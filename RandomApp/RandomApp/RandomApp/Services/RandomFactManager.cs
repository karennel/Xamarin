
using RandomApp.EndPoints;
using RandomApp.Services.Responses;
using System.Text;
using System.Threading.Tasks;

namespace RandomApp.Services
{
	public class RandomFactManager :  ApplicationService, IRandomFactManager
	{
		public RandomFactManager(IEndPointsManager endPointsManager) : base(endPointsManager)
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
