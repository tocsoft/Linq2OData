// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenSet.cs" company="Reimers.dk">
//   Copyright © Reimers.dk 2014
//   This source is subject to the Microsoft Public License (Ms-PL).
//   Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
//   All other rights reserved.
// </copyright>
// <summary>
//   Defines the TokenSet type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Linq2OData.Server.Parser
{
	using System;

	internal class TokenSet
	{
		private string _left;
		private string _operation;
		private string _right;

		public TokenSet()
		{
			_left = string.Empty;
			_right = string.Empty;
			_operation = string.Empty;
		}

		public string Left
		{
			get
			{
				return _left;
			}

			set
			{
				_left = value;
			}
		}

		public string Operation
		{
			get
			{
				return _operation;
			}

            set { 
				_operation = value;
			}
		}

		public string Right
		{
			get
			{
				return _right;
			}

			set
			{
				_right = value;
			}
		}

		public override string ToString()
		{
			return string.Format("{0} {1} {2}", Left, Operation, Right);
		}
        
	}
}