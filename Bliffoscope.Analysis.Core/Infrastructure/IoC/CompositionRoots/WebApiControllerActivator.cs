using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Bliffoscope.Analysis.Core.Infrastructure.Diagnostics;
using Castle.MicroKernel.Lifestyle;
using Castle.Windsor;

namespace Bliffoscope.Analysis.Core.Infrastructure.IoC.CompositionRoots
{
	public class WebApiControllerActivator : IHttpControllerActivator
	{
		private IWindsorContainer container;

		public WebApiControllerActivator(IWindsorContainer container)
		{
			this.container = container;
		}

		public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
		{
			var scope = this.container.BeginScope();
			var controller = this.container.Resolve(controllerType, new { requestInfo = new DefaultRequestInfo(request) });
			request.RegisterForDispose(new Release(() =>
			{
				scope.Dispose();
				this.container.Release(controller);
			}));

			return controller as IHttpController;
		}

		private class Release : IDisposable
		{
			private Action release;

			public Release(Action release)
			{
				this.release = release;
			}

			public void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);

			}

			protected virtual void Dispose(bool disposing)
			{
				if(disposing)
				{
					if(this.release != null)
						this.release();
					this.release = null;
				}
			}
		}
	}
}