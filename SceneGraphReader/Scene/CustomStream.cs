using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SceneGraphReader.Scene
{
    public class CustomStream: StreamReader
    {
        public string PeekLine()
        {
            string peekLine;
            
            long cachedPosition = BaseStream.Position;
            
            peekLine = ReadLine();

            BaseStream.Position = cachedPosition;

            return peekLine;
        }
    }
}
