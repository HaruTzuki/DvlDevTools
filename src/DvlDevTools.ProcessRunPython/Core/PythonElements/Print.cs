using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Core.PythonElements
{
	public class Print : PythonElement
	{
		public object Value { get; init; }

		public Print()
		{

		}

		public Print(object value) => Value = value;
		

		public override string ToString()
		{
			return $"print({Value})";
		}
	}
}
