using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client.Provider.Writers
{
    internal class BooleanValueWriter : ValueWriterBase<bool>
    {
        public override string Write(object value)
        {
            var boolean = (bool)value;

            return boolean ? "true" : "false";
        }
    }
}
