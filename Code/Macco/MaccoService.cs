using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Macco.Configuration;

namespace Macco
{
    public partial class MaccoService : ServiceBase
    {
        MaccoEngine macco;
        public MaccoService()
        {
            InitializeComponent();
            logger.Log = "Application";
        }

        protected override void OnStart(string[] args)
        {
            MaccoConfigSection section = (MaccoConfigSection)ConfigurationManager.GetSection("MaccoSettings");
            if (section != null)
            {
                macco = new MaccoEngine(section.Maccos.Cast<MaccoElement>().Select(m => new Folder
                {
                    Filter = m.Filter,
                    FriendlyName = m.FriendlyName,
                    ID = Guid.NewGuid(),
                    IncludeSubDirs = m.IncludeSubDirs,
                    Path = m.Path,
                    WhatToMacco = m.WhatToMacco
                }));
                macco.Start();
                logger.WriteEntry("Macco Started");

            }
            else
            {
                logger.WriteEntry("Macco Settings not found or invalid.");
            }
        }

        protected override void OnStop()
        {
            if (macco != null) macco.Stop();
            logger.WriteEntry("Macco Stopped");
        }
    }
}
