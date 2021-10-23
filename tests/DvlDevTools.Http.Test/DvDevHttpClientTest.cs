using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DvlDevTools.Http.Enumeration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;

namespace DvlDevTools.Http.Test
{
	[TestClass]
	public class DvDevHttpClientTest
	{
		private MockHttpMessageHandler mockHttp;

		private List<object> _users = new List<object>()
		{
			new {Id = 1, FirstName = "John", LastName = "Doe"},
			new {Id = 2, FirstName = "Bill", LastName = "Gates"},
			new {Id = 3, FirstName = "Satya", LastName = "Nadela"}
		};

		public DvDevHttpClientTest()
		{
			mockHttp = new MockHttpMessageHandler();
			mockHttp.When(HttpMethod.Get, "http://localhost/api/GetUsers/")
				.Respond("application/json", JsonConvert.SerializeObject(_users));
			mockHttp.When(HttpMethod.Post, "http://localhost/api/PostUser")
				.Respond(HttpStatusCode.Created, "application/json", JsonConvert.SerializeObject(_users));
			mockHttp.When(HttpMethod.Put, "http://localhost/api/UpdateUser")
				.Respond(HttpStatusCode.OK, "application/json", JsonConvert.SerializeObject(_users));

		}

		[TestMethod]
		public async Task Should_OK_In_Get_Method()
		{
			var httpClient = new DvlDevHttpClient(mockHttp);
			httpClient.AddAcceptTypeHeader(AcceptType.ApplicationJson);
			var response = await httpClient.DoRequest("http://localhost/api/GetUsers/", RequestType.GET);

			Assert.IsTrue(response.HttpStatusCode == HttpStatusCode.OK, $"Status Message is OK and message is: {response.ResponseMessage}");
		}

		[TestMethod]
		public async Task Should_OK_Or_Created_In_Post_Method()
		{
			var httpClient = new DvlDevHttpClient(mockHttp);
			httpClient.AddAcceptTypeHeader(AcceptType.ApplicationJson);
			var response = await httpClient.DoRequest("http://localhost/api/PostUser", RequestType.POST,
				new DvlDevHttpContent("Hello World", Encoding.Unicode, ContentType.ApplicationJson));

			Assert.IsTrue(response.HttpStatusCode is HttpStatusCode.OK or HttpStatusCode.Created, $"Status Message is OK or Created and message is: {response.ResponseMessage}");
		}

		[TestMethod]
		public async Task Should_OK_In_Put_Method()
		{
			var httpClient = new DvlDevHttpClient(mockHttp);
			httpClient.AddAcceptTypeHeader(AcceptType.ApplicationJson);
			var response = await httpClient.DoRequest("http://localhost/api/UpdateUser", RequestType.PUT,
				new DvlDevHttpContent("Hello World", Encoding.UTF8, ContentType.ApplicationJson));

			Assert.IsTrue(response.HttpStatusCode == HttpStatusCode.OK);
		}
	}
}
