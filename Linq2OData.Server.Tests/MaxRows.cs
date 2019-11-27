using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Linq2OData.Server.Tests.Models;
using Xunit;

namespace Linq2OData.Server.Tests
{

    public class MaxRows
    {
        IQueryable<Models.TestObject> ctx;
        public MaxRows()
        {
            ctx = Enumerable.Range(0, 99999)
                .Select(x => new TestObject() { intProperty = x }).ToList()
                .AsQueryable();
        }

        [Fact]
        public void ReturnAllRowsIfTopOrMaxNotSet()
        {

            var odata = ctx.Filter(new Dictionary<string, string>
            {

            });


            Assert.Equal(ctx.Count(), odata.Count());

        }
        [Fact]
        public void ReturnTopCountRows()
        {

            var odata = ctx.Filter(new Dictionary<string, string>
            {
                { "$top", "10"}
            });


            Assert.Equal(10, odata.Count());

        }

        [Fact]
        public void ReturnMaxCountRows()
        {

            var odata = ctx.Filter(new Dictionary<string, string>
            {
                //{ "$top", "10"}
            }, new Linq2ODataSettings { MaxRows = 10 });

            Assert.Equal(10, odata.Count());

        }

        [Theory]
        [InlineData(10, 20, 10)]
        [InlineData(20, 10, 10)]
        [InlineData(100, 23, 23)]
        [InlineData(2, 23, 2)]
        public void ReturnLowestMaxOrTop(int max, int top, int expected)
        {
            var odata = ctx.Filter(new Dictionary<string, string>
            {
                { "$top", top.ToString()}
            }, new Linq2ODataSettings { MaxRows = max });

            Assert.Equal(expected, odata.Count());
        }
    }
}
