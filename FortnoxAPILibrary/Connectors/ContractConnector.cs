using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace FortnoxAPILibrary.Connectors
{
    public interface IContractConnector : IFinancialYearBasedEntityConnector<Contract, Contracts, Sort.By.Contract>
    {
        /// <remarks/>
        string DocumentNumber { get; set; }

        /// <remarks/>
        string CustomerNumber { get; set; }

        /// <remarks/>
        string CustomerName { get; set; }

        /// <remarks/>
        string TemplateNumber { get; set; }

        /// <remarks/>
        string ContractLength { get; set; }

        /// <remarks/>
        string InvoiceInterval { get; set; }

        /// <remarks/>
        string LastInvoiceDate { get; set; }

        /// <remarks/>
        string Total { get; set; }

        /// <remarks/>
        string InvoicesRemaining { get; set; }

        /// <remarks/>
        string PeriodStart { get; set; }

        /// <remarks/>
        string PeriodEnd { get; set; }

        /// <remarks/>
        Filter.Contract FilterBy { get; set; }

        /// <summary>
        /// Find a Contract
        /// </summary>
        /// <param name="documentNumber">The document number of the Contract to find</param>
        /// <returns>The found Contract</returns>
        Contract Get(string documentNumber);

        /// <summary>
        /// Updates a Contract
        /// </summary>
        /// <param name="contract">The Contract to update</param>
        /// <returns>The updated Contract</returns>
        Contract Update(Contract contract);

        /// <summary>
        /// Create a new Contract
        /// </summary>
        /// <param name="contract">The Contract to create</param>
        /// <returns>The created Contract</returns>
        Contract Create(Contract contract);

        /// <summary>
        /// Gets at list of Contracts
        /// </summary>
        /// <returns>A list of Contracts</returns>
        Contracts Find();

        /// <summary>
        /// Finish a contract
        /// </summary>
        /// <param name="documentNumber">The document number of the contract to finish.</param>
        /// <returns>The finished contract</returns>
        Contract Finish(string documentNumber);

        /// <summary>
        /// Create an invoice from a contract
        /// </summary>
        /// <param name="documentNumber">The document number of the contract to create an Invoice from.</param>
        /// <returns>The Contract that the Invoice was created from</returns>
        Contract CreateInvoice(string documentNumber);

        /// <summary>
        /// Increase the Invoice count for the Contract
        /// </summary>
        /// <param name="documentNumber">The document number of the Contract to increase the Invoice.</param>
        /// <returns>The Contract that the Invoice was created from</returns>
        Contract IncreaseInvoiceCount(string documentNumber);
    }

    /// <remarks/>
    public class ContractConnector : FinancialYearBasedEntityConnector<Contract, Contracts, Sort.By.Contract>, IContractConnector
    {
        /// <remarks/>
        [FilterProperty]
        public string DocumentNumber { get; set; }

        /// <remarks/>
        [FilterProperty]
        public string CustomerNumber { get; set; }

        /// <remarks/>
        [FilterProperty]
        public string CustomerName { get; set; }

        /// <remarks/>
        [FilterProperty]
        public string TemplateNumber { get; set; }

        /// <remarks/>
        [FilterProperty]
        public string ContractLength { get; set; }

        /// <remarks/>
        [FilterProperty]
        public string InvoiceInterval { get; set; }

        /// <remarks/>
        public string LastInvoiceDate { get; set; }

        /// <remarks/>
        [FilterProperty]
        public string Total { get; set; }

        /// <remarks/>
        [FilterProperty]
        public string InvoicesRemaining { get; set; }

        /// <remarks/>
        [FilterProperty]
        public string PeriodStart { get; set; }

        /// <remarks/>
        [FilterProperty]
        public string PeriodEnd { get; set; }

        private bool filterBySet = false;
        private Filter.Contract filterBy;
        /// <remarks/>
        [FilterProperty("filter")]
        public Filter.Contract FilterBy
        {
            get { return filterBy; }
            set
            {
                filterBy = value;
                filterBySet = true;
            }
        }

        /// <remarks/>
        public ContractConnector()
        {
            base.Resource = "contracts";
        }
        
		/// <summary>
		/// Find a Contract
		/// </summary>
		/// <param name="documentNumber">The document number of the Contract to find</param>
		/// <returns>The found Contract</returns>
        public Contract Get(string documentNumber)
        {
            return base.BaseGet(documentNumber);
        }

        /// <summary>
        /// Updates a Contract
        /// </summary>
        /// <param name="contract">The Contract to update</param>
        /// <returns>The updated Contract</returns>
        public Contract Update(Contract contract)
        {
            return base.BaseUpdate(contract, contract.DocumentNumber);
        }

        /// <summary>
        /// Create a new Contract
        /// </summary>
        /// <param name="contract">The Contract to create</param>
        /// <returns>The created Contract</returns>
        public Contract Create(Contract contract)
        {
            return base.BaseCreate(contract);
        }

        /// <summary>
        /// Gets at list of Contracts
        /// </summary>
        /// <returns>A list of Contracts</returns>
        public Contracts Find()
        {
            return base.BaseFind();
        }

        /// <summary>
        /// Finish a contract
        /// </summary>
        /// <param name="documentNumber">The document number of the contract to finish.</param>
        /// <returns>The finished contract</returns>
        public Contract Finish(string documentNumber)
        {
            return base.DoAction(documentNumber, "finish");
        }

        /// <summary>
        /// Create an invoice from a contract
        /// </summary>
        /// <param name="documentNumber">The document number of the contract to create an Invoice from.</param>
        /// <returns>The Contract that the Invoice was created from</returns>
        public Contract CreateInvoice(string documentNumber)
        {
            return base.DoAction(documentNumber, "createinvoice");
        }

        /// <summary>
        /// Increase the Invoice count for the Contract
        /// </summary>
        /// <param name="documentNumber">The document number of the Contract to increase the Invoice.</param>
        /// <returns>The Contract that the Invoice was created from</returns>
        public Contract IncreaseInvoiceCount(string documentNumber)
        {
            return base.DoAction(documentNumber, "increaseinvoicecount");
        }
    }
}
