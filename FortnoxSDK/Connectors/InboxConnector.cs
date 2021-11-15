namespace Fortnox.SDK.Connectors;

internal class InboxConnector : ArchiveConnector
{
    public InboxConnector()
    {
        Endpoint = Endpoints.Inbox;
    }
}