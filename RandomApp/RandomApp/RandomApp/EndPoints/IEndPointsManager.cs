using System;
using System.Collections.Generic;
using System.Text;

namespace RandomApp.EndPoints
{
	public interface IEndPointsManager
	{
		IEndPoints EndPoints { get; }

		void Init();
	}
}
