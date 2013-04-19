using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Macco.Lib.Configuration
{
    public class MaccosCollection : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new MaccoElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MaccoElement)element).FriendlyName;
        }

        public MaccoElement this[int idx]
        {
            get
            {
                return (MaccoElement)BaseGet(idx);
            }
        }
    }
}
