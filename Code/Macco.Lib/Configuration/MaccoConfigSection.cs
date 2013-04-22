using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macco.Lib.Configuration
{
    public class MaccoConfigSection : ConfigurationSection
    {
        /// <summary>
        /// Returns an ASPNET2Configuration instance
        /// </summary>
        public static MaccoConfigSection GetConfig()
        {
            return ConfigurationManager.GetSection("MaccoConfigSection") as MaccoConfigSection;
        }

        [ConfigurationProperty("Maccos", IsRequired = true)]
        public MaccosCollection Maccos
        {
            get
            {
                return this["Maccos"] as MaccosCollection;
            }
        }

        //[ConfigurationProperty("reportRoot", IsRequired = true)]
        //public string ReportRoot
        //{
        //    get
        //    {
        //        return this["reportRoot"] as string;
        //    }
        //}
    }
}
