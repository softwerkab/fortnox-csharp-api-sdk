namespace Fortnox.SDK.Serialization
{
    public interface ISerializer
    {
        string Serialize<T>(T entity);
        T Deserialize<T>(string content);
    }
}
