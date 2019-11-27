using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Linq2OData.Client.Tests
{

    public class StringFunctionTests
    {

        [Fact]
        public void contains()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.Contains("big")).ToList();

            Assert.Equal("contains(stringProperty, 'big')", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void endsWtih()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.EndsWith("big")).ToList();

            Assert.Equal("endswith(stringProperty, 'big')", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void startswith()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.StartsWith("big")).ToList();

            Assert.Equal("startswith(stringProperty, 'big')", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void length()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.Length == 1).ToList();

            Assert.Equal("length(stringProperty) eq 1", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void indexof()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.IndexOf("test") == 1).ToList();

            Assert.Equal("indexof(stringProperty, 'test') eq 1", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void toLower()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.ToLower() == "").ToList();

            Assert.Equal("tolower(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void ToLowerInvariant()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.ToLowerInvariant() == "").ToList();

            Assert.Equal("tolower(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }


        [Fact]
        public void ToUpper()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.ToUpper() == "").ToList();

            Assert.Equal("toupper(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void ToUpperInvariant()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.ToUpperInvariant() == "").ToList();

            Assert.Equal("toupper(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Trim()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty.Trim() == "").ToList();

            Assert.Equal("trim(stringProperty) eq ''", ctx.LastRequest.Parsed.Filter);
        }

        [Fact(Skip = "come back to figuring out how we'll support concat")]
        public void concat()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.stringProperty + "test" == "propTest").ToList();

            Assert.Equal("concat(stringProperty, 'test') eq 'propTest'", ctx.LastRequest.Parsed.Filter);
        }

    }
}
