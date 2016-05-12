using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Linq2OData.Server.Parser;

namespace Linq2OData.Server
{
    public static class ModelFilterExtensions
    {
        public static IQueryable<object> Filter<T>(this IEnumerable<T> source, IEnumerable<KeyValuePair<string, string>> query)
        {

            var parser = new ParameterParser<T>();

            return Filter(source, parser.Parse(query));
        }
        public static IQueryable<object> Filter<T>(this IEnumerable<T> source, string filter)
        {
            return Filter(source, new Dictionary<string, string>() { { StringConstants.FilterParameter, filter } });
        }
        /// <summary>
        /// Filters the source collection using the passed query parameters.
        /// </summary>
        /// <param name="source">The source items to filter.</param>
        /// <param name="filter">The filter to apply.</param>
        /// <typeparam name="T">The <see cref="Type"/> of items in the source collection.</typeparam>
        /// <returns>A filtered and projected enumeration of the source collection.</returns>
        public static IQueryable<object> Filter<T>(this IEnumerable<T> source, IModelFilter<T> filter)
        {
            return filter == null ? source.OfType<object>().AsQueryable() : filter.Filter(source);
        }
    }
}
