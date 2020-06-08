using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ModeOfPaymentConnector : EntityConnector<ModeOfPayment, EntityCollection<ModeOfPayment>, Sort.By.ModeOfPayment?>, IModeOfPaymentConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.ModeOfPayment? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Code { get; set; }

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
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a modeOfPayment
		/// </summary>
		/// <param name="modeOfPayment">The modeOfPayment to update</param>
		/// <returns>The updated modeOfPayment</returns>
		public ModeOfPayment Update(ModeOfPayment modeOfPayment)
		{
			return UpdateAsync(modeOfPayment).Result;
		}

		/// <summary>
		/// Creates a new modeOfPayment
		/// </summary>
		/// <param name="modeOfPayment">The modeOfPayment to create</param>
		/// <returns>The created modeOfPayment</returns>
		public ModeOfPayment Create(ModeOfPayment modeOfPayment)
		{
			return CreateAsync(modeOfPayment).Result;
		}

		/// <summary>
		/// Deletes a modeOfPayment
		/// </summary>
		/// <param name="id">Identifier of the modeOfPayment to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of modeOfPayments
		/// </summary>
		/// <returns>A list of modeOfPayments</returns>
		public EntityCollection<ModeOfPayment> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<ModeOfPayment>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id);
		}
		public async Task<ModeOfPayment> CreateAsync(ModeOfPayment modeOfPayment)
		{
			return await BaseCreate(modeOfPayment);
		}
		public async Task<ModeOfPayment> UpdateAsync(ModeOfPayment modeOfPayment)
		{
			return await BaseUpdate(modeOfPayment, modeOfPayment.Code);
		}
		public async Task<ModeOfPayment> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
