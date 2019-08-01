
using RandomApp.Services.Responses;
using System.Threading.Tasks;

namespace RandomApp
{
	public interface IRandomFactServicesManagement
	{
		void Test();
		Task<RandomFactResponse> RandomFact();
	}
}
