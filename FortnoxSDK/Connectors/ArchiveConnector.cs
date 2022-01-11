using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fortnox.SDK.Connectors.Base;
using Fortnox.SDK.Entities;
using Fortnox.SDK.Interfaces;
using Fortnox.SDK.Requests;
using Fortnox.SDK.Utility;

namespace Fortnox.SDK.Connectors;

internal class ArchiveConnector : EntityConnector<ArchiveFolder>, IArchiveConnector
{
    public ArchiveConnector()
    {
        Endpoint = Endpoints.Archive;
    }

    #region Interface Methods

    public async Task<byte[]> DownloadFileAsync(string id, IdType idType = IdType.Id)
    {
        if (idType == IdType.Id)
            return await BaseDownload(null, id).ConfigureAwait(false);
        else
        {
            var parameters = new Dictionary<string, string>() { { "fileid", id } };
            return await BaseDownload(parameters).ConfigureAwait(false);
        }
    }

    public async Task<FileInfo> DownloadFileAsync(string id, string localPath, IdType idType = IdType.Id)
    {
        var data = await DownloadFileAsync(id, idType).ConfigureAwait(false);
        return await data.ToFile(localPath).ConfigureAwait(false);
    }

    public async Task<ArchiveFile> UploadFileAsync(string name, byte[] data, string folderPathOrId = null)
    {
        if (data == null)
            throw new ArgumentException("File data must be set.");

        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("File name must be set.");

        if (!Path.HasExtension(name))
            throw new ArgumentException("File name with extention must be set.");

        if (string.IsNullOrEmpty(folderPathOrId))
            folderPathOrId = "root";

        var urlParams = new Dictionary<string, string>();

        if (IsArchiveId(folderPathOrId) || IsPredefinedFolder(folderPathOrId))
            urlParams.Add("folderid", folderPathOrId);
        else
            urlParams.Add("path", folderPathOrId);

        return await BaseUpload(name, data, urlParams).ConfigureAwait(false);
    }

    public async Task<ArchiveFile> UploadFileAsync(string name, Stream stream, string folderPathOrId = null)
    {
        return await UploadFileAsync(name, await stream.ToBytes(), folderPathOrId).ConfigureAwait(false);
    }

    public async Task<ArchiveFile> UploadFileAsync(string localPath, string folderPathOrId = null)
    {
        var fileInfo = new FileInfo(localPath);
        return await UploadFileAsync(fileInfo.Name, fileInfo.ToBytes().GetResult(), folderPathOrId).ConfigureAwait(false);
    }

    public async Task DeleteFileAsync(string id)
    {
        await BaseDelete(id).ConfigureAwait(false);
    }

    public async Task<ArchiveFolder> GetFolderAsync(string pathOrId = null)
    {
        if (string.IsNullOrEmpty(pathOrId))
            pathOrId = "root";

        var request = new EntityRequest<ArchiveFolder>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Get,
        };

        if (IsArchiveId(pathOrId) || IsPredefinedFolder(pathOrId))
            request.Indices.Add(pathOrId);
        else
            request.Parameters.Add("path", pathOrId);

        return await SendAsync(request).ConfigureAwait(false);
    }

    public async Task<ArchiveFolder> GetRootAsync()
    {
        return await GetFolderAsync().ConfigureAwait(false);
    }

    public async Task<ArchiveFolder> CreateFolderAsync(string folderName, string path = null)
    {
        var folder = new ArchiveFolder() { Name = folderName };

        var request = new EntityRequest<ArchiveFolder>()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Post,
            Entity = folder
        };

        if (path != null)
            request.Parameters.Add("path", path);

        return await SendAsync(request).ConfigureAwait(false);
    }

    public async Task DeleteFolderAsync(string pathOrId)
    {
        var request = new BaseRequest()
        {
            Endpoint = Endpoint,
            Method = HttpMethod.Delete
        };

        if (!IsArchiveId(pathOrId))
            request.Parameters.Add("path", pathOrId);

        await SendAsync(request).ConfigureAwait(false);
    }

    #endregion Interface Methods

    private async Task<ArchiveFile> BaseUpload(string name, byte[] data, Dictionary<string, string> parameters, params string[] indices)
    {
        var request = new FileUploadRequest()
        {
            Parameters = parameters ?? new Dictionary<string, string>(),
            Endpoint = Endpoint,
            Indices = indices.ToList(),
            FileData = data,
            FileName = name
        };

        var responseData = await SendAsync(request).ConfigureAwait(false);
        var responseJson = Encoding.UTF8.GetString(responseData);

        return Serializer.Deserialize<EntityWrapper<ArchiveFile>>(responseJson).Entity;
    }

    private async Task<byte[]> BaseDownload(Dictionary<string, string> parameters, params string[] indices)
    {
        var request = new FileDownloadRequest()
        {
            Parameters = parameters ?? new Dictionary<string, string>(),
            Endpoint = Endpoint,
            Indices = indices.ToList()
        };

        return await SendAsync(request).ConfigureAwait(false);
    }

    private static bool IsArchiveId(string str)
    {
        return Guid.TryParse(str, out _);
    }

    private static bool IsPredefinedFolder(string str)
    {
        switch (str)
        {
            case StaticFolders.Root:
            case StaticFolders.AssetRegister:
            case StaticFolders.DailyTakings:
            case StaticFolders.SupplierInvoices:
            case StaticFolders.Vouchers:
            case StaticFolders.BankFiles:
            case StaticFolders.Salary:
            case StaticFolders.CustomerInvoices:
            case StaticFolders.Orders:
            case StaticFolders.Offers:
                return true;
            default:
                return false;
        }
    }
}