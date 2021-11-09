using System;

namespace DvlDevTools.ProcessRunPython.Helpers.Enumerations.Attributes
{
	public class OperatorSymbolAttribute : Attribute
	{
		public string OperatorSymbol { get; set; }

		public OperatorSymbolAttribute(string operatorSymbol)
		{
			OperatorSymbol = operatorSymbol;
		}
	}
}