using System;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class CustomerConnector : SearchableEntityConnector<Customer, CustomerSubset, CustomerSearch>, ICustomerConnector
	{


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
			return GetAsync(id).GetResult();
		}

		/// <summary>
		/// Updates a customer
		/// </summary>
		/// <param name="customer">The customer to update</param>
		/// <returns>The updated customer</returns>
		public Customer Update(Customer customer)
		{
			return UpdateAsync(customer).GetResult();
		}

		/// <summary>
		/// Creates a new customer
		/// </summary>
		/// <param name="customer">The customer to create</param>
		/// <returns>The created customer</returns>
		public Customer Create(Customer customer)
		{
			return CreateAsync(customer).GetResult();
		}

		/// <summary>
		/// Deletes a customer
		/// </summary>
		/// <param name="id">Identifier of the customer to delete</param>
		public void Delete(string id)
		{
			DeleteAsync(id).GetResult();
		}

        /// <summary>
        /// Gets a list of customers
        /// </summary>
        /// <returns>A list of customers</returns>
        public EntityCollection<CustomerSubset> Find()
        {
            return FindAsync().GetResult();
        }

        public async Task<EntityCollection<CustomerSubset>> FindAsync()
		{
			return await BaseFind().ConfigureAwait(false);
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id).ConfigureAwait(false);
		}
		public async Task<Customer> CreateAsync(Customer customer)
		{
			return await BaseCreate(customer).ConfigureAwait(false);
		}
		public async Task<Customer> UpdateAsync(Customer customer)
		{
			return await BaseUpdate(customer, customer.CustomerNumber).ConfigureAwait(false);
		}
		public async Task<Customer> GetAsync(string id)
		{
			return await BaseGet(id).ConfigureAwait(false);
		}
    }
}
