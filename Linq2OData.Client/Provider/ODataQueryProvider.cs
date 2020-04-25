using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client.Provider
{
    public class ODataQueryProvider<TType> : IQueryProvider
    {
        private readonly IODataDataClient client;
        private readonly ExpressionProcessor _expressionProcessor;
        private readonly ParameterBuilder _parameterBuilder;
        public ODataExpressionConverterSettings Settings { get; }

        public ODataQueryProvider(IODataDataClient client, ODataExpressionConverterSettings settings)
        {
            this.Settings = settings;
            this.client = client;
            _expressionProcessor = new ExpressionProcessor(settings);
            _parameterBuilder = new ParameterBuilder();
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new ODataQueryable<TType>(client, Settings, expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new ODataQueryable<TElement>(client, Settings, expression);
        }

        public object Execute(Expression expression)
        {
            var methodCallExpression = expression as MethodCallExpression;
            var resultsLoaded = false;
            Func<ParameterBuilder, IEnumerable<TType>> loadFunc = p =>
            {
                resultsLoaded = true;
                return GetResults(p);
            };
            return (methodCallExpression != null
                        ? _expressionProcessor.ProcessMethodCall(methodCallExpression, _parameterBuilder, loadFunc, GetResults)
                        : GetResults(_parameterBuilder))
                   ?? (resultsLoaded
                        ? null
                        : GetResults(_parameterBuilder));

            return GetResults(_parameterBuilder);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return (TResult)Execute(expression);
        }

        protected IEnumerable<TType> GetResults(ParameterBuilder paramaters)
        {
            var keyValuePairs = paramaters.Build();
            return client.Execute<TType>(keyValuePairs);
        }
        protected IEnumerable GetResults(Type type, ParameterBuilder paramaters)
        {
            var keyValuePairs = paramaters.Build();
            return client.Execute(type, keyValuePairs);
        }
    }
}
