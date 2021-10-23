using System;
using System.ComponentModel;

namespace DvlDevTools.Http.Attributes
{
	[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
	public class HeaderDisplayName : DisplayNameAttribute
	{
		public HeaderDisplayName(string displayName) : base(displayName)
		{
		}
	}
}
