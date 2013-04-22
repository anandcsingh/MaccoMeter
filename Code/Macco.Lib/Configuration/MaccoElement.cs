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
        [ConfigurationProperty("Index", IsRequired = false)]
        public int Index
        {
            get
            {
                return int.Parse(this["Index"]as string ?? "0");
            }
        }

        [ConfigurationProperty("FriendlyName", IsRequired = true)]
        public string FriendlyName
        {
            get
            {
                return this["FriendlyName"] as string;
            }
        }

        [ConfigurationProperty("IncludeSubDirs", IsRequired = true)]
        public string IncludeSubDirs
        {
            get
            {
                return this["IncludeSubDirs"] as string;
            }
        }

        [ConfigurationProperty("Path", IsRequired = true)]
        public string Path
        {
            get
            {
                return this["Path"] as string;
            }
        }

        [ConfigurationProperty("Filter", IsRequired = true)]
        public string Filter
        {
            get
            {
                return this["Filter"] as string;
            }
        }

        [ConfigurationProperty("WhatToMacco", IsRequired = true)]
        public string WhatToMacco
        {
            get
            {
                return this["WhatToMacco"] as string;
            }
        }

    }
}
