using Ninject.Modules;

namespace RandomApp
{
	public class RandomAppModules : NinjectModule
	{
		public override void Load()
		{
			Bind<INavigator>().To<Navigator>()
			 .InSingletonScope();
		}
	}
}
