using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Linq2OData.Server.Tests
{

    [TestFixture]
    public class StringFunctionTests
    {
        IQueryable<Models.TestObject> ctx;
        [SetUp]
        public void setup()
        {
            ctx = new List<Models.TestObject>().AsQueryable();
        }

        [Test]
        public void contains()
        {
            
            var expected = ctx.Where(x => x.stringProperty.Contains("big"));
            var actual = ctx.Filter("contains(stringProperty, 'big')");
            AssertExpression.AreEqual(expected, actual);
        }

        [Test]
        public void endsWtih()
        {
            var expected = ctx.Where(x => x.stringProperty.EndsWith("big"));
            var actual = ctx.Filter("endswith(stringProperty, 'big')");

            AssertExpression.AreEqual(expected, actual);
        }

        [Test]
        public void startswith()
        {

            var expected = ctx.Where(x => x.stringProperty.StartsWith("big"));
            var actual = ctx.Filter("startswith(stringProperty, 'big')");

            AssertExpression.AreEqual(expected, actual);

        }
        [Test]
        public void length()
        {

            var expected = ctx.Where(x => x.stringProperty.Length == 1);
            var actual = ctx.Filter("length(stringProperty) eq 1");

            AssertExpression.AreEqual(expected, actual);

        }


        [Test]
        public void indexof()
        {

            var expected = ctx.Where(x => x.stringProperty.IndexOf("test") == 1);
            var actual = ctx.Filter("indexof(stringProperty, 'test') eq 1");

            AssertExpression.AreEqual(expected, actual);
        }

        [Test]
        public void ToLowerInvariant()
        {
            var expected = ctx.Where(x => x.stringProperty.ToLowerInvariant() == "");
            var actual = ctx.Filter("tolower(stringProperty) eq ''");

            AssertExpression.AreEqual(expected, actual);
        }
        [Test]
        public void ToUpperInvariant()
        {
            var expected = ctx.Where(x => x.stringProperty.ToUpperInvariant() == "");
            var actual = ctx.Filter("toupper(stringProperty) eq ''");

            AssertExpression.AreEqual(expected, actual);
        }

        [Test]
        public void trim()
        {
            var expected = ctx.Where(x => x.stringProperty.Trim() == "");
            var actual = ctx.Filter("trim(stringProperty) eq ''");

            AssertExpression.AreEqual(expected, actual);
        }

        [Test]
        [Ignore("come back to figuring out how we'll support concat")]
        public void concat()
        {
            var actual = ctx.Filter("concat(stringProperty, 'test') eq 'propTest'");
            var expected = ctx.Where(x => x.stringProperty + "test" == "propTest");
            AssertExpression.AreEqual(expected, actual);
        }
    }
}
