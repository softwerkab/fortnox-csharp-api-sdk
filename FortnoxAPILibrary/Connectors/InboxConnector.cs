namespace FortnoxAPILibrary.Connectors
{
    public class InboxConnector : ArchiveConnector
    {
		public InboxSearch Search { get; set; } = new InboxSearch();

        public InboxConnector()
        {
            Resource = "inbox";
        }

    }
}
