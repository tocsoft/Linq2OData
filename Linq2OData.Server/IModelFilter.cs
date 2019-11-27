// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModelFilter.cs" company="Reimers.dk">
//   Copyright © Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the public interface for a model filter.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2OData.Server
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;
	using System.IO;
	using System.Linq;
	using System.Linq.Expressions;
	using Linq2OData.Server.Parser;

	/// <summary>
	/// Defines the public interface for a model filter.
	/// </summary>
	/// <typeparam name="T">The <see cref="Type"/> of item to filter.</typeparam>
	public interface IModelFilter<T>
	{
		/// <summary>
		/// Filters the passed collection with the defined filter.
		/// </summary>
		/// <param name="source">The source items to filter.</param>
		/// <returns>A filtered enumeration and projected of the source items.</returns>
		IQueryable<object> Filter(IEnumerable<T> source);

		/// <summary>
		/// Gets the filter expression.
		/// </summary>
		Expression<Func<T, bool>> FilterExpression { get; }

		/// <summary>
		/// Gets the amount of items to take.
		/// </summary>
		int TakeCount { get; }

		/// <summary>
		/// Gets the amount of items to skip.
		/// </summary>
		int SkipCount { get; }

		/// <summary>
		/// Gets the <see cref="SortDescription{T}"/> for the sequence.
		/// </summary>
		IEnumerable<SortDescription<T>> SortDescriptions { get; }
	}
    
}