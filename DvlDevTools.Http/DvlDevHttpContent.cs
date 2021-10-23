using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DvlDevTools.Http.Enumeration;
using DvlDevTools.Http.Helper;

namespace DvlDevTools.Http
{
	#nullable enable
	public class DvlDevHttpContent : StringContent
    {
	    public DvlDevHttpContent(string content) : base(content)
	    { }

	    public DvlDevHttpContent(string content, Encoding? encoding) : base(content, encoding)
	    { }

	    public DvlDevHttpContent(string content, Encoding? encoding, ContentType contentType) :base(content, encoding, contentType.GetDisplayName())
	    { }

		public DvlDevHttpContent(string content, Encoding? encoding, string? mediaType) : base(content, encoding, mediaType)
	    { }
    }
}
