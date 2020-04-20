using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IAssetConnector : IConnector
	{
        [SearchParameter("filter")]
		Filter.Asset? FilterBy { get; set; }


        [SearchParameter]
		string Description { get; set; }

        [SearchParameter]
		string Type { get; set; }
		Asset Update(Asset asset);

		Asset Create(Asset asset);

		Asset Get(string id);

		void Delete(string id);

		EntityCollection<AssetSubset> Find();

	}
}
