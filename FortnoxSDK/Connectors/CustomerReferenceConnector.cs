using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Exceptions;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Search;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class CustomerReferenceConnector : EntityConnector<CustomerReferenceRow>, ICustomerReferenceConnector
{
    public CustomerReferenceConnector()
    {
        Endpoint = Endpoints.CustomerReferences;
    }

    public async Task<IList<CustomerReferenceRow>> FindAsync(CustomerReferenceSearch searchSettings)
    {
        if (searchSettings?.Limit == ApiConstants.Unlimited)
            return await GetAllInOnePage(searchSettings);
        else
            return await GetSinglePage(searchSettings);
    }

    private async Task<IList<CustomerReferenceRow>> GetAllInOnePage(CustomerReferenceSearch searchSettings)
    {
        searchSettings = Clone(searchSettings);
        searchSettings.Limit = ApiConstants.MaxLimit;
        searchSettings.Page = 1;

        var all = new List<CustomerReferenceRow>();
        while (true)
        {
            var page = await GetSinglePage(searchSettings);
            if (!page.Any())
                break;

            all.AddRange(page);
            searchSettings.Page++;
        }

        return all;
    }

    private async Task<IList<CustomerReferenceRow>> GetSinglePage(CustomerReferenceSearch searchSettings)
    {
        var request = new EntityRequest<CustomerReference>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Get,
        };

        request.Parameters.AddRange(searchSettings?.GetSearchParameters());

        var customerReference = await SendAsync(request).ConfigureAwait(false);
        
        return customerReference.CustomerReferenceRows;
    }

    //Duplicated from SearchableEntityConnector
    private static T Clone<T>(T obj) where T : BaseSearch
    {
        var memberwiseClone = obj?.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
        return (T) memberwiseClone?.Invoke(obj, null);
    }

    public async Task<CustomerReferenceRow> GetAsync(long? id)
    {
        var request = new EntityRequest<CustomerReferenceRow>()
        {
            Endpoint = Endpoint,
            Indices = new[] { id.ToString() },
            Method = HttpMethod.Get,
        };

        if (request.Entity != null)
        {
            var requestJson = request.UseEntityWrapper
                ? Serializer.Serialize(new EntityWrapper<CustomerReferenceRow>(request.Entity))
                : Serializer.Serialize(request.Entity);
            request.Content = Encoding.UTF8.GetBytes(requestJson);
        }

        var responseData = await SendAsync((BaseRequest) request).ConfigureAwait(false);
        var responseJson = Encoding.UTF8.GetString(responseData);

        var customerReference = request.UseEntityWrapper
            ? Serializer.Deserialize<EntityWrapper<CustomerReference>>(responseJson).Entity
            : Serializer.Deserialize<CustomerReference>(responseJson);

        if (!customerReference.CustomerReferenceRows.Any())
            throw new FortnoxApiException($"Customer reference '{id}' does not exists.");

        return customerReference.CustomerReferenceRows.Single();
    }

    public async Task<CustomerReferenceRow> CreateAsync(CustomerReferenceRow customerReferenceRow)
    {
        var request = new EntityRequest<CustomerReferenceRow>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Post,
            Entity = customerReferenceRow
        };

        if (request.Entity != null)
        {
            var requestJson = request.UseEntityWrapper
                ? Serializer.Serialize(new EntityWrapper<CustomerReferenceRow>(request.Entity))
                : Serializer.Serialize(request.Entity);
            request.Content = Encoding.UTF8.GetBytes(requestJson);
        }

        var responseData = await SendAsync((BaseRequest) request).ConfigureAwait(false);
        var responseJson = Encoding.UTF8.GetString(responseData);

        var customerReference =  request.UseEntityWrapper
            ? Serializer.Deserialize<EntityWrapper<CustomerReference>>(responseJson).Entity
            : Serializer.Deserialize<CustomerReference>(responseJson);

        return customerReference.CustomerReferenceRows.Last();
    }

    public async Task<CustomerReferenceRow> UpdateAsync(CustomerReferenceRow customerReferenceRow)
    {
        var request = new EntityRequest<CustomerReferenceRow>()
        {
            Endpoint = Endpoint,
            Indices = new[] { customerReferenceRow.Id.ToString() },
            Method = HttpMethod.Put,
            Entity = customerReferenceRow
        };

        if (request.Entity != null)
        {
            var requestJson = request.UseEntityWrapper
                ? Serializer.Serialize(new EntityWrapper<CustomerReferenceRow>(request.Entity))
                : Serializer.Serialize(request.Entity);
            request.Content = Encoding.UTF8.GetBytes(requestJson);
        }

        var responseData = await SendAsync((BaseRequest) request).ConfigureAwait(false);
        var responseJson = Encoding.UTF8.GetString(responseData);

        var customerReference = request.UseEntityWrapper
            ? Serializer.Deserialize<EntityWrapper<CustomerReference>>(responseJson).Entity
            : Serializer.Deserialize<CustomerReference>(responseJson);

        return customerReference.CustomerReferenceRows.Single();
    }

    public async Task DeleteAsync(long? id)
    {
        await BaseDelete(id.ToString()).ConfigureAwait(false);
    }
}
