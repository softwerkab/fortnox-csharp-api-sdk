using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    internal class UnitConnector : SearchableEntityConnector<Unit, Unit, UnitSearch>, IUnitConnector
    {


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
            return GetAsync(id).GetResult();
        }

        /// <summary>
        /// Updates a unit
        /// </summary>
        /// <param name="unit">The unit to update</param>
        /// <returns>The updated unit</returns>
        public Unit Update(Unit unit)
        {
            return UpdateAsync(unit).GetResult();
        }

        /// <summary>
        /// Creates a new unit
        /// </summary>
        /// <param name="unit">The unit to create</param>
        /// <returns>The created unit</returns>
        public Unit Create(Unit unit)
        {
            return CreateAsync(unit).GetResult();
        }

        /// <summary>
        /// Deletes a unit
        /// </summary>
        /// <param name="id">Identifier of the unit to delete</param>
        public void Delete(string id)
        {
            DeleteAsync(id).GetResult();
        }

        /// <summary>
        /// Gets a list of units
        /// </summary>
        /// <returns>A list of units</returns>
        public EntityCollection<Unit> Find(UnitSearch searchSettings)
        {
            return FindAsync(searchSettings).GetResult();
        }

        public async Task<EntityCollection<Unit>> FindAsync(UnitSearch searchSettings)
        {
            return await BaseFind(searchSettings).ConfigureAwait(false);
        }
        public async Task DeleteAsync(string id)
        {
            await BaseDelete(id).ConfigureAwait(false);
        }
        public async Task<Unit> CreateAsync(Unit unit)
        {
            return await BaseCreate(unit).ConfigureAwait(false);
        }
        public async Task<Unit> UpdateAsync(Unit unit)
        {
            return await BaseUpdate(unit, unit.Code).ConfigureAwait(false);
        }
        public async Task<Unit> GetAsync(string id)
        {
            return await BaseGet(id).ConfigureAwait(false);
        }
    }
}
