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

            SyntaxTreeNode openWall = new SyntaxTreeNode("(");
            SyntaxTreeNode wall = new SyntaxTreeNode("Wall");
            SyntaxTreeNode openMap = new SyntaxTreeNode("(");
            SyntaxTreeNode map = new SyntaxTreeNode("Map");
            SyntaxTreeNode head = new SyntaxTreeNode("==BG==");
        }

        private static SyntaxTreeNode CreateDefaultItem()
        {
            
        }

#endregion

        public string value
        {
            get
            {
                return _value;
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