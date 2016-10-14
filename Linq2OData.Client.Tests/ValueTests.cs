using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq2OData.Client.Tests.Models;
using Moq;
using NUnit.Framework;

namespace Linq2OData.Client.Tests
{
    [TestFixture]
    public class ValueTests
    {
        [Test]
        public void String()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.stringProperty == "string").ToList();
            Assert.AreEqual("stringProperty eq 'string'", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Int()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.intProperty == 99).ToList();
            Assert.AreEqual("intProperty eq 99", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void EnumAndEnum()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.enumProperty == TestObjectEnum.opt2).ToList();
            Assert.AreEqual("enumProperty eq Linq2OData.Client.Tests.Models.TestObjectEnum'opt2'", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Bool()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.boolProperty == true).ToList();
            Assert.AreEqual("boolProperty eq True", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Guid()
        {
            var ctx = new TestContext<Models.TestObject>();
            var guid = new System.Guid("61CA9677-CABA-44A0-A187-7C86A8E0EAC3");
            ctx.Queryable.Where(x => x.guidProperty == guid).ToList();
            Assert.AreEqual("guidProperty eq guid'61ca9677-caba-44a0-a187-7c86a8e0eac3'", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Guid_null()
        {
            var ctx = new TestContext<Models.TestObject>();
            Guid? guid = null;
            ctx.Queryable.Where(x => x.guidNullProperty == guid).ToList();
            Assert.AreEqual("guidNullProperty eq null", ctx.LastRequest.Parsed.Filter);
        }
    }
}
