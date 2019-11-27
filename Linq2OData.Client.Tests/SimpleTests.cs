using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Linq2OData.Client.Tests
{

    public class SimpleTests
    {
        [Fact]
        public void GetList()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.ToList();

            Assert.Single(ctx.AllRequests);
            Assert.Empty(ctx.LastRequest.QueryParts);
            Assert.Equal(typeof(Models.TestObject), ctx.LastRequest.Type);
        }

        [Fact]
        public void StringIsNull()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty == null).ToList();

            Assert.Single(ctx.AllRequests);
            Assert.Single(ctx.LastRequest.QueryParts);

            Assert.Equal("stringProperty eq null", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void StringIsNullOrEquals()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty == null || x.stringProperty == "test").ToList();

            Assert.Single(ctx.AllRequests);
            Assert.Single(ctx.LastRequest.QueryParts);

            var filterQuery = ctx.LastRequest.QueryParts.Where(y => y.Key == "$filter").Select(x => Uri.UnescapeDataString(x.Value)).Single();

            Assert.Equal("(stringProperty eq null) or (stringProperty eq 'test')", ctx.LastRequest.Parsed.Filter);
        }
    }
}
