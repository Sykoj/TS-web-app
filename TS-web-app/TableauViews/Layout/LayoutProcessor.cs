using TsWebApp.TableauViews.ViewTree;

namespace TsWebApp.TableauViews.Layout {

    public class LayoutProcessor<T> where T : ILayoutable {

        private uint HorizontalMargin { get; }
        private uint VerticalMargin { get; }

        public LayoutProcessor(ILayoutOptions<T> options) {
            HorizontalMargin = options.HorizontalMargin;
            VerticalMargin = options.VerticalMargin;
        }

        public ViewNode<T> SetLayout(ViewNode<T> node) {

            (node.TreeWidth, node.TreeHeight) = ComputeSizes(node);
            node.TreeWidth++;
            ComputePosition(node, GetAxisPrefixLength(node.TreeWidth), - VerticalMargin - node.View.Height);
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

        public int GetAxisPrefixLength(uint nodeWidth) {
            
            if (nodeWidth == 1) {
                return 0;
            }
            else {
                return (int) (nodeWidth / 2) - 1;
            }
        }

        private void ComputePosition(ViewNode<T> node, long parentNodeAxis, long currentTreeHeight) {

            node.Position = (parentNodeAxis - GetAxisPrefixLength(node.View.Width),
                             currentTreeHeight + node.View.Height + VerticalMargin);

            if (node is BinaryViewNode<T> binaryNode) {

                var childLevelLength = binaryNode.LeftChild.TreeWidth + HorizontalMargin + binaryNode.RightChild.TreeWidth;

                long leftNodeAxis = parentNodeAxis - (childLevelLength / 2) + binaryNode.LeftChild.TreeWidth / 2;
                long rightNodeAxis = parentNodeAxis + (childLevelLength / 2) - binaryNode.RightChild.TreeWidth / 2;

                ComputePosition(binaryNode.RightChild, rightNodeAxis, node.Position.Y);
                ComputePosition(binaryNode.LeftChild, leftNodeAxis, node.Position.Y);
            }
            else if (node is UnaryViewNode<T> unaryNode) {

                ComputePosition(unaryNode.Child, parentNodeAxis, node.Position.Y);
            }
            else if (node is CompletionViewNode<T> completionNode) {
                return;  
            }
        }
    }
}
