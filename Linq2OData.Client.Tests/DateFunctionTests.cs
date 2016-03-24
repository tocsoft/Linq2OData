using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Linq2OData.Client.Tests
{
    [TestFixture]
    public class DateFunctionTests
    {

        [Test]
        public void year()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Year == 0).ToList();

            Assert.AreEqual("year(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Month()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Month == 0).ToList();

            Assert.AreEqual("month(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void day()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Day == 0).ToList();

            Assert.AreEqual("day(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void hour()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Hour == 0).ToList();

            Assert.AreEqual("hour(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void minute()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Minute == 0).ToList();

            Assert.AreEqual("minute(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Second()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Second == 0).ToList();

            Assert.AreEqual("second(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        [Ignore("no clean standard way to express getting the fractional seconds, maybe add some helper methods?")]
        public void fractionalseconds()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Second == 0).ToList();

            Assert.AreEqual("fractionalseconds(dateProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void date()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.dateProperty.Date == x.dateProperty).ToList();

            Assert.AreEqual("date(dateProperty) eq dateProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Now()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => DateTime.Now == x.dateProperty).ToList();

            Assert.AreEqual("now() eq dateProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Test]
        public void MinValue()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => DateTime.MinValue == x.dateProperty).ToList();

            Assert.AreEqual("mindatetime() eq dateProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Test]
        public void MaxValue()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => DateTime.MaxValue == x.dateProperty).ToList();

            Assert.AreEqual("maxdatetime() eq dateProperty", ctx.LastRequest.Parsed.Filter);
        }
    }
}
