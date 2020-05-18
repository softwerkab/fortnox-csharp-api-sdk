namespace FortnoxAPILibrary.Connectors
{
    public class InboxConnector : ArchiveConnector, IArchiveConnector
    {
        public InboxConnector()
        {
            Resource = "inbox";
        }

    }
}
