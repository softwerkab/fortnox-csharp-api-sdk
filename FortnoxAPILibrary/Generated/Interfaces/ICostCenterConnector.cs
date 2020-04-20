using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface ICostCenterConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.CostCenter? FilterBy { get; set; }

		CostCenter Update(CostCenter costCenter);

		CostCenter Create(CostCenter costCenter);

		CostCenter Get(string id);

		void Delete(string id);

		EntityCollection<CostCenter> Find();

	}
}
