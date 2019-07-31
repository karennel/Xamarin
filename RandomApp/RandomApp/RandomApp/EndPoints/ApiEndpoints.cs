
namespace RandomApp.EndPoints
{
	public class EndPoints : IEndPoints
	{
		public IRandomFactEndpoint RandomFact => new RandomFactEndpoint("https://batcluster-dev.out-bateleur.co.za:9221/api");
	}
}
