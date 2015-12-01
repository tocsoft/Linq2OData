using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client.Provider.Writers
{
    internal static class ParameterValueWriter
    {
        private static readonly IList<IValueWriter> ValueWriters;

        static ParameterValueWriter()
        {
            ValueWriters = new List<IValueWriter>
                            {
                                //new EnumValueWriter(),
                                //new StringValueWriter(),
                                new BooleanValueWriter(),
                                //new IntValueWriter(),
                                //new LongValueWriter(),
                                //new ShortValueWriter(),
                                //new UnsignedIntValueWriter(),
                                //new UnsignedLongValueWriter(),
                                //new UnsignedShortValueWriter(),
                                new ByteArrayValueWriter(),
                                //new StreamValueWriter(),
                                //new DecimalValueWriter(),
                                //new DoubleValueWriter(),
                                //new SingleValueWriter(),
                                //new ByteValueWriter(),
                                //new GuidValueWriter(),
                                //new DateTimeValueWriter(),
                                //new TimeSpanValueWriter(),
                                //new DateTimeOffsetValueWriter()
                            };
        }

        public static string Write(object value)
        {
            if (value == null)
            {
                return "null";
            }
            var type = value.GetType();

            if (type.IsEnum)
            {
                return string.Format("{0}", (int)value);
            }

            var writer = ValueWriters.FirstOrDefault(x => x.Handles(type));

            if (writer != null)
            {
                return writer.Write(value);
            }

            if (typeof(Nullable<>).IsAssignableFrom(type))
            {
                var genericParameter = type.GetGenericArguments()[0];

                return Write(Convert.ChangeType(value, genericParameter, CultureInfo.CurrentCulture));
            }


            return value.ToString();
        }
    }
}
