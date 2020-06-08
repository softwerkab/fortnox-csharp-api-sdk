using System.Text.RegularExpressions;
using FortnoxAPILibrary.Entities;
using Newtonsoft.Json.Linq;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AssetTypesConnector : EntityConnector<AssetType, EntityCollection<AssetTypesSubset>, Sort.By.AssetTypes?>, IAssetTypesConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.AssetTypes? FilterBy { get; set; }


		/// <remarks/>
		public AssetTypesConnector()
		{
			Resource = "assets/types";
		}
		/// <summary>
		/// Find a assetType based on id
		/// </summary>
		/// <param name="id">Identifier of the assetType to find</param>
		/// <returns>The found assetType</returns>
		public AssetType Get(int? id)
		{
            return GetAsync(id).Result;
        }

		/// <summary>
		/// Updates a assetType
		/// </summary>
		/// <param name="assetTypes">The assetType to update</param>
		/// <returns>The updated assetType</returns>
		public AssetType Update(AssetType assetTypes)
		{
            return UpdateAsync(assetTypes).Result;
        }

		/// <summary>
		/// Creates a new assetType
		/// </summary>
		/// <param name="assetType">The assetType to create</param>
		/// <returns>The created assetType</returns>
		public AssetType Create(AssetType assetType)
		{
            return CreateAsync(assetType).Result;
        }

		/// <summary>
		/// Deletes a assetTypes
		/// </summary>
		/// <param name="id">Identifier of the assetTypes to delete</param>
		public void Delete(int? id)
		{
			DeleteAsync(id).Wait();
		}

        /// <summary>
        /// Gets a list of assetTypess
        /// </summary>
        /// <returns>A list of assetTypess</returns>
        public EntityCollection<AssetTypesSubset> Find()
        {
            return FindAsync().Result;
        }

        public async Task<EntityCollection<AssetTypesSubset>> FindAsync()
        {
            FixResponseContent = (json) =>
            {
                var structure = JObject.Parse(json);

                structure["MetaInformation"] = structure["Types"][0]["MetaInformation"]; //copy meta-info node to root
                structure["Types"][0].Remove(); //remove the array element with meta-info node

				var fixedJson = structure.ToString();
                return fixedJson;
            };

            var result = await BaseFind();

            FixResponseContent = null;
			return result;
        }
		public async Task DeleteAsync(int? id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<AssetType> CreateAsync(AssetType assetType)
		{
            FixResponseContent = (json) => new Regex("Type").Replace(json, "AssetType", 1);

            var result = await BaseCreate(assetType);

            FixResponseContent = null;
            return result;
		}
		public async Task<AssetType> UpdateAsync(AssetType assetTypes)
		{
			FixResponseContent = (json) => new Regex("Type").Replace(json, "AssetType", 1);

			var result = await BaseUpdate(assetTypes, assetTypes.Id.ToString());

			FixResponseContent = null;
            return result;
		}
		public async Task<AssetType> GetAsync(int? id)
		{
			FixResponseContent = (json) => new Regex("Type").Replace(json, "AssetType", 1);

			var result = await BaseGet(id.ToString());

            FixResponseContent = null;
            return result;
		}
    }
}
