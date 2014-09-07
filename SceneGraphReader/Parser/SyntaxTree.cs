using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneGraphReader.Parser
{
    class SyntaxTreeNode
    {
        private String value;
        
        private  List<SyntaxTreeNode> children;

        #region Static 
        public static SyntaxTreeNode CreateDefaultTree()
        {
            SyntaxTreeNode temp = new SyntaxTreeNode("root");
            temp.AddChild(CreateDefaultBG);
            temp.AddChild(CreateDefaultItem);
        }

        private static SyntaxTreeNode CreateDefaultBG()
        {

            string startExpression = "Start=[0-9]+,[0-9]+\n";
            string endExpression = "End=[0-9]+,[0-9]+\n";
            string wallExpression = "Wall\n\(("+startExpression+endExpression+"\n\))\n";
            string mapExpression = "Map\n\((\n("+wallExpression+")*\))";
            string bgExpression = "=BG=\n("+mapExpression+")*\n";


            SyntaxTreeNode end = new SyntaxTreeNode(endExpression);


            SyntaxTreeNode start = new SyntaxTreeNode();
            start.value = startExpression;

            SyntaxTreeNode wall = new SyntaxTreeNode();
            wall.value = wallExpression;
            wall.children.Add(start);
            wall.children.Add(end);

            SyntaxTreeNode map = new SyntaxTreeNode();
            map.value = mapExpression;
            map.children.Add(wall);

            SyntaxTreeNode head = new SyntaxTreeNode();
            head.value = bgExpression;
            head.children.Add(map);

        }

        private static SyntaxTreeNode CreateDefaultItem()
        {
            string posExpression = "Pos=[0-9]+,[0-9]+\n";
            string itemExpression = "Item\n\((\nName=\"[A-Z,a-z,0-9]*\"\n";
            string itemExpressionFull = itemExpression+"("+posExpression+")\))|("+itemExpression+")+";
            string itemHeaderExpression = "=ITEMS=\n("+itemExpressionFull+")*\n";

            SyntaxTreeNode position = new SyntaxTreeNode(posExpression);
            
            SyntaxTreeNode childItem = new SyntaxTreeNode(itemExpression);

            SyntaxTreeNode item = new SyntaxTreeNode(itemExpressionFull);
            item.children.Add(childItem);
            item.children.Add(position);

            SyntaxTreeNode head = new SyntaxTreeNode(itemHeaderExpression);
            head.children.Add(item);

        }

        public SyntaxTreeNode(string expression)        
        {
             value = expression;
             children = new List<SyntaxTreeNode>();
        }

        public void AddChild(SyntaxTreeNode child)
        {
            children.Add(child);
        }
    }
}
