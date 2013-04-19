using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Macco.Configuration;

namespace Macco
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
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
            else
            {
                //logger.WriteEntry("Macco Settings not found or invalid.");
            }

            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[] 
            //{ 
            //    new MaccoService() 
            //};
            //ServiceBase.Run(ServicesToRun);
        }
    }
}
