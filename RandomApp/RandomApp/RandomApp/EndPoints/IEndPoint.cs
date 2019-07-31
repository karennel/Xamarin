
namespace RandomApp.EndPoints
{
	public interface IEndPoint
	{
		string Url { get; }
	}

	public interface IRandomFactEndpoint : IEndPoint { }

}
