using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Linq2OData.Client.Tests
{

    public class DateFunctionTests
    {

        [Fact]
        public void year()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Year == 0).ToList();

            Assert.Equal("year(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Month()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Month == 0).ToList();

            Assert.Equal("month(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void day()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Day == 0).ToList();

            Assert.Equal("day(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void hour()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Hour == 0).ToList();

            Assert.Equal("hour(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void minute()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Minute == 0).ToList();

            Assert.Equal("minute(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Second()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Second == 0).ToList();

            Assert.Equal("second(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Fact(Skip = "no clean standard way to express getting the fractional seconds, maybe add some helper methods?")]
        public void fractionalseconds()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Second == 0).ToList();

            Assert.Equal("fractionalseconds(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void date()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Date == x.dateProperty).ToList();

            Assert.Equal("date(dateProperty) eq dateProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Now()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => DateTime.Now == x.dateProperty).ToList();

            Assert.Equal("now() eq dateProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Fact]
        public void MinValue()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => DateTime.MinValue == x.dateProperty).ToList();

            Assert.Equal("mindatetime() eq dateProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Fact]
        public void MaxValue()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => DateTime.MaxValue == x.dateProperty).ToList();

            Assert.Equal("maxdatetime() eq dateProperty", ctx.LastRequest.Parsed.Filter);
        }
    }
}
