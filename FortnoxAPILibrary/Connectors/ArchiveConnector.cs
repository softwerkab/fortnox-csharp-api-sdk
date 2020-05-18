using System;
using System.Collections.Generic;
using System.IO;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class ArchiveConnector : EntityConnector<ArchiveFolder, EntityWrapper<ArchiveFolder>, Sort.By.Archive?>, IArchiveConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Archive? FilterBy { get; set; }

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
        /// <returns>The found file</returns>
        public byte[] DownloadFile(string id)
        {
            return DownloadFileAsync(id).Result;
        }

        /// <summary>
        /// Downloads the specified file and saves it to a provided location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="localPath"></param>
        /// <returns></returns>
        public FileInfo DownloadFile(string id, string localPath)
        {
            return DownloadFileAsync(id, localPath).Result;
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
            return UploadFileAsync(name, data, folderPathOrId).Result;
        }

        public ArchiveFile UploadFile(string name, Stream stream, string folderPathOrId = null)
        {
            return UploadFileAsync(name, stream, folderPathOrId).Result;
        }

        public ArchiveFile UploadFile(string localPath, string folderPathOrId = null)
        {
            return UploadFileAsync(localPath, folderPathOrId).Result;
        }

        /// <summary>
		/// Deletes a file
		/// Note: If the specified id belongs to a folder, the folder will be deleted instead!
		/// </summary>
		/// <param name="id">Id of the file delete</param>
        public void DeleteFile(string id)
		{
            DeleteFileAsync(id).Wait();
        }

        /// <summary>
        /// Retrieves a folder. If no path or id is specified, root folder will be retrieved
        /// </summary>
        /// <param name="pathOrId"></param>
        /// <returns></returns>
        public ArchiveFolder GetFolder(string pathOrId = null)
        {
            return GetFolderAsync(pathOrId).Result;
        }

        /// <summary>
        /// Retrieves the root folder.
        /// </summary>
        /// <returns></returns>
        public ArchiveFolder GetRoot()
        {
            return GetRootAsync().Result;
        }

        /// <summary>
        /// Creates a folder
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public ArchiveFolder CreateFolder(string folderName, string path = null)
        {
            return CreateFolderAsync(folderName, path).Result;
        }

        /// <summary>
        /// Deletes a folder
        /// </summary>
        /// <param name="pathOrId">Id or path of the folder to delete</param>
        public void DeleteFolder(string pathOrId)
        {
            DeleteFolderAsync(pathOrId).Wait();
        }

        #endregion SYNC Interface Methods

        #region ASYNC Interface Methods

        public async Task<byte[]> DownloadFileAsync(string id)
        {
            return await BaseDownload(null, id);
        }

        public async Task<FileInfo> DownloadFileAsync(string id, string localPath)
        {
            var data = await DownloadFileAsync(id);
            return await data.ToFile(localPath);
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

            return await BaseUpload(name, data, urlParams);
        }

        public async Task<ArchiveFile> UploadFileAsync(string name, Stream stream, string folderPathOrId = null)
        {
            return await UploadFileAsync(name, await stream.ToBytes(), folderPathOrId);
        }

        public async Task<ArchiveFile> UploadFileAsync(string localPath, string folderPathOrId = null)
        {
            var fileInfo = new FileInfo(localPath);
            return await UploadFileAsync(fileInfo.Name, fileInfo.ToBytes().Result, folderPathOrId);
        }

        public async Task DeleteFileAsync(string id)
        {
            await BaseDelete(id);
        }

        public async Task<ArchiveFolder> GetFolderAsync(string pathOrId = null)
        {
            if (string.IsNullOrEmpty(pathOrId))
                pathOrId = "root";

            if (IsArchiveId(pathOrId) || IsPredefinedFolder(pathOrId))
                return await BaseGet(pathOrId);
            else
            {
                ParametersInjection = new Dictionary<string, string>();
                ParametersInjection.Add("path", pathOrId);
                return await BaseGet();
            }
        }

        public async Task<ArchiveFolder> GetRootAsync()
        {
            return await GetFolderAsync();
        }

        public async Task<ArchiveFolder> CreateFolderAsync(string folderName, string path = null)
        {
            var folder = new ArchiveFolder() { Name = folderName };

            if (path != null)
                ParametersInjection = new Dictionary<string, string> { { "path", path } };

            return await BaseCreate(folder);
        }

        public async Task DeleteFolderAsync(string pathOrId)
        {
            if (IsArchiveId(pathOrId))
                await BaseDelete(pathOrId);
            else
            {
                ParametersInjection = new Dictionary<string, string> { { "path", pathOrId } };
                await BaseDelete();
            }
        }

        #endregion ASYNC Interface Methods

        private async Task<ArchiveFile> BaseUpload(string name, byte[] data, Dictionary<string, string> parameters, params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                Parameters = parameters ?? new Dictionary<string, string>(),
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices
            };

            return await UploadFile<ArchiveFile>(data, name);
        }

        private async Task<byte[]> BaseDownload(Dictionary<string, string> parameters, params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                Parameters = parameters ?? new Dictionary<string, string>(),
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices
            };

            return await DownloadFile();
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
