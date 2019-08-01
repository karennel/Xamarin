using RandomApp.EndPoints;
using RandomApp.Services;
using RandomApp.Services.Responses;
using System.Text;
using System.Threading.Tasks;

namespace RandomApp
{
	public class RandomFactServicesManagement : ApplicationService, IRandomFactServicesManagement
	{
		public RandomFactServicesManagement(IEndPointsManager endPointsManager) : base(endPointsManager)
		{
		}

		public void Test()
		{
		}

		public async Task<RandomFactResponse> RandomFact
					(
					)
		{
			var sb = new StringBuilder();

			var result = await GetAsync<RandomFactResponse>(nameof(RandomFact), sb.ToString());
			return result.Trailer.StatusCode == 0 ? result : null;
		}

	}
}
