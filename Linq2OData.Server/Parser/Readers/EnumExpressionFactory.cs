// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExpressionFactory.cs" company="Reimers.dk">
//   Copyright © Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the EnumExpressionFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2OData.Server.Parser.Readers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text.RegularExpressions;

    internal class EnumExpressionFactory : IValueExpressionFactory
    {
        private static readonly Regex EnumRegex = new Regex("^(.+)'(.+)'$", RegexOptions.Compiled);
        private static readonly ConcurrentDictionary<string, Type> KnownTypes = new ConcurrentDictionary<string, Type>();

        public bool Handles(Type type)
        {
#if !NETFX_CORE
            return type.IsEnum;
#else
			return type.GetTypeInfo().IsEnum;
#endif
        }

        public ConstantExpression Convert(string token)
        {
            var match = EnumRegex.Match(token);
            if (match.Success && TryLoadType(match.Groups[1].Value, out var type))
            {
                var value = match.Groups[2].Value;

                return Expression.Constant((int)Enum.Parse(type, value));
            }
            int val;
            if (int.TryParse(token, out val))
            {
                return Expression.Constant(val);
            }
            throw new FormatException("Could not read " + token + " as Enum.");
        }

        private bool TryLoadType(string arg, out Type type)
        {
            if (KnownTypes.TryGetValue(arg, out type))
            {
                return true;
            }

            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a =>
                    {
                        try
                        {
                            return a.GetTypes();
                        }
                        catch (ReflectionTypeLoadException ex)
                        {
                            return ex.Types.Where(x => x != null);
                        }
                    }).ToArray();


            type = types.FirstOrDefault(t => t.FullName == arg);
            type = KnownTypes.GetOrAdd(arg, type);
            return type != null;
        }
    }
}