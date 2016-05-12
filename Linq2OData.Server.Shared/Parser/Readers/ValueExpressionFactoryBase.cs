// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueExpressionFactoryBase.cs" company="Reimers.dk">
//   Copyright � Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the ValueExpressionFactoryBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2OData.Server.Parser.Readers
{
	using System;
	using System.Linq.Expressions;

	internal abstract class ValueExpressionFactoryBase<T> : IValueExpressionFactory
	{
		public bool Handles(Type type)
		{
#if !NETFX_CORE
			return typeof(T) == type;
#else
			return typeof(T).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
#endif
		}

		public abstract ConstantExpression Convert(string token);
	}
}