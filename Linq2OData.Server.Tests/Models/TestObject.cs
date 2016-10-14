using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2OData.Server.Tests.Models
{
    class TestObject
    {
        internal TimeSpan timeSpanProperty;

        public string stringProperty { get; set; }
        public string secondStringProperty { get; set; }
        public Guid guidProperty { get; set; }
        public Guid secondGuidProperty { get; set; }
        public Guid? guidNullProperty { get; set; }

        public int intProperty { get; set; }
        public int secondIntProperty { get; set; }


        public float floatProperty { get; set; }
        public float secondFloatProperty { get; set; }

        public bool boolProperty { get; set; }
        public bool secondBoolProperty { get; set; }

        public DateTime dateProperty { get; set; }
        public DateTimeOffset dateOffsetProperty { get; set; }

        public TestObjectEnum enumProperty { get; set; }
        public TestObjectEnum secondEnumProperty { get; set; }

    }
    [Flags]
    public enum TestObjectEnum
    {
        opt1 = 1,
        opt2 = 2,
        opt3 = 4
    }
}
