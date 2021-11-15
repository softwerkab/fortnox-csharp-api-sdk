namespace Fortnox.SDK.Connectors;

internal class InboxConnector : ArchiveConnector
{
    public InboxConnector()
    {
        Resource = Endpoints.Inbox;
    }
}