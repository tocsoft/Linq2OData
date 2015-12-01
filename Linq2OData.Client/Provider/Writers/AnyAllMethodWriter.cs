using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client.Provider.Writers
{

    internal class AnyAllMethodWriter : IMethodCallWriter
    {
        public bool CanHandle(MethodCallExpression expression)
        {
            Contract.Assert(expression.Method != null);

            return expression.Method.Name == "Any" || expression.Method.Name == "All";
        }

        public string Handle(MethodCallExpression expression, Func<Expression, string> expressionWriter)
        {
            Contract.Assert(expression.Method != null);
            Contract.Assert(expression.Arguments != null);

            var firstArg = expressionWriter(expression.Arguments[0]);
            var method = expression.Method.Name.ToLowerInvariant();
            string parameter = null;
            var lambdaParameter = expression.Arguments[1] as LambdaExpression;
            if (lambdaParameter != null)
            {
                var first = lambdaParameter.Parameters.First();
                parameter = first.Name ?? first.ToString();
            }

            var predicate = expressionWriter(expression.Arguments[1]);

            return string.Format("{0}/{1}({2}:{3})", firstArg, method, parameter, predicate);
        }
    }
}
