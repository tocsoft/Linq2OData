using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq2OData.Server.Tests.Models;
using NUnit.Framework;

namespace Linq2OData.Server.Tests
{
    [TestFixture]
    public class MaxRows
    {
        IQueryable<Models.TestObject> ctx;
        [SetUp]
        public void setup()
        {
            ctx = Enumerable.Range(0, 99999)
                .Select(x => new TestObject() { intProperty = x }).ToList()
                .AsQueryable();
        }

        [Test]
        public void ReturnAllRowsIfTopOrMaxNotSet()
        {

            var odata = ctx.Filter(new Dictionary<string, string>
            {

            });


            Assert.AreEqual(ctx.Count(), odata.Count());

        }
        [Test]
        public void ReturnTopCountRows()
        {

            var odata = ctx.Filter(new Dictionary<string, string>
            {
                { "$top", "10"}
            });


            Assert.AreEqual(10, odata.Count());

        }

        [Test]
        public void ReturnMaxCountRows()
        {

            var odata = ctx.Filter(new Dictionary<string, string>
            {
                //{ "$top", "10"}
            }, new Linq2ODataSettings { MaxRows = 10 });

            Assert.AreEqual(10, odata.Count());

        }

        [Test]
        [TestCase(10, 20, 10)]
        [TestCase(20, 10, 10)]
        [TestCase(100, 23, 23)]
        [TestCase(2, 23, 2)]
        public void ReturnLowestMaxOrTop(int max, int top, int expected)
        {
            var odata = ctx.Filter(new Dictionary<string, string>
            {
                { "$top", top.ToString()}
            }, new Linq2ODataSettings { MaxRows = max });

            Assert.AreEqual(expected, odata.Count());
        }
    }
}
