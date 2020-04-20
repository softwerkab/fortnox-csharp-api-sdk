using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAccountChartConnector
	{
        [SearchParameter("filter")]
		Filter.AccountChart? FilterBy { get; set; }
		
		EntityCollection<AccountChart> Find();

	}
}
