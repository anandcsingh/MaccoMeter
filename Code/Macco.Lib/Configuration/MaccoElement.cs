using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Macco.Lib.Configuration
{
    public class MaccoElement : ConfigurationElement
    {
        public string FriendlyName { get; set; }
        public bool IncludeSubDirs { get; set; }
        public string Path { get; set; }
        public string Filter { get; set; }
        public WatcherChangeTypes WhatToMacco { get; set; }
    }
}
