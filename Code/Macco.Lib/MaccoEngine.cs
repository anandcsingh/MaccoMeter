using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macco.Lib
{
    public class MaccoEngine
    {
        public MaccoEngine(IEnumerable<Folder> locationsToMacco)
        {
            this.FoldersToMacco = locationsToMacco;
            Maccos = new List<FileSystemWatcher>();
            InitializeWatchers();
        }

        public void Start()
        {
            foreach (FileSystemWatcher macco in Maccos)
            {
                macco.EnableRaisingEvents = true;
            }
        }

        public void Stop()
        {
            foreach (FileSystemWatcher macco in Maccos)
            {
                macco.EnableRaisingEvents = false;
            }
        }

        private void SetupEventHandlers(FileSystemWatcher macco, WatcherChangeTypes whatToMacco)
        {
            if (whatToMacco == WatcherChangeTypes.All)
            {
                macco.Changed += macco_Changed;
                macco.Created += macco_Changed;
                macco.Deleted += macco_Changed;
                macco.Renamed += macco_Changed;
            }
            else
            {
                if (whatToMacco == WatcherChangeTypes.Changed)
                {
                    macco.Changed += macco_Changed;
                }
                if (whatToMacco == WatcherChangeTypes.Created)
                {
                    macco.Created += macco_Changed;
                }
                if (whatToMacco == WatcherChangeTypes.Deleted)
                {
                    macco.Deleted += macco_Changed;
                }
                if (whatToMacco == WatcherChangeTypes.Renamed)
                {
                    macco.Renamed += macco_Changed;
                }
            }
        }

        private void InitializeWatchers()
        {
            foreach (Folder folder in FoldersToMacco)
            {
                try
                {
                    FileSystemWatcher macco = new FileSystemWatcher
                    {
                        IncludeSubdirectories = folder.IncludeSubDirs,
                        Path = folder.Path,
                        NotifyFilter = NotifyFilters.Attributes | NotifyFilters.CreationTime | NotifyFilters.DirectoryName | NotifyFilters.FileName | NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Security | NotifyFilters.Size,
                        Filter = folder.Filter
                    };

                    SetupEventHandlers(macco, folder.WhatToMacco);
                    Maccos.Add(macco);
                    macco.EnableRaisingEvents = true;// begin to watch location
                }
                catch (Exception)
                {
                    Logger.Log(string.Format("Failed to start {0}. At Location {1}", folder.FriendlyName, folder.Path));
                }
            }
        }

        void macco_Changed(object sender, FileSystemEventArgs e)
        {
            if (changedHandler != null) // someone must subscribe
            {
                changedHandler(sender, new MaccoEventArgs
                {
                    FileSystemEventArgs = e,
                    //FriendlyName = FoldersToMacco.Single(f => f.Path == e.FullPath).FriendlyName,
                    Path = e.FullPath
                });
            }
        }

        public IEnumerable<Folder> FoldersToMacco { get; set; }

        public List<FileSystemWatcher> Maccos { get; set; }

        public ILogger Logger { get; set; }

        public delegate void MaccoEventHandler(object sender, MaccoEventArgs r);

        public event MaccoEventHandler changedHandler;
    }
}
