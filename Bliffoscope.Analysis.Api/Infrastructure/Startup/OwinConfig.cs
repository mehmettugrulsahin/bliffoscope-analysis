using System;
using Bliffoscope.Analysis.Core.Infrastructure.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataProtection;
using Owin;

namespace Bliffoscope.Analysis.Api.Infrastructure.Startup
{
	public static class OwinConfig
	{
		public const int CookieExpirationMinutes = 30;

		public static void Configure(IAppBuilder app)
		{
			app
				.UseCookieAuthentication(new CookieAuthenticationOptions
				{
					AuthenticationType = AuthenticationTypes.ApplicationCookie,
					TicketDataFormat = new TicketDataFormat(app.CreateDataProtector(new string[] { "Bliffoscope", typeof(OwinConfig).FullName })),
					ExpireTimeSpan = TimeSpan.FromMinutes(CookieExpirationMinutes),
					SlidingExpiration = true
				});
		}
	}
}