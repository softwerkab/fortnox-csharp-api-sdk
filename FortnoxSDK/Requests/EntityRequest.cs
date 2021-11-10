namespace Fortnox.SDK.Requests;

internal class EntityRequest<TEntity> : BaseRequest
{
    public TEntity Entity { get; set; }
    public bool UseEntityWrapper { get; set; } = true;
}