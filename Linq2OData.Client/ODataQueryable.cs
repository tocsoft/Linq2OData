using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Linq2OData.Client.Provider;

namespace Linq2OData.Client
{
    public class ODataQueryable<TType> : IQueryable<TType>
    {
        private readonly ODataQueryProvider<TType> queryProvider;
        private readonly ODataExpressionConverterSettings settings;

        public ODataQueryable(IODataDataClient client) : this(client, ODataExpressionConverterSettings.Default)
        {
        }

        public ODataQueryable(IODataDataClient client, ODataExpressionConverterSettings settings)
        {
            queryProvider = new ODataQueryProvider<TType>(client, settings);
            Provider = queryProvider;
            Expression = Expression.Constant(this);
        }


        internal ODataQueryable(IODataDataClient client, ODataExpressionConverterSettings settings, Expression expression)
        {
            queryProvider = new ODataQueryProvider<TType>(client, settings);
            Provider = queryProvider;
            Expression = expression;
            this.settings = settings;
        }

        public Type ElementType
        {
            get { return typeof(TType); }
        }

        public Expression Expression { get; protected set; }

        public IQueryProvider Provider { get; protected set; }

        public IEnumerator<TType> GetEnumerator()
        {
            var enumerable = Provider.Execute<IEnumerable<TType>>(Expression);
            return (enumerable ?? new TType[0]).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Provider.Execute<IEnumerable>(Expression).GetEnumerator();
        }
    }
}
