using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empires.IO.Interfaces;

namespace Empires.IO
{
    public class Writer : IWriter
    {
        public void WriteLine(object content)
        {
            Console.Write(content.ToString());
        }
    }
}
