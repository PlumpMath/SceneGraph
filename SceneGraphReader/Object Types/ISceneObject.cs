using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SceneGraphReader.Scene
{
    public abstract class SceneObject
    {
        public string Name;
        
        public string ObjectType;

        public SceneObject(string line)
        {
            Name = line;
        }

        public abstract void ParseObject(ref StreamReader stream);
    }
}
