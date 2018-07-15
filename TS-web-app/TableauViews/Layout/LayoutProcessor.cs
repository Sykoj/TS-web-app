using TsWebApp.TableauViews.ViewTree;

namespace TsWebApp.TableauViews.Layout {

    public class LayoutProcessor<T> where T : ILayoutable {

        private uint HorizontalMargin { get; }
        private uint VerticalMargin { get; }
        public delegate (int X, int Y) RootPositionSetter(uint TreeWidth, uint TreeHeight, uint RootWidth, uint RootHeight);

        public RootPositionSetter RootPositionSet { get; }

        public LayoutProcessor(ILayoutOptions<T> options) {
            HorizontalMargin = options.HorizontalMargin;
            VerticalMargin = options.VerticalMargin;
            RootPositionSet = options.RootPosition;
        }

        public ViewNode<T> SetLayout(ViewNode<T> node) {

            (node.TreeWidth, node.TreeHeight) = ComputeSizes(node);

            (int X, int Y) = RootPositionSet(
                node.TreeWidth, node.TreeHeight,
                node.View.Width, node.View.Height
                );

            node.Position = (X, Y);
            ComputeChildPositions(node);
            return node;
        }

        private (uint TreeWidth, uint TreeHeight) ComputeSizes(ViewNode<T> node) {

            uint subtreeWidth = 0;
            uint subtreeHeight = 0;

            if (node is BinaryViewNode<T> binaryNode) {

                (binaryNode.LeftChild.TreeWidth, binaryNode.LeftChild.TreeHeight) = ComputeSizes(binaryNode.LeftChild);
                (binaryNode.RightChild.TreeWidth, binaryNode.RightChild.TreeHeight) = ComputeSizes(binaryNode.RightChild);

                subtreeWidth = binaryNode.LeftChild.TreeWidth + HorizontalMargin + binaryNode.RightChild.TreeWidth;
                subtreeHeight = node.View.Height + ((binaryNode.LeftChild.TreeHeight > binaryNode.RightChild.TreeHeight) ?
                    binaryNode.LeftChild.TreeHeight + VerticalMargin
                    : binaryNode.RightChild.TreeHeight + VerticalMargin);
            } else if (node is UnaryViewNode<T> unaryNode) {

                (unaryNode.Child.TreeWidth, unaryNode.Child.TreeHeight) = ComputeSizes(unaryNode.Child);
                subtreeWidth = unaryNode.Child.TreeWidth;
                subtreeHeight = unaryNode.Child.TreeHeight + VerticalMargin + unaryNode.View.Height;
            } else if (node is CompletionViewNode<T> completionNode) {

                subtreeHeight = completionNode.View.Height;
            }

            if (node.View.Width > subtreeWidth) {
                subtreeWidth = node.View.Width;
            }

            return (subtreeWidth, subtreeHeight);
        }

        private void ComputeChildPositions(ViewNode<T> node) {

            if (node is BinaryViewNode<T> binaryNode) {

                var subtreeSum = binaryNode.LeftChild.TreeWidth + HorizontalMargin + binaryNode.RightChild.TreeWidth;
                long leftHorizontalPosition = 0;
                long rightHorizontalPosition = 0;

                var rf1 = (binaryNode.LeftChild.TreeWidth - binaryNode.LeftChild.View.Width) / 2;
                var rf2 = (binaryNode.RightChild.TreeWidth - binaryNode.RightChild.View.Width) / 2;
                var leftBorder = node.Position.X - (node.TreeWidth - node.View.Width) / 2;

                leftHorizontalPosition = leftBorder + (node.TreeWidth - subtreeSum) / 2 + rf1;
                rightHorizontalPosition = leftHorizontalPosition + rf1 + HorizontalMargin + rf2;

                binaryNode.LeftChild.Position = (leftHorizontalPosition, node.Position.Y + node.View.Height + VerticalMargin);
                binaryNode.RightChild.Position = (rightHorizontalPosition + binaryNode.LeftChild.View.Width, node.Position.Y + node.View.Height + VerticalMargin);

                ComputeChildPositions(binaryNode.RightChild);
                ComputeChildPositions(binaryNode.LeftChild);
            } else if (node is UnaryViewNode<T> unaryNode) {

                var leftBorder = node.Position.X - (node.TreeWidth - node.View.Width) / 2;
                long childHorizontalPosition = leftBorder + (node.TreeWidth - unaryNode.Child.View.Width) / 2;

                unaryNode.Child.Position = (childHorizontalPosition, unaryNode.Position.Y + node.View.Height + VerticalMargin);
                ComputeChildPositions(unaryNode.Child);
            } else if (node is CompletionViewNode<T> completionNode) {
                return;
            }
        }
    }
}
