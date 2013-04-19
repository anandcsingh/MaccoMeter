using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macco
{
    public class Folder
    {
        public string FriendlyName { get; set; }
        public bool IncludeSubDirs { get; set; }
        public string Path { get; set; }
        public string Filter { get; set; }
        public WatcherChangeTypes WhatToMacco { get; set; }
        public Guid ID { get; set; }
    }
}
