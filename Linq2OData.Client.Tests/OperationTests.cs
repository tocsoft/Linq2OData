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
    public class OperationTests
    {
        [Test]
        public void Equals()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.stringProperty == x.secondStringProperty).ToList();
            Assert.AreEqual("stringProperty eq secondStringProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void NotEquals()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.stringProperty != x.secondStringProperty).ToList();
            Assert.AreEqual("stringProperty ne secondStringProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void GreaterThan()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty > x.secondIntProperty).ToList();

            Assert.AreEqual("intProperty gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void LessThan()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty < x.secondIntProperty).ToList();

            Assert.AreEqual("intProperty lt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void GreaterThanOrEqual()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty >= x.secondIntProperty).ToList();

            Assert.AreEqual("intProperty ge secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Test]
        public void LessThanOrEqual()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty <= x.secondIntProperty).ToList();

            Assert.AreEqual("intProperty le secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void HasFlag()
        {
            var ctx = new TestContext<Models.TestObject>();
            
            ctx.Queryable.Where(x => x.enumProperty.HasFlag(Models.TestObjectEnum.opt1)).ToList();

            Assert.AreEqual("enumProperty has Linq2OData.Client.Tests.Models.TestObjectEnum'opt1'", ctx.LastRequest.Parsed.Filter);
        }
        [Test]
        public void HasFlagProperty()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.enumProperty.HasFlag(x.secondEnumProperty)).ToList();

            Assert.AreEqual("enumProperty has secondEnumProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void And()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.boolProperty && x.secondBoolProperty).ToList();

            Assert.AreEqual("boolProperty and secondBoolProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Test]
        public void AndSingleAmp()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.boolProperty & x.secondBoolProperty).ToList();

            Assert.AreEqual("boolProperty and secondBoolProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Test]
        public void Or()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.boolProperty || x.secondBoolProperty).ToList();

            Assert.AreEqual("boolProperty or secondBoolProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Test]
        public void Or_single()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.boolProperty | x.secondBoolProperty).ToList();

            Assert.AreEqual("boolProperty or secondBoolProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Not()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => !x.boolProperty).ToList();

            Assert.AreEqual("not boolProperty", ctx.LastRequest.Parsed.Filter);
        }


        [Test]
        public void Add()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty + x.intProperty > x.secondIntProperty).ToList();

            Assert.AreEqual("(intProperty add intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Subtract()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty - x.intProperty > x.secondIntProperty).ToList();

            Assert.AreEqual("(intProperty sub intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Multiplication()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty * x.intProperty > x.secondIntProperty).ToList();

            Assert.AreEqual("(intProperty mul intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Division()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty / x.intProperty > x.secondIntProperty).ToList();

            Assert.AreEqual("(intProperty div intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Modulo()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty % x.intProperty > x.secondIntProperty).ToList();

            Assert.AreEqual("(intProperty mod intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }


        [Test]
        public void Precidence_v1()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => (x.intProperty - x.intProperty) + x.intProperty > x.secondIntProperty).ToList();

            Assert.AreEqual("((intProperty sub intProperty) add intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Test]
        public void Precidence_v2()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty - (x.intProperty + x.intProperty) > x.secondIntProperty).ToList();

            Assert.AreEqual("(intProperty sub (intProperty add intProperty)) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }
    }
}
