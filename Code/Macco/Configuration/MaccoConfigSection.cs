using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macco.Configuration
{
    public class MaccoConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("Maccos")]
        public MaccosCollection Maccos
        {
            get { return (MaccosCollection)base["Maccos"]; }
        }
    }
}
