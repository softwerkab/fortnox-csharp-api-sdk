using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class TaxReductionConnector : EntityConnector<TaxReduction, TaxReductions, Sort.By.TaxReduction>
	{
		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string ReferenceNumber { get; set; }

		private bool filterBySet = false;
		private Filter.Invoice filterBy;
        /// <remarks/>
        [FilterProperty("filter")]
		public Filter.Invoice FilterBy
		{
			get { return filterBy; }
			set
			{
				filterBy = value;
				filterBySet = true;
			}
		}

		/// <remarks/>
		public enum TypeOfReduction
		{
			/// <remarks/>
			ROT,
			/// <remarks/>
			RUT
		}

		/// <remarks/>
		public enum ReferenceDocumentType
		{
			/// <remarks/>
			OFFER,
			/// <remarks/>
			ORDER,
			/// <remarks/>
			INVOICE
		}

		/// <remarks/>
		public TaxReductionConnector(string accessToken, string clientSecret) : base(accessToken, clientSecret)
        {
			base.Resource = "taxreductions";
		}

        /// <remarks/>
        public TaxReductionConnector() : this(null, null)
        {
        }

        /// <summary>
        /// Find a tax reduction based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TaxReduction Get(string id)
		{
			return base.BaseGet(id);
		}

		/// <summary>
		/// Updates a tax reduction
		/// </summary>
		/// <param name="taxReduction">The tax reduction to update</param>
		/// <returns>The updated tax reduction</returns>
		public TaxReduction Update(TaxReduction taxReduction)
		{
			return base.BaseUpdate(taxReduction, taxReduction.Id.ToString());
		}

		/// <summary>
		/// Create a new tax reduction
		/// </summary>
		/// <param name="taxReduction">The tax reduction to create</param>
		/// <returns>The created tax reduction</returns>
		public TaxReduction Create(TaxReduction taxReduction)
		{
			return base.BaseCreate(taxReduction);
		}

		/// <summary>
		/// Deletes a tax reduction
		/// </summary>
		/// <param name="id">Id of the tax reduction to delete</param>
		public void Delete(string id)
		{
			base.BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of tax reductions
		/// </summary>
		/// <returns>A list of tax reductions</returns>
		public TaxReductions Find()
		{
			return base.BaseFind();
		}
	}
}
