
namespace RandomApp.EndPoints
{
	public class EndPoints : IEndPoints
	{
		public IRandomFactEndpoint RandomFact => new RandomFactEndpoint("https://randomuselessfact.appspot.com/random.json?language=en");
	}
}
