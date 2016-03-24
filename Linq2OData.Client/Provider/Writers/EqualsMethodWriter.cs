using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace Linq2OData.Client.Provider.Writers
{
    internal class EqualsMethodWriter : IMethodCallWriter
    {
        public bool CanHandle(MethodCallExpression expression)
        {
            return expression.Method.Name == "Equals";
        }

        public string Handle(MethodCallExpression expression, Func<Expression, string> expressionWriter, ODataExpressionConverterSettings settings)
        {
            Contract.Assert(expression.Arguments != null);

            return string.Format(
                "{0} eq {1}",
                expressionWriter(expression.Object),
                expressionWriter(expression.Arguments[0]));
        }
    }
}