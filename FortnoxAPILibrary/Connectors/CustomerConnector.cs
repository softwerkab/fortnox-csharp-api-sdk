using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CustomerConnector : EntityConnector<Customer, EntityCollection<CustomerSubset>, Sort.By.Customer?>, ICustomerConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Customer? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string City { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string CustomerNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Email { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string GLN { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string GLNDelivery { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Name { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string OrganisationNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Phone1 { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string ZipCode { get; set; }

		/// <remarks/>
		public CustomerConnector()
		{
			Resource = "customers";
		}
		/// <summary>
		/// Find a customer based on id
		/// </summary>
		/// <param name="id">Identifier of the customer to find</param>
		/// <returns>The found customer</returns>
		public Customer Get(string id)
		{
			return GetAsync(id).Result;
		}

		/// <summary>
		/// Updates a customer
		/// </summary>
		/// <param name="customer">The customer to update</param>
		/// <returns>The updated customer</returns>
		public Customer Update(Customer customer)
		{
			return UpdateAsync(customer).Result;
		}

		/// <summary>
		/// Creates a new customer
		/// </summary>
		/// <param name="customer">The customer to create</param>
		/// <returns>The created customer</returns>
		public Customer Create(Customer customer)
		{
			return CreateAsync(customer).Result;
		}

		/// <summary>
		/// Deletes a customer
		/// </summary>
		/// <param name="id">Identifier of the customer to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).Wait();
		}

		/// <summary>
		/// Gets a list of customers
		/// </summary>
		/// <returns>A list of customers</returns>
		public EntityCollection<CustomerSubset> Find()
		{
			return FindAsync().Result;
		}

		public async Task<EntityCollection<CustomerSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id);
		}
		public async Task<Customer> CreateAsync(Customer customer)
		{
			return await BaseCreate(customer);
		}
		public async Task<Customer> UpdateAsync(Customer customer)
		{
			return await BaseUpdate(customer, customer.CustomerNumber);
		}
		public async Task<Customer> GetAsync(string id)
		{
			return await BaseGet(id);
		}
	}
}
