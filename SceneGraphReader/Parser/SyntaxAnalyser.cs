using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SceneGraphReader.Scene;

namespace SceneGraphReader.Parser
{
    public class SyntaxAnalyser
    {
        private SyntaxTreeNode syntaxTree;

        public SyntaxAnalyser()
        {
            syntaxTree = SyntaxTreeNode.CreateDefaultTree();
        }

        public SyntaxTreeNode AnalyzeSyntax(string file)
        {
            SyntaxTreeNode root = TraverseTree(file,syntaxTree);

            return root;
        }
        
        private SyntaxTreeNode TraverseTree(string line, SyntaxTreeNode syntaxNode)
        {
            string matchedExpression = MatchExpression(line, syntaxNode.value);
            
            if (matchedExpression != null)
            {
                SyntaxTreeNode retNode = new SyntaxTreeNode(matchedExpression);

                foreach (SyntaxTreeNode node in syntaxNode.GetChildren())
                {
                    SyntaxTreeNode temp = TraverseTree(matchedExpression, node);
                    if (temp != null)
                    {
                        retNode.AddChild(temp);
                    }

                    matchedExpression = Regex.Replace(matchedExpression, node.value, "");
                }

                return retNode;
            }

            return null;
        }


        private string MatchExpression(string line, string expression)
        { 
            Match match = Regex.Match(line,expression);
            if (match.Value != "")
            {
                return match.Value;
            }

            return null;
        }

    }
}
