using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Linq2OData.Client.Tests
{

    public class MathFunctionTests
    {
        [Fact]
        public void round()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => Math.Round(x.floatProperty) == 0).ToList();

            Assert.Equal("round(floatProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void floor()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => Math.Floor(x.floatProperty) == 0).ToList();

            Assert.Equal("floor(floatProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void ceiling()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => Math.Ceiling(x.floatProperty) == 0).ToList();

            Assert.Equal("ceiling(floatProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }
    }
}
