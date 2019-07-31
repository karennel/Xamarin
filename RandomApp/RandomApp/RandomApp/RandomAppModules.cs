using Ninject.Modules;
using RandomApp.Controller;

namespace RandomApp
{
	public class RandomAppModules : NinjectModule
	{
		public override void Load()
		{
			Bind<INavigator>().To<Navigator>()
			 .InSingletonScope();

			Bind<IAppItemPageController>().To<AppItemPageController>();

			Bind<IRandomFactController>().To<RandomFactController>();

		}
	}
}
