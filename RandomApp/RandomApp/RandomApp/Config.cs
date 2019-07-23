using System;
using System.Collections.Generic;
using System.Text;

namespace RandomApp
{
	public interface IBateleurConfig
	{
		//NumberFormatInfo NumberFormatInfo { get; }
		//NumberFormatInfo NumberFormatInfoNoDecimals { get; }

		string DateFormat { get; }
		string TimeFormat { get; }

		string ClientId { get; }
		string TenantCode { get; }

		string GoogleMapsCountry { get; }
		string GoogleApiKey { get; }

		bool IsAccountLiteVisible { get; }
	}
}
