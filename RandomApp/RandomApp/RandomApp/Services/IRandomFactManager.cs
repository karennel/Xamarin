using RandomApp.Services.Responses;
using System.Threading.Tasks;

namespace RandomApp.Services
{
	public interface IRandomFactManager
	{
		void Test();
		Task<RandomFactResponse> RandomFact();
	}
}
