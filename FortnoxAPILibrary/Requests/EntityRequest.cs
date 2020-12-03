namespace FortnoxAPILibrary.Requests
{
    public class EntityRequest<TEntity> : BaseRequest
    {
        public TEntity Entity { get; set; }
        public bool UseEntityWrapper { get; set; } = true;
    }
}