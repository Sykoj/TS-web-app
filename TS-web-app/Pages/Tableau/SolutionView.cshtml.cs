using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Web;
using System.Collections.Generic;
using TableauxIO;
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

            List<string> canvas = new List<string>();
            for (int i = 0; i < canvasY; ++i) {
                canvas.Add(new string(' ', (int)canvasX));
            }

            PrintTree(canvas, view);
            
            foreach(var line in canvas) {
                var htmlEncodedLine = HttpUtility.HtmlEncode(line);
                ViewForm = ViewForm + htmlEncodedLine + "<br>";
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

            var x = line.Substring(0, index);
            var y = line.Substring(index + text.Length);
            return x + text + y;
        }


    }
}