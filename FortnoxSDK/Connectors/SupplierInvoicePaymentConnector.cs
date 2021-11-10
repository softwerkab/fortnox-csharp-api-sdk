using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors;

/// <remarks/>
internal class SupplierInvoicePaymentConnector : SearchableEntityConnector<SupplierInvoicePayment, SupplierInvoicePaymentSubset, SupplierInvoicePaymentSearch>, ISupplierInvoicePaymentConnector
{

    /// <remarks/>
    public SupplierInvoicePaymentConnector()
    {
        Resource = "supplierinvoicepayments";
    }
    /// <summary>
    /// Find a supplierInvoicePayment based on id
    /// </summary>
    /// <param name="id">Identifier of the supplierInvoicePayment to find</param>
    /// <returns>The found supplierInvoicePayment</returns>
    public SupplierInvoicePayment Get(long? id)
    {
        return GetAsync(id).GetResult();
    }

    /// <summary>
    /// Updates a supplierInvoicePayment
    /// </summary>
    /// <param name="supplierInvoicePayment">The supplierInvoicePayment to update</param>
    /// <returns>The updated supplierInvoicePayment</returns>
    public SupplierInvoicePayment Update(SupplierInvoicePayment supplierInvoicePayment)
    {
        return UpdateAsync(supplierInvoicePayment).GetResult();
    }

    /// <summary>
    /// Creates a new supplierInvoicePayment
    /// </summary>
    /// <param name="supplierInvoicePayment">The supplierInvoicePayment to create</param>
    /// <returns>The created supplierInvoicePayment</returns>
    public SupplierInvoicePayment Create(SupplierInvoicePayment supplierInvoicePayment)
    {
        return CreateAsync(supplierInvoicePayment).GetResult();
    }

    /// <summary>
    /// Deletes a supplierInvoicePayment
    /// </summary>
    /// <param name="id">Identifier of the supplierInvoicePayment to delete</param>
    public void Delete(long? id)
    {
        DeleteAsync(id).GetResult();
    }

    /// <summary>
    /// Gets a list of supplierInvoicePayments
    /// </summary>
    /// <returns>A list of supplierInvoicePayments</returns>
    public EntityCollection<SupplierInvoicePaymentSubset> Find(SupplierInvoicePaymentSearch searchSettings)
    {
        return FindAsync(searchSettings).GetResult();
    }

    /// <summary>
    /// Bookkeeps the supplier invoice payment
    /// </summary>
    /// <param name="id"></param>
    public void Bookkeep(long? id)
    {
        BookkeepAsync(id).GetResult();
    }

    public async Task<EntityCollection<SupplierInvoicePaymentSubset>> FindAsync(SupplierInvoicePaymentSearch searchSettings)
    {
        return await BaseFind(searchSettings).ConfigureAwait(false);
    }
    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }
    public async Task<SupplierInvoicePayment> CreateAsync(SupplierInvoicePayment supplierInvoicePayment)
    {
        return await BaseCreate(supplierInvoicePayment).ConfigureAwait(false);
    }
    public async Task<SupplierInvoicePayment> UpdateAsync(SupplierInvoicePayment supplierInvoicePayment)
    {
        return await BaseUpdate(supplierInvoicePayment, supplierInvoicePayment.Number.ToString()).ConfigureAwait(false);
    }
    public async Task<SupplierInvoicePayment> GetAsync(long? id)
    {
        return await BaseGet(id.ToString()).ConfigureAwait(false);
    }
    public async Task BookkeepAsync(long? id)
    {
        await DoActionAsync(id.ToString(), Action.Bookkeep).ConfigureAwait(false);
    }
}