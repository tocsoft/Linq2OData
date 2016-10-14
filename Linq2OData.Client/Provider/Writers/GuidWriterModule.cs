using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace Linq2OData.Client.Provider.Writers
{
    internal static class GuidWriterModule
    {
        internal static void RegisterWriters(ODataExpressionConverterSettings settings)
        {
            settings.RegisterValueWriter(new GuidValueWriter());
        }
    }
}