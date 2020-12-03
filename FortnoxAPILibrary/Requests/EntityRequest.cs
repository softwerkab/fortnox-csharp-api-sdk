namespace FortnoxAPILibrary.Requests
{
    public class EntityRequest<TEntity> : BaseRequest
    {
        public TEntity Entity { get; set; }
    }
}