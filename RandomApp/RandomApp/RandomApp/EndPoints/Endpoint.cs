
namespace RandomApp.EndPoints
{
	public abstract class EndPoint : IEndPoint
	{
		public string Url { get; private set; }

		protected EndPoint(string url)
		{
			Url = url;
		}
	}

	public class RandomFactEndpoint : EndPoint, IRandomFactEndpoint
	{
		public RandomFactEndpoint(string url) : base(url) { }
	}
}
