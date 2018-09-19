using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary.Connectors
{
    public interface ISupplierInvoiceAccrualConnector : IEntityConnector<Sort.By.SupplierInvoiceAccrual>
    {
        /// <summary>
        /// Get an supplierinvoice accrual	
        /// </summary>
        /// <param name="supplierInvoiceNumber">The supplier invoice number of the supplier invoice accrual to get</param>
        /// <returns>The found supplier invoice accrual</returns>
        SupplierInvoiceAccrual Get(string supplierInvoiceNumber);

        ///<summary>
        ///Updates an supplier invoice accrual
        ///</summary>
        ///<param name="invoiceAccrual">The supplier invoice accrual to update</param>
        ///<returns>The updated supplier invoice accrual</returns>
        SupplierInvoiceAccrual Update(SupplierInvoiceAccrual invoiceAccrual);

        /// <summary>
        /// Create a new supplier invoice accrual
        /// </summary>
        /// <param name="supplierInvoiceAccrual">The supplier invoice accrual to create</param>
        /// <returns>The created supplierinvoice accrual</returns>
        SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual);

        /// <summary>
        /// Deletes an supplier invoice accrual
        /// </summary>
        /// <param name="supplierInvoiceNumber">The invoice number of the supplier invoice accrual to delete</param>
        void Delete(string supplierInvoiceNumber);

        /// <summary>
        /// Gets a list of supplier invoice accruals
        /// </summary>
        /// <returns>A list of supplier invoice accruals</returns>
        SupplierInvoiceAccruals Find();
    }

    /// <remarks/>
	public class SupplierInvoiceAccrualConnector : EntityConnector<SupplierInvoiceAccrual, SupplierInvoiceAccruals, Sort.By.SupplierInvoiceAccrual>, ISupplierInvoiceAccrualConnector
    {
		/// <remarks/>
		public SupplierInvoiceAccrualConnector()
		{
			base.Resource = "supplierinvoiceaccruals";
		}

		/// <remarks/>
		public enum Period
		{
			/// <remarks/>
			MONTHLY,
			/// <remarks/>
			BIMONTHLY,
			/// <remarks/>
			QUARTERLY,
			/// <remarks/>
			SEMIANNUALLY,
			/// <remarks/>
			ANNUALLY
		}

		/// <summary>
		/// Get an supplierinvoice accrual	
		/// </summary>
		/// <param name="supplierInvoiceNumber">The supplier invoice number of the supplier invoice accrual to get</param>
		/// <returns>The found supplier invoice accrual</returns>
		public SupplierInvoiceAccrual Get(string supplierInvoiceNumber)
		{
			return base.BaseGet(supplierInvoiceNumber);
		}

		///<summary>
		///Updates an supplier invoice accrual
		///</summary>
		///<param name="invoiceAccrual">The supplier invoice accrual to update</param>
		///<returns>The updated supplier invoice accrual</returns>
		public SupplierInvoiceAccrual Update(SupplierInvoiceAccrual invoiceAccrual)
		{
			return base.BaseUpdate(invoiceAccrual, invoiceAccrual.SupplierInvoiceNumber);
		}

		/// <summary>
		/// Create a new supplier invoice accrual
		/// </summary>
		/// <param name="supplierInvoiceAccrual">The supplier invoice accrual to create</param>
		/// <returns>The created supplierinvoice accrual</returns>
		public SupplierInvoiceAccrual Create(SupplierInvoiceAccrual supplierInvoiceAccrual)
		{
			return base.BaseCreate(supplierInvoiceAccrual);
		}

		/// <summary>
		/// Deletes an supplier invoice accrual
		/// </summary>
		/// <param name="supplierInvoiceNumber">The invoice number of the supplier invoice accrual to delete</param>
		public void Delete(string supplierInvoiceNumber)
		{
			base.BaseDelete(supplierInvoiceNumber);
		}

		/// <summary>
		/// Gets a list of supplier invoice accruals
		/// </summary>
		/// <returns>A list of supplier invoice accruals</returns>
		public SupplierInvoiceAccruals Find()
		{
			return base.BaseFind();
		}
	}
}
