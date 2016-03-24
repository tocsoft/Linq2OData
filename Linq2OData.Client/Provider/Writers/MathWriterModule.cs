using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace Linq2OData.Client.Provider.Writers
{
    internal static class MathWriterModule
    {
        internal static void RegisterWriters(ODataExpressionConverterSettings settings)
        {
            settings.RegisterMethod(typeof(Math), nameof(Math.Floor));
            settings.RegisterMethod(typeof(Math), nameof(Math.Ceiling));
            settings.RegisterMethod(typeof(Math), nameof(Math.Round));
        }
    }
}