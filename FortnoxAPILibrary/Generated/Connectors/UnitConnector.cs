using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class UnitConnector : EntityConnector<Unit, EntityCollection<UnitSubset>, Sort.By.Unit?>
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Unit FilterBy { get; set; }


		/// <remarks/>
		public UnitConnector()
		{
			Resource = "units";
		}

		/// <summary>
		/// Find a unit based on unitnumber
		/// </summary>
		/// <param name="unitNumber">The unitnumber to find</param>
		/// <returns>The found unit</returns>
		public Unit Get(string unitNumber)
		{
			return BaseGet(unitNumber);
		}

		/// <summary>
		/// Updates a unit
		/// </summary>
		/// <param name="unit">The unit to update</param>
		/// <returns>The updated unit</returns>
		public Unit Update(Unit unit)
		{
			return BaseUpdate(unit, unit.UnitNumber);
		}

		/// <summary>
		/// Create a new unit
		/// </summary>
		/// <param name="unit">The unit to create</param>
		/// <returns>The created unit</returns>
		public Unit Create(Unit unit)
		{
			return BaseCreate(unit);
		}

		/// <summary>
		/// Deletes a unit
		/// </summary>
		/// <param name="unitNumber">The unitnumber to delete</param>
		public void Delete(string unitNumber)
		{
			BaseDelete(unitNumber);
		}

		/// <summary>
		/// Gets a list of units
		/// </summary>
		/// <returns>A list of units</returns>
		public EntityCollection<UnitSubset> Find()
		{
			return BaseFind();
		}
	}
}
