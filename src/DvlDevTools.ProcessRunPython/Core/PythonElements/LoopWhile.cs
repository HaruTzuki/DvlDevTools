using DvlDevTools.ProcessRunPython.Helpers.Enumerations;
using DvlDevTools.ProcessRunPython.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Core.PythonElements
{
    public class LoopWhile : PythonElement
    {
        public string Left { get; init; }
        public string Right { get; init; }
        public ComparisonOperators ComparisonOperator { get; init; }
		public PythonElement[] PythonElements { get; init; }

		public LoopWhile()
		{

		}

		public LoopWhile(string left, string right, ComparisonOperators comparisonOperator, PythonElement[] pythonElements)
		{
			Left = left;
			Right = right;
			ComparisonOperator = comparisonOperator;
			PythonElements = pythonElements;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();

			stringBuilder.AppendLine($"while {Left} {ComparisonOperator.GetOperatorSymbol()} {Right}:");

			foreach(var pythonElement in PythonElements)
			{
				stringBuilder.AppendLine($"\t{pythonElement.ToString()}");
			}

			return stringBuilder.ToString();
		}
	}
}
