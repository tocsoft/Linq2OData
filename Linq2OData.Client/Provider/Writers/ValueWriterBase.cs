using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client.Provider.Writers
{
    internal abstract class ValueWriterBase<T> : IValueWriter
    {
        public bool Handles(Type type)
        {
            return typeof(T) == type;
        }

        public abstract string Write(object value);
    }
}
