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
    public class MathFunctionTests
    {
        [Test]
        public void round()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => Math.Round(x.floatProperty) == 0).ToList();

            Assert.AreEqual("round(floatProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void floor()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => Math.Floor(x.floatProperty) == 0).ToList();

            Assert.AreEqual("floor(floatProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void ceiling()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => Math.Ceiling(x.floatProperty) == 0).ToList();

            Assert.AreEqual("ceiling(floatProperty) eq 0", ctx.LastRequest.Parsed.Filter);
        }
    }
}
