using Ninject.Activation;
using Ninject.Modules;

namespace RandomApp
{
	public class RandomAppModules : NinjectModule
	{
	
		public override void Load()
		{
			Bind<INavigationService>().To<NavigationService>();
		}
	}
}
