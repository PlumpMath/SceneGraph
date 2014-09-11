using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneGraphReader.Scene
{
    class ObjectFactory
    {
        private static Dictionary<string,Type> SyntaxTable = new Dictionary<string,Type>()
        {
                {"==BG==",typeof(BGFolder)},
                {"Wall",typeof(Wall)},
                {"==ITEMS==",typeof(ItemFolder)},
                {"Item",typeof(Item)},
        };

        public SceneObject ReadObjects(StreamReader fileStream)
        {
            Folder root = new Folder("root");
            
            string curLine = fileStream.ReadLine();

            while (curLine != null)
            {
                if (SyntaxTable.ContainsKey(curLine))
                {
                    SceneObject tempObject = Activator.CreateInstance(SyntaxTable[curLine], curLine, fileStream) as SceneObject;

                }
            }

            return root;
        }
    }
}
