using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Linq2OData.Client.Tests
{

    public class OperationTests
    {
        [Fact]
        public void Verify_Equals()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.stringProperty == x.secondStringProperty).ToList();
            Assert.Equal("stringProperty eq secondStringProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void NotEquals()
        {
            var ctx = new TestContext<Models.TestObject>();
            ctx.Queryable.Where(x => x.stringProperty != x.secondStringProperty).ToList();
            Assert.Equal("stringProperty ne secondStringProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void GreaterThan()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty > x.secondIntProperty).ToList();

            Assert.Equal("intProperty gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void LessThan()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty < x.secondIntProperty).ToList();

            Assert.Equal("intProperty lt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void GreaterThanOrEqual()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty >= x.secondIntProperty).ToList();

            Assert.Equal("intProperty ge secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Fact]
        public void LessThanOrEqual()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty <= x.secondIntProperty).ToList();

            Assert.Equal("intProperty le secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void HasFlag()
        {
            var ctx = new TestContext<Models.TestObject>();
            
            ctx.Queryable.Where(x => x.enumProperty.HasFlag(Models.TestObjectEnum.opt1)).ToList();

            Assert.Equal("enumProperty has Linq2OData.Client.Tests.Models.TestObjectEnum'opt1'", ctx.LastRequest.Parsed.Filter);
        }
        [Fact]
        public void HasFlagProperty()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.enumProperty.HasFlag(x.secondEnumProperty)).ToList();

            Assert.Equal("enumProperty has secondEnumProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void And()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.boolProperty && x.secondBoolProperty).ToList();

            Assert.Equal("boolProperty and secondBoolProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Fact]
        public void AndSingleAmp()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.boolProperty & x.secondBoolProperty).ToList();

            Assert.Equal("boolProperty and secondBoolProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Fact]
        public void Or()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.boolProperty || x.secondBoolProperty).ToList();

            Assert.Equal("boolProperty or secondBoolProperty", ctx.LastRequest.Parsed.Filter);
        }
        [Fact]
        public void Or_single()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.boolProperty | x.secondBoolProperty).ToList();

            Assert.Equal("boolProperty or secondBoolProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Not()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => !x.boolProperty).ToList();

            Assert.Equal("not boolProperty", ctx.LastRequest.Parsed.Filter);
        }


        [Fact]
        public void Add()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty + x.intProperty > x.secondIntProperty).ToList();

            Assert.Equal("(intProperty add intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Subtract()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty - x.intProperty > x.secondIntProperty).ToList();

            Assert.Equal("(intProperty sub intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Multiplication()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty * x.intProperty > x.secondIntProperty).ToList();

            Assert.Equal("(intProperty mul intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Division()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty / x.intProperty > x.secondIntProperty).ToList();

            Assert.Equal("(intProperty div intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Modulo()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty % x.intProperty > x.secondIntProperty).ToList();

            Assert.Equal("(intProperty mod intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }


        [Fact]
        public void Precidence_v1()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => (x.intProperty - x.intProperty) + x.intProperty > x.secondIntProperty).ToList();

            Assert.Equal("((intProperty sub intProperty) add intProperty) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }

        [Fact]
        public void Precidence_v2()
        {
            var ctx = new TestContext<Models.TestObject>();

            ctx.Queryable.Where(x => x.intProperty - (x.intProperty + x.intProperty) > x.secondIntProperty).ToList();

            Assert.Equal("(intProperty sub (intProperty add intProperty)) gt secondIntProperty", ctx.LastRequest.Parsed.Filter);
        }
    }
}
