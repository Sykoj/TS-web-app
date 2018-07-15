using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Collections.Generic;
using TableauxIO;
using System;
using TsWebApp.Data;
using TsWebApp.Model;
using TsWebApp.TableauViews;
using TsWebApp.TableauViews.Layout;
using TsWebApp.TableauViews.ViewTree;

namespace TsWebApp.Pages.Tableau {

    public class SolutionViewModel : PageModel {

        private ApplicationDbContext Persistence { get; set; }

        public TableauRequest TableauRequest { get; set; }

        public SolutionNode SolutionNode { get; set; }

        public string ViewForm { get; set; } = string.Empty;

        public List<string> Canvas;

        public SolutionViewModel(ApplicationDbContext persistence) {
            Persistence = persistence;
        }

        [ActionName("SolutionView")]
        public void OnGet(ulong id, string session) {

            var request = Persistence.TableauRequests.Find(id);
            Persistence.Entry(request).Collection(p => p.RawFormulas).Load();
            TableauRequest = request;

            string solutionJson = null;
            if (session != null) {

                solutionJson = HttpContext.Session.GetString(session);
                var result = JsonConvert.DeserializeObject<RequestResult>(solutionJson);
                SolutionNode = result.SolutionNode;
            }

            var viewBuilder = new ViewTreeBuilder<TextView>(new TextViewFactory());
            var view = viewBuilder.CreateViewTree(SolutionNode);

            LayoutProcessor<TextView> layout = new LayoutProcessor<TextView>(new TextViewOptions());
            layout.SetLayout(view);

            var canvasX = view.TreeWidth;
            var canvasY = view.TreeHeight;

            Canvas = new List<string>();
            for (int i = 0; i < canvasY; ++i) {
                Canvas.Add(new string(' ', (int)canvasX * 2));
            }

            PrintTree(Canvas, view);
            GenerateConnections(Canvas, view);
        }

        void GenerateConnections(List<string> canvas, ViewNode<TextView> node) {

            if (node is BinaryViewNode<TextView> binaryNode) {

                var (x, y) = node.Position;
                int axis = (int)x + LayoutProcessor<TextView>.GetAxisPrefixLength(node.View.Width);
                canvas[(int)(y + 1)] = Emplace(canvas[(int)(y + 1)], "|", axis);

                int leftAxis = (int)binaryNode.LeftChild.Position.X + LayoutProcessor<TextView>.GetAxisPrefixLength(binaryNode.LeftChild.View.Width);
                int rightAxis = (int)binaryNode.RightChild.Position.X +  LayoutProcessor<TextView>.GetAxisPrefixLength(binaryNode.RightChild.View.Width);

                var diff = rightAxis - leftAxis;
                var connection = new string('-', diff);

                canvas[(int)(y + 2)] = Emplace(canvas[(int)(y + 2)], connection, leftAxis);

                GenerateConnections(canvas, binaryNode.RightChild);
                GenerateConnections(canvas, binaryNode.LeftChild);

            } else if (node is UnaryViewNode<TextView> unaryNode) {

                if (unaryNode.Child.GetType() == typeof(CompletionViewNode<TextView>)
                    && unaryNode.Child.View == null || unaryNode.Child.View.Representation == string.Empty) {
                    return;
                }

                var (x, y) = node.Position;
                int axis = (int)x + LayoutProcessor<TextView>.GetAxisPrefixLength(node.View.Width);
                canvas[(int)(y + 1)] = Emplace(canvas[(int)(y + 1)], "|", axis);
                canvas[(int)(y + 2)] = Emplace(canvas[(int)(y + 2)], "|", axis);

                GenerateConnections(canvas, unaryNode.Child);
            }
        }

        void PrintTree(List<string> canvas, ViewNode<TextView> node) {

            int x = (int)node.Position.X;
            int y = (int)node.Position.Y;
            canvas[y] = Emplace(canvas[y], node.View.Representation, x);

            if (node is BinaryViewNode<TextView> binaryNode) {
                PrintTree(canvas, binaryNode.LeftChild);
                PrintTree(canvas, binaryNode.RightChild);
            }
            if (node is UnaryViewNode<TextView> unaryNode) {
                PrintTree(canvas, unaryNode.Child);
            }
        }

        string Emplace(string line, string text, int index) {

            string x = string.Empty;
            string y = string.Empty;
            if (index != 0) {
                x = line.Substring(0, index);
            }
            if (index + text.Length < line.Length) {
                y = line.Substring(index + text.Length);

            }

            return x + text + y;
        }


    }
}