using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Core.PythonElements
{
    public class PrintLine : PythonElement
	{
		public object Value { get; init; }

		public PrintLine()
		{

		}

		public PrintLine(object value) => Value = value;


		public override string ToString()
		{
			return $"print({Value}, end='\\n')";
		}
	}
}
