// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IParameterParser.cs" company="Reimers.dk">
//   Copyright © Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the public interface for a parameter parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2OData.Server.Parser
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// Defines the public interface for a parameter parser.
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of object to parse parameters for.</typeparam>
	public interface IParameterParser<T>
	{
		/// <summary>
		/// Parses the passes parameters into a <see cref="ModelFilter{T}"/>.
		/// </summary>
		/// <param name="queryParameters">The parameters to parse.</param>
		/// <returns>A <see cref="ModelFilter{T}"/> representing the restrictions in the parameters.</returns>
		IModelFilter<T> Parse(IEnumerable<KeyValuePair<string, string>> queryParameters);
	}

}