using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneGraphReader.Scene
{
    public class Map:SceneObject
    {
        public Map(string line, ref StreamReader reader):base(line)
        {
            ParseObject(ref reader);
        }

        public override void ParseObject(ref StreamReader stream)
        {
            string currentLine = stream.ReadLine();

            if (currentLine != null && currentLine == "(")
            {
                currentLine = stream.ReadLine();

                while(currentLine == "Wall")
                {
                    Wall wall = new Wall(currentLine,ref stream);

                    if (wall != null)
                    {                            
                        currentLine = stream.ReadLine();       
                    } 
                }

                if (currentLine == ")")
                {
                    return;
                }
            }

            throw new FormatException();
        }
    }
}
