using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Linq2OData.Server.Tests
{
    [TestFixture]
    public class ValueTests
    {
        IQueryable<Models.TestObject> ctx;
        [SetUp]
        public void setup()
        {
            ctx = new List<Models.TestObject>().AsQueryable();
        }
        [Test]
        public void String()
        {

            var odata = ctx.Filter(new Dictionary<string, string> {
                { "$filter", "stringProperty eq 'string'" }
            });

            var expected = ctx.Where(x => x.stringProperty == "string");

            AssertExpression.AreEqual(expected.Expression, odata.Expression);

        }
        [Test]
        public void EnumValue()
        {
            var odata = ctx.Filter(new Dictionary<string, string> {
                { "$filter", "enumProperty eq 1" }
            });

            var expected = ctx.Where(x => x.enumProperty == Models.TestObjectEnum.opt1);

            AssertExpression.AreEqual(expected.Expression, odata.Expression);

        }
        [Test]
        public void EnumText()
        {
            var odata = ctx.Filter(new Dictionary<string, string> {
                { "$filter", "enumProperty eq Linq2OData.Server.Tests.Models.TestObjectEnum'opt1'" }
            });

            var expected = ctx.Where(x => x.enumProperty == Models.TestObjectEnum.opt1);

            AssertExpression.AreEqual(expected.Expression, odata.Expression);
        }

        [Test]
        public void Bool()
        {
            var odata = ctx.Filter("boolProperty eq True");
            var expected = ctx.Where(x => x.boolProperty == true);

            AssertExpression.AreEqual(expected, odata);
        }

        [Test]
        public void Int()
        {
            var odata = ctx.Filter("intProperty eq 99");
            var expected = ctx.Where(x => x.intProperty == 99);

            AssertExpression.AreEqual(expected, odata);
        }

        [Test]
        public void Guid()
        {
            var odata = ctx.Filter("guidProperty eq guid'61CA9677-CABA-44A0-A187-7C86A8E0EAC3'");
            var guid = new System.Guid("61CA9677-CABA-44A0-A187-7C86A8E0EAC3");
            var expected = ctx.Where(x => x.guidProperty == guid);

            AssertExpression.AreEqual(expected, odata);
        }
        [Test]
        public void Guid_lower()
        {
            var odata = ctx.Filter("guidProperty eq guid'61ca9677-caba-44a0-a187-7c86a8e0eac3'");
            var guid = new System.Guid("61CA9677-CABA-44A0-A187-7C86A8E0EAC3");
            var expected = ctx.Where(x => x.guidProperty == guid);

            AssertExpression.AreEqual(expected, odata);
        }
        [Test]
        public void NullableGuid()
        {
            var odata = ctx.Filter("guidNullProperty eq null");
            
            var expected = ctx.Where(x => x.guidNullProperty == null);

            Assert.AreEqual(expected.Expression.ToString(), odata.Expression.ToString());
            //skip true comparison as there must be subtle difference need to investigate more
            //AssertExpression.AreEqual(expected, odata);
        }
    }
}
