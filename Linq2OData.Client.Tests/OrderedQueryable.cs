using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Linq2OData.Client.Tests
{

    public class OrderedQueryable
    {
        [Fact]
        public void OrdererdResults()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => Math.Round(x.floatProperty) == 0).OrderByDescending(x=>x.floatProperty).ToList();

            Assert.Equal("round(floatProperty) eq 0", ctx.LastRequest.Parsed.Filter);
            Assert.Equal("floatProperty desc", ctx.LastRequest.Parsed.OrderBy);
        }
    }
}
