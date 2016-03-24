using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client.Provider.Writers
{
    class GenericMemberWriter : IMemberCallWriter
    {
        readonly Type type;
        readonly string methodName;
        readonly Func<ODataExpressionConverterSettings, string> odataFunction;

        public GenericMemberWriter(Type type, string methodName, string odataFunction)
            : this(type, methodName, (s) => odataFunction)
        {

        }

        public GenericMemberWriter(Type type, string methodName, Func<ODataExpressionConverterSettings, string> odataFunction)
        {
            this.odataFunction = odataFunction;
            this.methodName = methodName;
            this.type = type;
        }
        
        public bool CanHandle(MemberExpression expression)
        {
            return expression.Member.DeclaringType == type
                   && methodName.Equals(expression.Member.Name, StringComparison.Ordinal);
        }

        public string Handle(MemberExpression expression, ODataExpressionConverterSettings settings)
        {
            return odataFunction(settings);
        }
    }
}
