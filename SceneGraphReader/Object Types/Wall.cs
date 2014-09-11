using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SceneGraphReader.Scene
{
    public class Wall:SceneObject
    {
        public Vector2D Start;
        public Vector2D End;

        public Wall(string line, ref StreamReader stream):base(line)
        {
            ParseObject(ref stream);
        }

        public override void ParseObject(ref StreamReader stream)
        {
            string currentLine = stream.ReadLine();

            if (currentLine != null && currentLine == "(")
            {
                currentLine = stream.ReadLine();

                Start = new Vector2D(currentLine,"Start");
                if (Start != null)
                {
                    currentLine = stream.ReadLine();
                    End = new Vector2D(currentLine, "End");

                    if (End != null)
                    {
                        currentLine = stream.ReadLine();

                        if (currentLine == ")")
                        {
                            return;
                        }
                    }
                }
            }
            throw new FormatException();
        }
    }
}
