using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SceneGraphReader.Scene
{
    public class Vector2D
    {
        public string Name;
        public float X;
        public float Y;

        public Vector2D(string line, string title)
        {
            Match match = Regex.Match(line, title + "=(?<x>[0-9]*.?[0-9]*,?<y>)[0-9]*.?[0-9]*");

            if (match.Value != "")
            {
                string stringX = match.Groups["x"].Value;
                if (!float.TryParse(stringX, out X))
                    throw new FormatException();

                string stringY = match.Groups["y"].Value;
                if (float.TryParse(stringY, out Y))
                    throw new FormatException();

                Name = title;
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}
