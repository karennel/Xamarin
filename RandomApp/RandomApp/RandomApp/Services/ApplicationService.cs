
using RandomApp.EndPoints;

namespace RandomApp.Services
{
	public abstract class ApplicationService : Service
	{
		readonly IEndPointsManager _endPointsManager;

		protected ApplicationService(IEndPointsManager endPointsManager)
		{
			_endPointsManager = endPointsManager;
		}

		protected override string GetEndPoint()
		{
			return _endPointsManager.EndPoints.RandomFact.Url;
		}
	}
}
