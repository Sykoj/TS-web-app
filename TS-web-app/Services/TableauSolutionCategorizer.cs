using System.Collections.Generic;
using System.Linq;
using Ts.App.Model;
using Ts.IO;

namespace Ts.App.Services {

    public class TableauSolutionCategorizer {

        public static TableauType CategorizeTableauSolution(SolutionNode tableauSolution) {

            var leaves = GetSolutionTreeLeaves(tableauSolution);

            var contradictionLeaves =
                (from leave in leaves where leave.GetType() == typeof(ContradictionNode) select leave)
                .Count();

            if (contradictionLeaves == leaves.Count) return TableauType.Contradictionary;
            else if (contradictionLeaves == 0) return TableauType.AllBranchesNoncontradictionary;
            else return TableauType.OtherExpected;
        }

        private static List<CompletionNode> GetSolutionTreeLeaves(SolutionNode tableauSolution) {

            var leaves = new List<CompletionNode>();
            tableauSolution.AddLeaves(leaves);
            return leaves;
        }
    }

    public static class SolutionNodeExtensions {

        public static void AddLeaves(this SolutionNode node, List<CompletionNode> leaves) {

            switch (node) {
                case CompletionNode completionNode:
                    leaves.Add(completionNode);
                    break;
                case BinaryNode binaryNode:
                    binaryNode.LeftChild.AddLeaves(leaves);
                    binaryNode.RightChild.AddLeaves(leaves);
                    break;
                case UnaryNode unaryNode:
                    unaryNode.Child.AddLeaves(leaves);
                    break;
            }
        }
    }
}
