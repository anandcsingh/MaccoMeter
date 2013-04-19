using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macco.Logging
{
    public class EventLogLogger : ILogger
    {
        #region ILogger Members

        public void Log(string message)
        {
            EventLog.WriteEntry("Application", message);
        }

        #endregion
    }
}
