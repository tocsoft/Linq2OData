using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Client
{
    public interface IODataDataClient
    {
        IEnumerable<TType> Execute<TType>(IEnumerable<KeyValuePair<string, string>> queryStringParamaters);
        IEnumerable Execute(Type type, IEnumerable<KeyValuePair<string, string>> queryStringParamaters);
    }

    public interface IAsyncODataDataClient
    {
        Task<IEnumerable<TType>> Execute<TType>(IEnumerable<KeyValuePair<string, string>> queryStringParamaters);
        Task<IEnumerable> Execute(Type type, IEnumerable<KeyValuePair<string, string>> queryStringParamaters);
    }
}
