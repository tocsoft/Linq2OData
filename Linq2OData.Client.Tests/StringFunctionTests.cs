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
    public class StringFunctionTests
    {

        [Test]
        public void contains()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.Contains("big")).ToList();

            Assert.AreEqual("contains(stringProperty, 'big')", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void endsWtih()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.EndsWith("big")).ToList();

            Assert.AreEqual("endswith(stringProperty, 'big')", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void startswith()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.StartsWith("big")).ToList();

            Assert.AreEqual("startswith(stringProperty, 'big')", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void length()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.Length == 1).ToList();

            Assert.AreEqual("length(stringProperty) eq 1", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void indexof()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.IndexOf("test") == 1).ToList();

            Assert.AreEqual("indexof(stringProperty, 'test') eq 1", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void toLower()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.ToLower() == "").ToList();

            Assert.AreEqual("tolower(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void ToLowerInvariant()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.ToLowerInvariant() == "").ToList();

            Assert.AreEqual("tolower(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }


        [Test]
        public void ToUpper()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.ToUpper() == "").ToList();

            Assert.AreEqual("toupper(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void ToUpperInvariant()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.ToUpperInvariant() == "").ToList();

            Assert.AreEqual("toupper(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Trim()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.Trim() == "").ToList();

            Assert.AreEqual("trim(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        [Ignore("come back to figuring out how we'll support concat")]
        public void concat()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty + "test" == "propTest").ToList();

            Assert.AreEqual("concat(stringProperty, 'test') eq 'propTest'", ctx.LastRequest.Parsed.Filter);
        }

    }
}
