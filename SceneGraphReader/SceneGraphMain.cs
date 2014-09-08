using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SceneGraphReader.Parser;
using SceneGraphReader.Scene;

namespace SceneGraphReader
{
    class SceneGraphMain
    {
        static void Main(string[] args)
        {
            SyntaxAnalyser testAnalyser = new SyntaxAnalyser();

            SyntaxTreeNode temp = testAnalyser.AnalyzeSyntax("==BG==\n");

            foreach (SyntaxTreeNode node in temp.GetChildren())
            {
                if (node.value == "==BG==\n")
                {
                    return;
                }
            }

        }
    }
}
