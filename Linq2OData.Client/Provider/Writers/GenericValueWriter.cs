using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client.Provider.Writers
{
    internal class GenericValueWriter : IValueWriter
    {
        readonly Type type;
        readonly Func<object, ODataExpressionConverterSettings, string> odataFunction;

        public GenericValueWriter(Type type, Func<object, string> odataFunction) : this(type, (a, b) => odataFunction(a))
        {
        }
        public GenericValueWriter(Type type, Func<object, ODataExpressionConverterSettings, string> odataFunction)
        {
            this.odataFunction = odataFunction;
            this.type = type;
        }


        public bool Handles(Type typeToTest)
        {
            return type == typeToTest;
        }

        public string Write(object value, ODataExpressionConverterSettings settings)
        {
            return odataFunction(value, settings);
        }
    }
}
