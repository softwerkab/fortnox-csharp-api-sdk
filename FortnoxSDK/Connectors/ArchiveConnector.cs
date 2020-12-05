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

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Connectors
{
    /// <remarks/>
    public class ArchiveConnector : EntityConnector<ArchiveFolder>, IArchiveConnector
	{

		/// <remarks/>
		public ArchiveConnector()
		{
			Resource = "archive";
		}

        #region SYNC Interface Methods

        /// <summary>
        /// Downloads the specified file
        /// </summary>
        /// <param name="id">Identifier of the file to download</param>
        /// <param name="idType">Specify type of the provided identifier. Temporary workaround. </param>
        /// <returns>The found file</returns>
        public byte[] DownloadFile(string id, IdType idType = IdType.Id)
        {
            return DownloadFileAsync(id, idType).GetResult();
        }

        /// <summary>
        /// Downloads the specified file and saves it to a provided location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="localPath"></param>
        /// <param name="idType">Specify type of the provided identifier. Temporary workaround.</param>
        /// <returns></returns>
        public FileInfo DownloadFile(string id, string localPath, IdType idType = IdType.Id)
        {
            return DownloadFileAsync(id, localPath, idType).GetResult();
        }

        /// <summary>
		/// Creates a new file
		/// </summary>
		/// <param name="name">File name</param>
		/// <param name="data">File data</param>
        /// <param name="folderPathOrId">Path or id of the folder where file should be located</param>
		/// <returns>The created file</returns>
		public ArchiveFile UploadFile(string name, byte[] data, string folderPathOrId = null)
        {
            return UploadFileAsync(name, data, folderPathOrId).GetResult();
        }

        public ArchiveFile UploadFile(string name, Stream stream, string folderPathOrId = null)
        {
            return UploadFileAsync(name, stream, folderPathOrId).GetResult();
        }

        public ArchiveFile UploadFile(string localPath, string folderPathOrId = null)
        {
            return UploadFileAsync(localPath, folderPathOrId).GetResult();
        }

        /// <summary>
		/// Deletes a file
		/// Note: If the specified id belongs to a folder, the folder will be deleted instead!
		/// </summary>
		/// <param name="id">Id of the file delete</param>
        public void DeleteFile(string id)
		{
            DeleteFileAsync(id).GetResult();
        }

        /// <summary>
        /// Retrieves a folder. If no path or id is specified, root folder will be retrieved
        /// </summary>
        /// <param name="pathOrId"></param>
        /// <returns></returns>
        public ArchiveFolder GetFolder(string pathOrId = null)
        {
            return GetFolderAsync(pathOrId).GetResult();
        }

        /// <summary>
        /// Retrieves the root folder.
        /// </summary>
        /// <returns></returns>
        public ArchiveFolder GetRoot()
        {
            return GetRootAsync().GetResult();
        }

        /// <summary>
        /// Creates a folder
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public ArchiveFolder CreateFolder(string folderName, string path = null)
        {
            return CreateFolderAsync(folderName, path).GetResult();
        }

        /// <summary>
        /// Deletes a folder
        /// </summary>
        /// <param name="pathOrId">Id or path of the folder to delete</param>
        public void DeleteFolder(string pathOrId)
        {
            DeleteFolderAsync(pathOrId).GetResult();
        }

        #endregion SYNC Interface Methods

        #region ASYNC Interface Methods

        public async Task<byte[]> DownloadFileAsync(string id, IdType idType = IdType.Id)
        {
            if (idType == IdType.Id)
                return await BaseDownload(null, id).ConfigureAwait(false);
            else
            {
                var parameters = new Dictionary<string, string>() { {"fileid", id} };
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
                Resource = Resource,
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
                Resource = Resource,
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
                Resource = Resource,
                Method = HttpMethod.Delete
            };

            if (!IsArchiveId(pathOrId))
                request.Parameters.Add("path", pathOrId);

            await SendAsync(request).ConfigureAwait(false);
        }

        #endregion ASYNC Interface Methods

        private async Task<ArchiveFile> BaseUpload(string name, byte[] data, Dictionary<string, string> parameters, params string[] indices)
        {
            var request = new FileUploadRequest()
            {
                Parameters = parameters ?? new Dictionary<string, string>(),
                Resource = Resource,
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
                Resource = Resource,
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

    public class StaticFolders
    {
        public const string Root = "root";
        public const string AssetRegister = "inbox_a";
        public const string DailyTakings = "inbox_d";
        public const string SupplierInvoices = "inbox_s";
        public const string Vouchers = "inbox_v";
        public const string BankFiles = "inbox_b";
        public const string Salary = "inbox_l";
        public const string CustomerInvoices = "inbox_kf";
        public const string Orders = "inbox_o";
        public const string Offers = "inbox_of"; //"quotes"
    }
}
