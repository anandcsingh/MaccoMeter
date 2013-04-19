using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macco.Lib
{
    public class MaccoEventArgs
    {
        public string FriendlyName { get; set; }
        public string Path { get; set; }
        public FileSystemEventArgs FileSystemEventArgs { get; set; }
    }
}
