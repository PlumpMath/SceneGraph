using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneGraphReader.Scene
{
    class ItemFolder:SceneObject
    {

        public List<Item> Items = new List<Item>();

        public ItemFolder(string line, ref StreamReader stream):base(line)
        {
            ParseObject(ref stream);
        }

        public override void ParseObject(ref StreamReader stream)
        {
            string currentLine = stream.ReadLine();

            if (currentLine != null)
            {
                while (currentLine == "Item")
                {
                    Item item = new Item(currentLine, ref stream);

                    if(item != null)
                    {
                        Items.Add(item);     
                    }
                }
            }
        }
    }
}
