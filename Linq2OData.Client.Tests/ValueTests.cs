using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq2OData.Client.Tests.Models;
using Moq;
using Xunit;

namespace Linq2OData.Client.Tests
{

    public class ValueTests
    {
        [Fact]
        public void String()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.stringProperty == "string").ToList();
            Assert.Equal("stringProperty eq 'string'", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Int()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.intProperty == 99).ToList();
            Assert.Equal("intProperty eq 99", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void EnumAndEnum()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.enumProperty == TestObjectEnum.opt2).ToList();
            Assert.Equal("enumProperty eq Linq2OData.Client.Tests.Models.TestObjectEnum'opt2'", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Bool()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.boolProperty == true).ToList();
            Assert.Equal("boolProperty eq True", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Guid()
        {
            var ctx = new TestContext<Models.TestObject>();
            var guid = new System.Guid("61CA9677-CABA-44A0-A187-7C86A8E0EAC3");
            ctx.Queryable.Where(x => x.guidProperty == guid).ToList();
            Assert.Equal("guidProperty eq guid'61ca9677-caba-44a0-a187-7c86a8e0eac3'", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Guid_null()
        {
            var ctx = new TestContext<Models.TestObject>();
            Guid? guid = null;
            ctx.Queryable.Where(x => x.guidNullProperty == guid).ToList();
            Assert.Equal("guidNullProperty eq null", ctx.LastRequest.Parsed.Filter);
        }
    }
}
