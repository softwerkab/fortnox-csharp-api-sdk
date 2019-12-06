using System;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary
{
	/// <remarks/>
	[Serializable]
    public class ErrorInformation
	{
		/// <remarks/>
        public string Error { get; set; }

		/// <remarks/>
        public string Message { get; set; }

		/// <remarks/>
        public string Code { get; set; }
	}
}