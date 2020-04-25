using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Linq2OData.Client.Provider;

namespace Linq2OData.Client
{
    public static class ODataQueryableExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> AsODataQueryStringArguments<T>(this IQueryable<T> queryable)
        {
            if (queryable is null)
            {
                throw new ArgumentNullException(nameof(queryable));
            }

            var client = new ArgumentCapturingODataDataClient();
            ODataExpressionConverterSettings settings = ODataExpressionConverterSettings.Default;
            if (queryable.Provider is ODataQueryProvider<T> p)
            {
                settings = p.Settings;
            }

            var provider = new ODataQueryProvider<T>(client, settings);
            provider.Execute(queryable.Expression);

            return client.QueryStringParamaters;
        }

        private class ArgumentCapturingODataDataClient : IODataDataClient
        {
            public IEnumerable<KeyValuePair<string, string>> QueryStringParamaters { get; private set; } = Enumerable.Empty<KeyValuePair<string, string>>();

            public IEnumerable<TType> Execute<TType>(IEnumerable<KeyValuePair<string, string>> queryStringParamaters)
            {
                this.QueryStringParamaters = queryStringParamaters;
                return Enumerable.Empty<TType>();
            }

            public IEnumerable Execute(Type type, IEnumerable<KeyValuePair<string, string>> queryStringParamaters)
            {
                this.QueryStringParamaters = queryStringParamaters;
                return Enumerable.Empty<object>();
            }
        }
    }
}
