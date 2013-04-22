using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
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
                macco.changedHandler += macco_changedHandler;
                logger.WriteEntry("Macco Started");

            }
            else
            {
                logger.WriteEntry("Macco Settings not found or invalid.");
            }
        }

        void macco_changedHandler(object sender, MaccoEventArgs r)
        {
            using (StreamWriter sw = File.AppendText("data.csv"))
            {
                FileInfo f = new FileInfo(r.Path);
                sw.WriteLine("{0},{1},{2}", r.Path, r.FileSystemEventArgs.ChangeType, f.Length);
            }
        }

        protected override void OnStop()
        {
            if (macco != null) macco.Stop();
            logger.WriteEntry("Macco Stopped");
        }
    }
}
