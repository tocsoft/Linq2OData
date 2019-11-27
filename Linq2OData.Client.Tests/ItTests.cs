using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Linq2OData.Client.Tests
{

    public class ItTests
    {
        [Fact]
        public void It()
        {
            var ctx = new TestContext<string>();

            ctx.Queryable.Where(x=>x.EndsWith("")).ToList();

            Assert.Equal("endswith($it, '')", ctx.LastRequest.Parsed.Filter);
        }
    }
}
