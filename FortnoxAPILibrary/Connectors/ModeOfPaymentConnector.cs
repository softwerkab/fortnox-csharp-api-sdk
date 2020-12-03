using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ModeOfPaymentConnector : SearchableEntityConnector<ModeOfPayment, ModeOfPayment, ModeOfPaymentSearch>, IModeOfPaymentConnector
	{


		/// <remarks/>
		public ModeOfPaymentConnector()
		{
			Resource = "modesofpayments";
		}
		/// <summary>
		/// Find a modeOfPayment based on id
		/// </summary>
		/// <param name="id">Identifier of the modeOfPayment to find</param>
		/// <returns>The found modeOfPayment</returns>
		public ModeOfPayment Get(string id)
		{
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a modeOfPayment
		/// </summary>
		/// <param name="modeOfPayment">The modeOfPayment to update</param>
		/// <returns>The updated modeOfPayment</returns>
		public ModeOfPayment Update(ModeOfPayment modeOfPayment)
		{
			return UpdateAsync(modeOfPayment).GetResult();
		}

		/// <summary>
		/// Creates a new modeOfPayment
		/// </summary>
		/// <param name="modeOfPayment">The modeOfPayment to create</param>
		/// <returns>The created modeOfPayment</returns>
		public ModeOfPayment Create(ModeOfPayment modeOfPayment)
		{
			return CreateAsync(modeOfPayment).GetResult();
		}

		/// <summary>
		/// Deletes a modeOfPayment
		/// </summary>
		/// <param name="id">Identifier of the modeOfPayment to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).GetResult();
		}

		/// <summary>
		/// Gets a list of modeOfPayments
		/// </summary>
		/// <returns>A list of modeOfPayments</returns>
		public EntityCollection<ModeOfPayment> Find(ModeOfPaymentSearch searchSettings)
		{
			return FindAsync(searchSettings).GetResult();
		}

		public async Task<EntityCollection<ModeOfPayment>> FindAsync(ModeOfPaymentSearch searchSettings)
		{
			return await BaseFind(searchSettings).ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<ModeOfPayment> CreateAsync(ModeOfPayment modeOfPayment)
		{
			return await BaseCreate(modeOfPayment).ConfigureAwait(false);
		}
		public async Task<ModeOfPayment> UpdateAsync(ModeOfPayment modeOfPayment)
		{
			return await BaseUpdate(modeOfPayment, modeOfPayment.Code).ConfigureAwait(false);
		}
		public async Task<ModeOfPayment> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
