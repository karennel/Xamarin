
namespace RandomApp.EndPoints
{
	public interface IEndPointsManager
	{
		IEndPoints EndPoints { get; }

		void Init(string environment);
	}
}
