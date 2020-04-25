using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq2OData.Client.Tests.Models;
using Moq;
using Xunit;

namespace Linq2OData.Client.Tests
{

    public class ExtensionTests
    {
        [Fact]
        public void GetQueryStringArgumentsForODataQueryable()
        {
            var ctx = new TestContext<Models.TestObject>();
            var args = ctx.Queryable.Where(x => x.stringProperty == "string").AsODataQueryStringArguments();
            var filter = Assert.Single(args, x => x.Key == "$filter");
            Assert.Equal("stringProperty eq 'string'", filter.Value);
        }

        [Fact]
        public void GetQueryStringArgumentsForIEnumerable()
        {
            var args = Enumerable.Empty<Models.TestObject>()
                .AsQueryable()
                .Where(x => x.stringProperty == "string")
                .AsODataQueryStringArguments();

            var filter = Assert.Single(args, x => x.Key == "$filter");
            Assert.Equal("stringProperty eq 'string'", filter.Value);
        }
    }
}
