using DvlDevTools.Http.Enumeration;
using DvlDevTools.Http.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DvlDevTools.Http
{
	public class DvlDevHttpClient
	{
		public string BaseAddress { get; set; }
		public DvlDevHttpContent Content { get; set; }

		private readonly HttpClient _httpClient;

		public DvlDevHttpClient()
		{
			_httpClient = new HttpClient();

		}

		public DvlDevHttpClient(HttpMessageHandler httpMessageHandler)
		{
			_httpClient = new HttpClient(httpMessageHandler);
		}

		public async Task<DvlDevHttpResponse> DoRequest(string requestUrl, RequestType requestType)
		{
			return await DoRequest(requestUrl, requestType, Content);
		}

		public async Task<DvlDevHttpResponse> DoRequest(string requestUrl, RequestType requestType, DvlDevHttpContent content)
		{
			return requestType switch
			{
				RequestType.GET => await HttpGet(requestUrl),
				RequestType.POST => await HttpPost(requestUrl, content),
				RequestType.PUT => await HttpPut(requestUrl, content),
				RequestType.DELETE => await HttpDelete(requestUrl),
				RequestType.PATCH => await HttpPatch(requestUrl, content),
				_ => await new Task<DvlDevHttpResponse>(() => new DvlDevHttpResponse()
					{ HttpStatusCode = HttpStatusCode.BadRequest
						, ResponseMessage = "Method Type Does Not Exist"
						, HttpResponseHeaders = null
					})
			};
		}

		#region HeaderSection
		public void ClearHeaders()
		{
			_httpClient.DefaultRequestHeaders.Clear();
		}

		public void AddAcceptTypeHeader(AcceptType acceptType)
		{
			AddHeader("Accept", acceptType.GetDisplayName());
		}

		public void AddAcceptTypeHeader(string acceptType)
		{
			AddHeader("Accept", acceptType);
		}

		public void AddHeader(string key, string value)
		{
			_httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, value);
		}

		public IEnumerable<KeyValuePair<string, string>> GetHeaders()
		{
			foreach (var (key, value) in _httpClient.DefaultRequestHeaders)
			{
				yield return new KeyValuePair<string, string>(key, string.Join(",", value));
			}
		}
		#endregion

		#region Request Method Section
		private async Task<DvlDevHttpResponse> HttpGet(string requestUrl)
		{
			if (!string.IsNullOrEmpty(BaseAddress))
			{
				_httpClient.BaseAddress = new Uri(BaseAddress);
			}
			var responseMessage = await _httpClient.GetAsync(requestUrl);
			return new DvlDevHttpResponse()
			{
				HttpStatusCode = responseMessage.StatusCode,
				ResponseMessage = await responseMessage.Content.ReadAsStringAsync(),
				HttpResponseHeaders = responseMessage.Headers
			};
		}
		private async Task<DvlDevHttpResponse> HttpPost(string requestUrl, DvlDevHttpContent content)
		{
			if (content == null)
			{
				throw new HttpRequestException($"The content is null. This action not permitted.", null,
					HttpStatusCode.BadRequest);
			}

			if (!string.IsNullOrEmpty(BaseAddress))
			{
				_httpClient.BaseAddress = new Uri(BaseAddress);
			}

			var responseMessage = await _httpClient.PostAsync(requestUrl, content);
			return new DvlDevHttpResponse()
				{
					HttpStatusCode = responseMessage.StatusCode,
					ResponseMessage = await responseMessage.Content.ReadAsStringAsync(),
					HttpResponseHeaders = responseMessage.Headers
				};
		}
		private async Task<DvlDevHttpResponse> HttpPut(string requestUrl, DvlDevHttpContent content)
		{
			if (content == null)
			{
				throw new HttpRequestException($"The content is null. This action not permitted.", null,
					HttpStatusCode.BadRequest);
			}

			if (!string.IsNullOrEmpty(BaseAddress))
			{
				_httpClient.BaseAddress = new Uri(BaseAddress);
			}

			var responseMessage = await _httpClient.PutAsync(requestUrl, content);
			return new DvlDevHttpResponse()
			{
				HttpStatusCode = responseMessage.StatusCode,
				ResponseMessage = await responseMessage.Content.ReadAsStringAsync(),
				HttpResponseHeaders = responseMessage.Headers
			};
		}
		private async Task<DvlDevHttpResponse> HttpDelete(string requestUrl)
		{
			if (!string.IsNullOrEmpty(BaseAddress))
			{
				_httpClient.BaseAddress = new Uri(BaseAddress);
			}

			var responseMessage = await _httpClient.DeleteAsync(requestUrl);
			return new DvlDevHttpResponse()
			{
				HttpStatusCode = responseMessage.StatusCode,
				ResponseMessage = await responseMessage.Content.ReadAsStringAsync(),
				HttpResponseHeaders = responseMessage.Headers
			};
		}

		private async Task<DvlDevHttpResponse> HttpPatch(string requestUrl, DvlDevHttpContent content)
		{
			if (content == null)
			{
				throw new HttpRequestException($"The content is null. This action not permitted.", null,
					HttpStatusCode.BadRequest);
			}

			if (!string.IsNullOrEmpty(BaseAddress))
			{
				_httpClient.BaseAddress = new Uri(BaseAddress);
			}

			var responseMessage = await _httpClient.PatchAsync(requestUrl, content);

			return new DvlDevHttpResponse()
			{
				HttpStatusCode = responseMessage.StatusCode,
				ResponseMessage = await responseMessage.Content.ReadAsStringAsync(),
				HttpResponseHeaders = responseMessage.Headers
			};
		}
		#endregion
	}
}
