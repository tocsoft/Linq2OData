using System;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace Linq2OData.Client.Provider.Writers
{
    internal static class EnumWriterModule
    {
        internal static void RegisterWriters(ODataExpressionConverterSettings settings)
        {
            settings.RegisterMethod(typeof(Enum), nameof(Enum.HasFlag), (opj, args) => $"{opj} has {args.Single()}");

            settings.RegisterValueWriter(new EnumValueWriter());
        }
    }
}