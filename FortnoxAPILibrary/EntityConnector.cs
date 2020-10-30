using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public abstract class EntityConnector<TEntity> : BaseConnector where TEntity : class
    {
        protected Dictionary<string, string> ParametersInjection { get; set; } //TODO: Remove, temporary workaround

        protected async Task<TEntity> BaseCreate(TEntity entity)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = Array.Empty<string>(),
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Post,
            };
            ParametersInjection = null;

            var wrappedEntity = new EntityWrapper<TEntity>() {Entity = entity};
            var result = await DoEntityRequest(wrappedEntity).ConfigureAwait(false);
            return result?.Entity;
        }

        protected async Task<TEntity> BaseUpdate(TEntity entity, params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Put,
            };
            ParametersInjection = null;

            var wrappedEntity = new EntityWrapper<TEntity>() { Entity = entity };

            var result = await DoEntityRequest(wrappedEntity).ConfigureAwait(false);
            return result?.Entity;
        }

        protected async Task BaseDelete(params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Delete
            };
            ParametersInjection = null;

            await DoRequest().ConfigureAwait(false);
        }

        protected async Task<TEntity> BaseGet(params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Get,
            };
            ParametersInjection = null;

            var result = await DoEntityRequest<EntityWrapper<TEntity>>().ConfigureAwait(false);
            return result?.Entity;
        }
        
        protected TEntity DoAction(string documentNumber, Action action)
        {
            return DoActionAsync(documentNumber, action).Result;
        }

        protected byte[] DoDownloadAction(string documentNumber, Action action, string localPath = null)
        {
            return DoDownloadActionAsync(documentNumber, action, localPath).Result;
        }

        protected async Task<byte[]> DoDownloadActionAsync(string documentNumber, Action action, string localPath = null)
        {
            if (!action.IsDownloadAction())
                throw new Exception("Invalid action type");

            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new[] { documentNumber, action.GetStringValue() },
                Method = HttpMethod.Get,
            };

            var data = await DoSimpleRequest().ConfigureAwait(false);
            if (localPath != null)
                await data.ToFile(localPath).ConfigureAwait(false);
            return data;
        }

        protected async Task<TEntity> DoActionAsync(string documentNumber, Action action)
        {
            if (action.IsDownloadAction())
                throw new Exception("Invalid action type");

            RequestInfo = new RequestInfo
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new[] {documentNumber, action.GetStringValue()},
                Method = action.GetMethod()
            };

            var result = await DoEntityRequest<EntityWrapper<TEntity>>().ConfigureAwait(false);
            return result?.Entity;
        }
    }
}
