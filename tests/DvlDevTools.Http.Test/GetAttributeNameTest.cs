using System.Diagnostics;
using System.Linq;
using DvlDevTools.Http.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DvlDevTools.Http.Test
{
	[TestClass]
	public class GetAttributeNameTest
	{
		[TestMethod]
		public void CheckIfGettingContentTypeAttributeDisplayNameWorks()
		{
			var httpClient = new DvlDevHttpClient();
			httpClient.AddAcceptTypeHeader(AcceptType.ApplicationJson);
			httpClient.AddAcceptTypeHeader(AcceptType.ApplicationGZip);
			httpClient.AddAcceptTypeHeader(AcceptType.ApplicationFontWoff);
			httpClient.AddAcceptTypeHeader(AcceptType.TextCsv);
			httpClient.AddAcceptTypeHeader(AcceptType.TextCsv);
			httpClient.AddAcceptTypeHeader(AcceptType.ApplicationOgg);
			httpClient.AddAcceptTypeHeader(AcceptType.ApplicationEcmaScript);
			httpClient.AddHeader("Token", "dsdsddsds");
			

			foreach (var VARIABLE in httpClient.GetHeaders())
			{
				Debug.WriteLine(VARIABLE.Key + " " + VARIABLE.Value);
			}

		}
	}
}
