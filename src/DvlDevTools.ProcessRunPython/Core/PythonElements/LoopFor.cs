using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.ProcessRunPython.Core.PythonElements
{
	public class LoopFor : PythonElement
	{
		public string ArrayVariableName { get; init; }
		public string IteratorVariableName { get; init; }
		public PythonElement Result { get; init; }

		public LoopFor()
		{

		}

		public LoopFor(string arrayVariableName, string iteratorVariableName, PythonElement result)
		{
			ArrayVariableName = arrayVariableName;
			IteratorVariableName = iteratorVariableName;
			Result = result;
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder();

			stringBuilder.AppendLine($"for {IteratorVariableName} in {ArrayVariableName}:");
			stringBuilder.AppendLine($"\t{Result.ToString()}");

			return stringBuilder.ToString();
		}
	}
}
