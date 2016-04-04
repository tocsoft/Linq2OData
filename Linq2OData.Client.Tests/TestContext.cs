using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Linq2OData.Client.Tests
{
    public class TestContext<TType>
    {
        public Request LastRequest = null;
        public List<Request> AllRequests = new List<Request>();

        public IEnumerable<object> Result = Enumerable.Empty<object>();

        public TestContext()
        {
            var client = new Mock<IODataDataClient>();

            client.Setup(x => x.Execute<TType>(It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
                .Returns<IEnumerable<KeyValuePair<string, string>>>(qs =>
                {
                    var req = new Request
                    {
                        QueryParts = qs,
                        Type = typeof(TType)
                    };
                    LastRequest = req;
                    AllRequests.Add(req);

                    return Result.Where(x => typeof(TType).IsAssignableFrom(x.GetType())).Select(x => (TType)x);
                });

            client.Setup(x => x.Execute(It.IsAny<Type>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
                .Returns<Type, IEnumerable<KeyValuePair<string, string>>>((t, qs) =>
                {
                    var req = new Request
                    {
                        QueryParts = qs,
                        Type = t
                    };
                    LastRequest = req;
                    AllRequests.Add(req);

                    return Result.Where(x => t.IsAssignableFrom(x.GetType()));
                });

            Queryable = new Linq2OData.Client.ODataQueryable<TType>(client.Object);
        }


        public IQueryable<TType> Queryable
        {
            get; private set;
        }

        public class Request
        {
            public Type Type { get; set; }
            public IEnumerable<KeyValuePair<string, string>> QueryParts { get; set; }

            RequestParsed _parsed;
            public RequestParsed Parsed
            {
                get
                {
                    return _parsed = _parsed ?? (_parsed = new RequestParsed(QueryParts));
                }
            }
        }
        public class RequestParsed
        {
            public RequestParsed(IEnumerable<KeyValuePair<string, string>> parts)
            {
                Filter = parts.Where(y => y.Key == "$filter").Select(x => x.Value).SingleOrDefault();
                OrderBy = parts.Where(y => y.Key == "$orderby").Select(x => x.Value).SingleOrDefault();

            }

            public string Filter { get; private set; }
            public string OrderBy { get; private set; }
        }
    }
}
