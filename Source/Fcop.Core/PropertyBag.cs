using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcop.Core
{
    public class PropertyBag
    {

        public T ReadProperty<T>(string Name)
        {
            return default(T);
        }

        public void Write(string Key, object Value)
        {

        }

    }
}
