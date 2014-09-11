using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneGraphReader.Scene
{
    public class BGFolder:Folder
    {
        public List<Map> Maps = new List<Map>();

        public BGFolder(string line, StreamReader stream):base(line)
        {
            ParseObject(ref stream);
        }

        public override void ParseObject(ref StreamReader stream)
        {
            string currentLine = stream.ReadLine();

            if (currentLine != null)
            {
                while (currentLine == "Map")
                {
                    Map map = new Map(currentLine,ref stream);

                    if (map != null)
                    {
                        Maps.Add(map);
                    }
                }
            }
        }

    }
}
