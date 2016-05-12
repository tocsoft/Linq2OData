// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterParser.cs" company="Reimers.dk">
//   Copyright © Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the default implementation of a parameter parser.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2OData.Server.Parser
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Diagnostics.Contracts;
	using System.Linq;
	using Linq2OData.Server.Parser.Readers;

	/// <summary>
	/// Defines the default implementation of a parameter parser.
	/// </summary>
	/// <typeparam name="T">The <see cref="Type"/> of item to create parser for.</typeparam>
	public class ParameterParser<T> : IParameterParser<T>
	{
		private readonly IFilterExpressionFactory _filterExpressionFactory;
		private readonly ISelectExpressionFactory<T> _selectExpressionFactory;
        private readonly Linq2ODataSettings _settings;
        private readonly ISortExpressionFactory _sortExpressionFactory;

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterParser{T}"/> class.
		/// </summary>
		public ParameterParser(Linq2ODataSettings settings)
			: this(settings, new MemberNameResolver())
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterParser{T}"/> class.
		/// </summary>
		/// <param name="memberNameResolver">The <see cref="IMemberNameResolver"/> to use for name resolution.</param>
		public ParameterParser(Linq2ODataSettings settings, IMemberNameResolver memberNameResolver)
			: this(settings, new FilterExpressionFactory(memberNameResolver, Enumerable.Empty<IValueExpressionFactory>()), new SortExpressionFactory(memberNameResolver), new SelectExpressionFactory<T>(memberNameResolver, new RuntimeTypeProvider(memberNameResolver)))
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterParser{T}"/> class.
		/// </summary>
		/// <param name="memberNameResolver">The <see cref="IMemberNameResolver"/> to use for name resolution.</param>
		/// <param name="valueExpressionFactories">The custom <see cref="IValueExpressionFactory"/> to use for value conversion.</param>
		public ParameterParser(Linq2ODataSettings settings, IMemberNameResolver memberNameResolver, IEnumerable<IValueExpressionFactory> valueExpressionFactories)
			: this(settings, new FilterExpressionFactory(memberNameResolver, valueExpressionFactories), new SortExpressionFactory(memberNameResolver), new SelectExpressionFactory<T>(memberNameResolver, new RuntimeTypeProvider(memberNameResolver)))
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParameterParser{T}"/> class.
		/// </summary>
		/// <param name="filterExpressionFactory">The <see cref="IFilterExpressionFactory"/> to use.</param>
		/// <param name="sortExpressionFactory">The <see cref="ISortExpressionFactory"/> to use.</param>
		/// <param name="selectExpressionFactory">The <see cref="ISelectExpressionFactory{T}"/> to use.</param>
		public ParameterParser(
            Linq2ODataSettings settings,
            IFilterExpressionFactory filterExpressionFactory,
			ISortExpressionFactory sortExpressionFactory,
			ISelectExpressionFactory<T> selectExpressionFactory)
		{
            _settings = settings;
            _filterExpressionFactory = filterExpressionFactory;
			_sortExpressionFactory = sortExpressionFactory;
			_selectExpressionFactory = selectExpressionFactory;
		}

		/// <summary>
		/// Parses the passes query parameters to a <see cref="ModelFilter{T}"/>.
		/// </summary>
		/// <param name="queryParameters"></param>
		/// <returns></returns>
		public IModelFilter<T> Parse(IEnumerable<KeyValuePair<string, string>> queryParameters)
		{
			var orderbyField = queryParameters.GetValue(StringConstants.OrderByParameter).FirstOrDefault();
			var selects = queryParameters.GetValue(StringConstants.SelectParameter).FirstOrDefault();
			var filter = queryParameters.GetValue(StringConstants.FilterParameter).FirstOrDefault();
			var skip = queryParameters.GetValue(StringConstants.SkipParameter).FirstOrDefault();
			var top = queryParameters.GetValue(StringConstants.TopParameter).FirstOrDefault();

			var filterExpression = _filterExpressionFactory.Create<T>(filter);
			var sortDescriptions = _sortExpressionFactory.Create<T>(orderbyField);
			var selectFunction = _selectExpressionFactory.Create(selects);

			var modelFilter = new ModelFilter<T>(
                _settings,
				filterExpression,
				selectFunction,
				sortDescriptions,
				string.IsNullOrWhiteSpace(skip) ? -1 : Convert.ToInt32(skip),
				string.IsNullOrWhiteSpace(top) ? -1 : Convert.ToInt32(top));
			return modelFilter;
		}

	
	}
}