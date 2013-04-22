using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Macco.Lib.Configuration
{
    public class MaccosCollection : ConfigurationElementCollection
    {
        public MaccoElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as MaccoElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new MaccoElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MaccoElement)element).Index;
        }
    }
}
