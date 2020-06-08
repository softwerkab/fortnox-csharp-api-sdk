using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class UnitConnector : EntityConnector<Unit, EntityCollection<Unit>, Sort.By.Unit?>, IUnitConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Unit? FilterBy { get; set; }


		/// <remarks/>
		public UnitConnector()
		{
			Resource = "units";
		}
		/// <summary>
		/// Find a unit based on id
		/// </summary>
		/// <param name="id">Identifier of the unit to find</param>
		/// <returns>The found unit</returns>
		public Unit Get(string id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a unit
		/// </summary>
		/// <param name="unit">The unit to update</param>
		/// <returns>The updated unit</returns>
		public Unit Update(Unit unit)
		{
			return UpdateAsync(unit).Result;
		}

		/// <summary>
		/// Creates a new unit
		/// </summary>
		/// <param name="unit">The unit to create</param>
		/// <returns>The created unit</returns>
		public Unit Create(Unit unit)
		{
			return CreateAsync(unit).Result;
		}

		/// <summary>
		/// Deletes a unit
		/// </summary>
		/// <param name="id">Identifier of the unit to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of units
		/// </summary>
		/// <returns>A list of units</returns>
		public EntityCollection<Unit> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<Unit>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id);
		}
		public async Task<Unit> CreateAsync(Unit unit)
		{
			return await BaseCreate(unit);
		}
		public async Task<Unit> UpdateAsync(Unit unit)
		{
			return await BaseUpdate(unit, unit.Code);
		}
		public async Task<Unit> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
