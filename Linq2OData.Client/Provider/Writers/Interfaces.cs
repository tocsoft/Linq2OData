using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client.Provider.Writers
{
    public interface IMethodCallWriter
    {
        bool CanHandle(MethodCallExpression expression);

        string Handle(MethodCallExpression expression, Func<Expression, string> expressionWriter, ODataExpressionConverterSettings settings);
    }

    public interface IMemberCallWriter
    {
        bool CanHandle(MemberExpression expression);

        string Handle(MemberExpression expression, ODataExpressionConverterSettings settings);
    }

    public interface IValueWriter
    {
        bool Handles(Type type);

        string Write(object value, ODataExpressionConverterSettings settings);
    }

}
