using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CustomerConnector : EntityConnector<Customer, Customers, Sort.By.Customer>
	{
		/// <remarks/>
		public enum Type
		{
			/// <remarks/>
			PRIVATE,
			/// <remarks/>
			COMPANY
        }

		/// <remarks/>
		public enum VATType
		{
			/// <remarks/>
			SEVAT,
			/// <remarks/>
			SEREVERSEDVAT,
			/// <remarks/>
			EUREVERSEDVAT,
			/// <remarks/>
			EUVAT,
			/// <remarks/>
			EXPORT
		}

		/// <remarks/>
		public enum DefaultInvoiceDeliveryType
		{
			/// <remarks/>
			EMAIL,
			/// <remarks/>
			PRINT,
			/// <remarks/>
			PRINTSERVICE,
            /// <remarks/>
            ELECTRONICINVOICE
		}

		/// <remarks/>
		public enum DefaultOfferDeliveryType
		{
			/// <remarks/>
			EMAIL,
			/// <remarks/>
			PRINT
		}

		/// <remarks/>
		public enum DefaultOrderDeliveryType
		{
			/// <remarks/>
			EMAIL,
			/// <remarks/>
			PRINT
		}

		private bool filterBySet;
		private Filter.Customer filterBy;
		/// <remarks/>
		[FilterProperty("filter")]
		public Filter.Customer FilterBy
		{
			get { return filterBy; }
			set
			{
				filterBy = value;
				filterBySet = true;
			}
		}


		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string City { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string CustomerNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string Email { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string Name { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string OrganisationNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string Phone { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string ZipCode { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string GLN { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string GLNDelivery { get; set; }

		/// <remarks/>
		public CustomerConnector()
		{
			Resource = "customers";
		}


		/// <summary>
		/// Find a customer based on customernumber
		/// </summary>
		/// <param name="customerNumber">The customernumber to find</param>
		/// <returns>The found customer</returns>
		public Customer Get(string customerNumber)
		{
			return BaseGet(customerNumber);
		}

		/// <summary>
		/// Updates a customer
		/// </summary>
		/// <param name="customer">The customer to update</param>
		/// <returns>The updated customer</returns>
		public Customer Update(Customer customer)
		{
			return BaseUpdate(customer, customer.CustomerNumber);
		}

		/// <summary>
		/// Create a new customer
		/// </summary>
		/// <param name="customer">The customer to create</param>
		/// <returns>The created customer</returns>
		public Customer Create(Customer customer)
		{
			return BaseCreate(customer);
		}

		/// <summary>
		/// Deletes a customer
		/// </summary>
		/// <param name="customerNumber">The customernumber to delete</param>
		public void Delete(string customerNumber)
		{
			BaseDelete(customerNumber);
		}

		/// <summary>
		/// Gets a list of customers
		/// </summary>
		/// <returns>A list of customers</returns>
		public Customers Find()
		{
			return BaseFind();
		}
	}
}
