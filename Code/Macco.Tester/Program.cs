using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macco.Lib;
using Macco.Lib.Configuration;

namespace Macco.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = ConfigurationManager.AppSettings["smoo"];
            MaccoConfigSection section = (MaccoConfigSection)ConfigurationManager.GetSection("MaccoSettings");
            if (section != null)
            {
                MaccoEngine macco = new MaccoEngine(section.Maccos.Cast<MaccoElement>().Select(m => new Folder
                {
                    Filter = m.Filter,
                    FriendlyName = m.FriendlyName,
                    ID = Guid.NewGuid(),
                    IncludeSubDirs = m.IncludeSubDirs,
                    Path = m.Path,
                    WhatToMacco = m.WhatToMacco
                }));
                macco.Start();

            }
        }
    }
}
