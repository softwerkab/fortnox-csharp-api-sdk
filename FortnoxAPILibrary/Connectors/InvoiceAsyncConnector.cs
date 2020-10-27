using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary.Connectors
{
    public class InvoiceAsyncConnector : EntityAsyncConnector<Invoice, EntityCollection<InvoiceSubset>, Sort.By.Invoice?>
    {
        public InvoiceAsyncConnector()
        {
            Resource = "invoices";
        } 
        /// <summary>
        /// This action returns a PDF document with the current template that is used by the specific document. Unliike the action print, this action doesn’t set the property Sent as true.
        /// <param name="id"></param>
        /// <returns></returns>
        /// </summary>
        public byte[] Preview(long? id)
        {
            return DoDownloadAction(id.ToString(), Action.Preview);
        }
    }
}