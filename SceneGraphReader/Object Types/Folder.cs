using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace SceneGraphReader.Scene
{
    public class Folder:SceneObject
    {
        public Folder(string line, StreamReader stream):base(line)
        { 
            ParseObject(ref stream);
        }

        public Folder(string name):base(name){}

        public override void ParseObject(ref StreamReader stream)
        {
            throw new NotImplementedException();
        }

    }
}
