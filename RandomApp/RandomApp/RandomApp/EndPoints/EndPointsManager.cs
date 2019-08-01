

namespace RandomApp.EndPoints
{
	public class EndPointsManager : IEndPointsManager
	{
		public IEndPoints EndPoints { get; private set; }
		
		public void Init()
		{
			EndPoints = new EndPoints();
		}
	}
}
