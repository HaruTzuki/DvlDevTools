using DvlDevTools.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Core.PythonElements
{
    public sealed class Variable : PythonElement
    {
        public string Name { get; init; }
        public object Value { get; init; }

		public override string ToString()
		{
			var valueType = Value.GetType();

			return $"{Name} = {PrintValue(valueType, Value)}";
		}

		private static string PrintValue(Type valueType, object value)
		{
			if(valueType.IsIn(typeof(int),typeof(long), typeof(short), typeof(sbyte), typeof(uint), typeof(ulong), typeof(ushort), typeof(byte), typeof(float), typeof(double), typeof(decimal)))
			{
				return $"{value}";
			}
			else
			{
				if(value.ToString().StartsWith("[") && value.ToString().EndsWith("]"))
				{
					return $"{value}";
				}

				return $"'{value}'";
			}
		}
	}
}
