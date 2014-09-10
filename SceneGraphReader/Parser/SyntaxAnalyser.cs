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
                    string peek = PeekNextExpression(matchedExpression, node);
                   SyntaxTreeNode temp = TraverseTree(peek, node);
                    if (temp != null)
                    {
                        retNode.AddChild(temp);
                    }

                    matchedExpression = Regex.Replace(line, matchedExpression, "");
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

        private string PeekNextExpression(string line, SyntaxTreeNode node)
        {
            string matchException = MatchExpression(line,node.value);

            if (line == matchException)
            {
                MatchCollection matches = Regex.Matches(line, "(.|\n)*" + node.value + "(.|\n)*");
                if (matches.Count > 1)
                {
                    return matches[1].Value;
                }
                else
                    return "";
            }

            return line;
        }

    }
}
