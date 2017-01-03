using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core
{
    public class PropertyBag
    {

        private Dictionary<string, object> _properties = new Dictionary<string, object>();

        public T ReadProperty<T>(string Name)
        {
            if (_properties.ContainsKey(Name))
                return (T)_properties[Name];
            return default(T);
        }

        public object ReadProperty(string Name)
        {
            if (_properties.ContainsKey(Name))
                return _properties[Name];
            return null;
        }

        public void Write(string Key, object Value)
        {
            _properties[Key] = Value;
        }

        public List<string> Keys
        {
            get
            {
                return _properties.Keys.ToList();
            }
        }

    }
}
