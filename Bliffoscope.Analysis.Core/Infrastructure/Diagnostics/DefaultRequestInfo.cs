using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http.Controllers;

namespace Bliffoscope.Analysis.Core.Infrastructure.Diagnostics
{
	public class DefaultRequestInfo
	{
		private HttpRequestMessage httpRequestMessage;

		public DefaultRequestInfo(HttpRequestMessage httpRequestMessage)
		{
			this.httpRequestMessage = httpRequestMessage;
		}

		public Uri RequestUri
		{
			get { return this.httpRequestMessage != null ? this.httpRequestMessage.RequestUri : null; }
		}

		public Guid GetCorrelationId()
		{
			return this.httpRequestMessage != null ? this.httpRequestMessage.GetCorrelationId() : Guid.Empty;
		}

		public IEnumerable<KeyValuePair<string, IEnumerable<string>>> Headers
		{
			get { return this.httpRequestMessage != null ? this.httpRequestMessage.Headers : null; }
		}

		public HttpRequestContext GetRequestContext()
		{
			return this.httpRequestMessage != null ? this.httpRequestMessage.GetRequestContext() : null;
		}

		public IPrincipal Principal
		{
			get
			{
				IPrincipal result = null;
				if(this.httpRequestMessage != null)
				{
					var context = this.httpRequestMessage.GetRequestContext();
					if(context != null)
						result = context.Principal;
				}
				return result;
			}
		}
	}
}
