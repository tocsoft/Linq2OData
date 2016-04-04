using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Linq2OData.Client.Tests
{
    [TestFixture]
    public class OrderedQueryable
    {
        [Test]
        public void OrdererdResults()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => Math.Round(x.floatProperty) == 0).OrderByDescending(x=>x.floatProperty).ToList();

            Assert.AreEqual("round(floatProperty) eq 0", ctx.LastRequest.Parsed.Filter);
            Assert.AreEqual("floatProperty desc", ctx.LastRequest.Parsed.OrderBy);
        }
    }
}
