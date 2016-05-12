using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq2OData.Server
{
    public static class ModelFilterExtensions
    {
        public static IQueryable<object> Filter<T>(this IEnumerable<T> query, IEnumerable<KeyValuePair<string, string>> queryStringParamaters)
        {
            throw new NotImplementedException("Ensure you install a correct version for you framework");
        }
    }
}
