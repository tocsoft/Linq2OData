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
    public class SimpleTests
    {
        [Test]
        public void GetList()
        {
            var client = new Mock<IODataDataClient>();
            client.Setup(x => x.Execute<Models.TestObject>(It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
                .Callback<IEnumerable<KeyValuePair<string, string>>>(x =>
                {
                    Assert.IsTrue(x.Any(y => y.Key == "$filter"), "No filters provided");
                })
                .Returns(Enumerable.Empty<Models.TestObject>());


            client.Setup(x => x.Execute(It.IsAny<Type>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>()))
                .Callback<Type, IEnumerable<KeyValuePair<string, string>>>((t, qs) =>
                {
                    Assert.IsTrue(qs.Any(y => y.Key == "$filter"), "No filters provided");
                })
                .Returns(new object[0]);

            var queryable = new Linq2OData.Client.ODataQueryable<Models.TestObject>(client.Object);

            var list = queryable.Where(x => true == true).ToList();
        }
    }
}
