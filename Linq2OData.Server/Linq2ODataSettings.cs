using System;
using System.Collections.Generic;
using System.Text;

namespace Linq2OData.Server
{
    public class Linq2ODataSettings
    {
        static Linq2ODataSettings _defaults;
        public static Linq2ODataSettings Defaults { get { return _defaults ?? (_defaults = new Linq2ODataSettings()); } set { _defaults = value; } }

        public int? MaxRows { get; set; } = null;
    }
}
