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
    public class ItTests
    {
        [Test]
        public void It()
        {
            var ctx = new TestContext<string>();

            ctx.Queryable.Where(x=>x.EndsWith("")).ToList();

            Assert.AreEqual("endswith($it, '')", ctx.LastRequest.Parsed.Filter);
        }
    }
}
