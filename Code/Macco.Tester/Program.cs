using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
            MaccoConfigSection section = (MaccoConfigSection)ConfigurationManager.GetSection("MaccoConfigSection");
            if (section != null)
            {
                List<Folder> list = new List<Folder>();
                foreach (MaccoElement m in section.Maccos)
                {
                    list.Add(new Folder
                    {
                        Filter = m.Filter,
                        FriendlyName = m.FriendlyName,
                        ID = Guid.NewGuid(),
                        IncludeSubDirs = bool.Parse(m.IncludeSubDirs),
                        Path = m.Path,
                        WhatToMacco = (System.IO.WatcherChangeTypes)Enum.Parse(typeof(System.IO.WatcherChangeTypes), m.WhatToMacco)
                    });
                }

                MaccoEngine macco = new MaccoEngine(list);
                macco.Start();
                macco.changedHandler += macco_changedHandler;
                Thread.Sleep(600000);
            }


        }


        static void macco_changedHandler(object sender, MaccoEventArgs r)
        {
            using (StreamWriter sw = File.AppendText("data.csv"))
            {
                FileInfo f = new FileInfo(r.Path);
                sw.WriteLine("{0},{1},{2}", r.Path, r.FileSystemEventArgs.ChangeType, f.Length);
            }
        }
    }
}
