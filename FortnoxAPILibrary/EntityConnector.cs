using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;
using FortnoxAPILibrary.Requests;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public abstract class EntityConnector<TEntity> : BaseConnector where TEntity : class
    {
        protected Dictionary<string, string> ParametersInjection { get; set; } //TODO: Remove, temporary workaround

        protected async Task<T> SendAsync<T>(EntityRequest<T> fortnoxRequest)
        {
            var requestJson = fortnoxRequest.Entity == null ? string.Empty : Serializer.Serialize(fortnoxRequest.Entity);
            fortnoxRequest.Content = Encoding.UTF8.GetBytes(requestJson);

            var responseData = await SendAsync((BaseRequest) fortnoxRequest).ConfigureAwait(false);
            var responseJson = Encoding.UTF8.GetString(responseData);

            return Serializer.Deserialize<T>(responseJson);
        }

        protected async Task<TEntity> BaseCreate(TEntity entity)
        {
            var request = new EntityRequest<EntityWrapper<TEntity>>()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = Array.Empty<string>(),
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Post,
                Entity = new EntityWrapper<TEntity>() { Entity = entity }
            };
            ParametersInjection = null;

            var result = await SendAsync(request).ConfigureAwait(false);
            return result?.Entity;
        }

        protected async Task<TEntity> BaseUpdate(TEntity entity, params string[] indices)
        {
            var request = new EntityRequest<EntityWrapper<TEntity>>()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Put,
                Entity = new EntityWrapper<TEntity>() { Entity = entity }
            };
            ParametersInjection = null;

            var result = await SendAsync(request).ConfigureAwait(false);
            return result?.Entity;
        }

        protected async Task BaseDelete(params string[] indices)
        {
            var request = new BaseRequest()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Delete
            };
            ParametersInjection = null;

            await SendAsync(request).ConfigureAwait(false);
        }

        protected async Task<TEntity> BaseGet(params string[] indices)
        {
            var request = new EntityRequest<EntityWrapper<TEntity>>()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Get,
            };
            ParametersInjection = null;

            var result = await SendAsync(request).ConfigureAwait(false);
            return result?.Entity;
        }
        
        protected async Task<byte[]> DoDownloadActionAsync(string documentNumber, Action action, string localPath = null)
        {
            if (!action.IsDownloadAction())
                throw new Exception("Invalid action type");

            var request = new BaseRequest()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new[] { documentNumber, action.GetStringValue() },
                Method = HttpMethod.Get,
            };

            var data = await SendAsync(request).ConfigureAwait(false);
            if (localPath != null)
                await data.ToFile(localPath).ConfigureAwait(false);
            return data;
        }

        protected async Task<TEntity> DoActionAsync(string documentNumber, Action action)
        {
            if (action.IsDownloadAction())
                throw new Exception("Invalid action type");

            var request = new EntityRequest<EntityWrapper<TEntity>>()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new[] {documentNumber, action.GetStringValue()},
                Method = action.GetMethod()
            };

            var result = await SendAsync(request).ConfigureAwait(false);
            return result?.Entity;
        }
    }
}
