using Ninject.Modules;
using RandomApp.Controller;
using RandomApp.EndPoints;
using RandomApp.Services;

namespace RandomApp
{
	public class RandomAppModules : NinjectModule
	{
		public override void Load()
		{
			Bind<INavigator>().To<Navigator>()
			 .InSingletonScope();

			Bind<IEndPointsManager>().To<EndPointsManager>()
				.InSingletonScope();

			Bind<IAppItemPageController>().To<AppItemPageController>();

			Bind<IRandomFactController>().To<RandomFactController>();

		
			Bind<IRandomFactServicesManagement>().To<RandomFactServicesManagement>();
			Bind<IEndPoint>().To<EndPoint>();
		}
	}
}
