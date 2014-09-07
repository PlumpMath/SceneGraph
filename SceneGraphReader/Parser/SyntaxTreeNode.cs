using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneGraphReader.Parser
{
    [Serializable]
    public class SyntaxTreeNode
    {
        
        #region Static Functions 
        public static SyntaxTreeNode CreateDefaultTree()
        {
            
            SyntaxTreeNode bgNode = CreateDefaultBG();
            SyntaxTreeNode itemNode = CreateDefaultItem();

            SyntaxTreeNode root = new SyntaxTreeNode(bgNode.value + itemNode.value);

            root.AddChild(bgNode);
            root.AddChild(itemNode);

            return root;
        }

        private static SyntaxTreeNode CreateDefaultBG()
        {

            string startExpression = "Start=[0-9]+,[0-9]+\n";
            string endExpression = "End=[0-9]+,[0-9]+\n";
            string wallExpression = "Wall\n\\(("+startExpression+endExpression+"\n\\))\n";
            string mapExpression = "Map\n\\((\n("+wallExpression+")*\\))";
            string bgExpression = "=BG=\n("+mapExpression+")*\n?";


            SyntaxTreeNode end = new SyntaxTreeNode(endExpression);

            SyntaxTreeNode start = new SyntaxTreeNode(startExpression);

            SyntaxTreeNode wall = new SyntaxTreeNode(wallExpression);
            wall.AddChild(start);
            wall.AddChild(end);

            SyntaxTreeNode map = new SyntaxTreeNode(mapExpression);
            map.AddChild(wall);

            SyntaxTreeNode head = new SyntaxTreeNode(bgExpression);
            head.AddChild(map);

            return head;
        }

        private static SyntaxTreeNode CreateDefaultItem()
        {
            string posExpression = "Pos=[0-9]+,[0-9]+\n";
            string nameExpression = "Name=\"[A-Z,a-z,0-9]*\"";
            string itemExpression = "Item\n\\((\n"+nameExpression+"\n";
            string itemExpressionFull = itemExpression+"("+posExpression+")\\))|("+itemExpression+")+";
            string itemHeaderExpression = "=ITEMS=\n("+itemExpressionFull+")*\n?";

            SyntaxTreeNode name = new SyntaxTreeNode(nameExpression);

            SyntaxTreeNode position = new SyntaxTreeNode(posExpression);
           
            SyntaxTreeNode childItem = new SyntaxTreeNode(itemExpression);

            SyntaxTreeNode item = new SyntaxTreeNode(itemExpressionFull);
            item.AddChild(name);
            item.AddChild(childItem);
            item.AddChild(position);

            SyntaxTreeNode head = new SyntaxTreeNode(itemHeaderExpression);
            head.AddChild(item);

            return head;
        }

#endregion

        public string value
        {
            get
            {
                return value;
            }
        }
        
        private string _value;
        
        private  List<SyntaxTreeNode> children;

        public SyntaxTreeNode(string expression)        
        {
             children = new List<SyntaxTreeNode>();
             _value = expression;
        }

        public void AddChild(SyntaxTreeNode child)
        {
            children.Add(child);
        }

        public List<SyntaxTreeNode> GetChildren()
        {
            return children;
        }
    }
}