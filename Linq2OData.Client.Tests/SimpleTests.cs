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
    public class SimpleTests
    {
        [Test]
        public void GetList()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.ToList();

            Assert.That(ctx.AllRequests, Has.Count.EqualTo(1));
            Assert.That(ctx.LastRequest.QueryParts, Has.Count.EqualTo(0));
            Assert.AreEqual(typeof(Models.TestObject), ctx.LastRequest.Type);
        }

        [Test]
        public void StringIsNull()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty == null).ToList();

            Assert.That(ctx.AllRequests, Has.Count.EqualTo(1));
            Assert.That(ctx.LastRequest.QueryParts, Has.Count.EqualTo(1));

            Assert.AreEqual("stringProperty eq null", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void StringIsNullOrEquals()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty == null || x.stringProperty == "test").ToList();

            Assert.That(ctx.AllRequests, Has.Count.EqualTo(1));
            Assert.That(ctx.LastRequest.QueryParts, Has.Count.EqualTo(1));

            var filterQuery = ctx.LastRequest.QueryParts.Where(y => y.Key == "$filter").Select(x => Uri.UnescapeDataString(x.Value)).Single();

            Assert.AreEqual("(stringProperty eq null) or (stringProperty eq 'test')", ctx.LastRequest.Parsed.Filter);
        }
    }
}
