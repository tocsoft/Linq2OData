using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client.Provider.Writers
{
    internal class ByteArrayValueWriter : ValueWriterBase<byte[]>
    {
        public override string Write(object value)
        {
            var base64 = Convert.ToBase64String((byte[])value);
            return string.Format("X'{0}'", base64);
        }
    }
}
