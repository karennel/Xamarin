using System;
using System.Collections.Generic;
using System.Text;

namespace RandomApp.EndPoints
{
	public interface IEndPoints
	{
		IRandomFactEndpoint RandomFact { get; }
	}
}
