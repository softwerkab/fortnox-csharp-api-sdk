using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class TermsOfPaymentConnector : SearchableEntityConnector<TermsOfPayment, TermsOfPayment, TermsOfPaymentSearch>, ITermsOfPaymentConnector
	{


		/// <remarks/>
		public TermsOfPaymentConnector()
		{
			Resource = "termsofpayments";
		}
		/// <summary>
		/// Find a termsOfPayment based on id
		/// </summary>
		/// <param name="id">Identifier of the termsOfPayment to find</param>
		/// <returns>The found termsOfPayment</returns>
		public TermsOfPayment Get(string id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a termsOfPayment
		/// </summary>
		/// <param name="termsOfPayment">The termsOfPayment to update</param>
		/// <returns>The updated termsOfPayment</returns>
		public TermsOfPayment Update(TermsOfPayment termsOfPayment)
		{
			return UpdateAsync(termsOfPayment).Result;
		}

		/// <summary>
		/// Creates a new termsOfPayment
		/// </summary>
		/// <param name="termsOfPayment">The termsOfPayment to create</param>
		/// <returns>The created termsOfPayment</returns>
		public TermsOfPayment Create(TermsOfPayment termsOfPayment)
		{
			return CreateAsync(termsOfPayment).Result;
		}

		/// <summary>
		/// Deletes a termsOfPayment
		/// </summary>
		/// <param name="id">Identifier of the termsOfPayment to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of termsOfPayments
		/// </summary>
		/// <returns>A list of termsOfPayments</returns>
		public EntityCollection<TermsOfPayment> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<TermsOfPayment>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<TermsOfPayment> CreateAsync(TermsOfPayment termsOfPayment)
		{
			return await BaseCreate(termsOfPayment).ConfigureAwait(false);
		}
		public async Task<TermsOfPayment> UpdateAsync(TermsOfPayment termsOfPayment)
		{
			return await BaseUpdate(termsOfPayment, termsOfPayment.Code).ConfigureAwait(false);
		}
		public async Task<TermsOfPayment> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
	}
}
