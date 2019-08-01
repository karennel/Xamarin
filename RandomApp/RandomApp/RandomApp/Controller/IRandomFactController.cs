using RandomApp.Services.Responses;
using System.Threading.Tasks;

namespace RandomApp.Controller
{
	public interface IRandomFactController
	{
		Task Test();

		Task<RandomFactResponse> RandomFact();
	}
}
