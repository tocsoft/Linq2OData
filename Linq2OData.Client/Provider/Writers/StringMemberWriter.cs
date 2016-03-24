using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Linq;

namespace Linq2OData.Client.Provider.Writers
{
    internal class StringMemberWriter : IMemberCallWriter
    {
        static string[] methods = { "Length" };

        public bool CanHandle(MemberExpression expression)
        {
            return expression.Member.DeclaringType == typeof(string)
                   && methods.Contains(expression.Member.Name);
        }

        public string Handle(MemberExpression expression, ODataExpressionConverterSettings settings)
        {
            return expression.Member.Name.ToLowerInvariant();
        }
    }
}