using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    //TODO: Implement Async methods
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

		/// <summary>
		/// Downloads the specified file
		/// </summary>
		/// <param name="id">Identifier of the file to download</param>
		/// <returns>The found file</returns>
		public byte[] DownloadFile(string id)
		{
            return BaseDownload(null, id);
        }

        public void DownloadFile(string id, string localPath)
        {
            DownloadFile(id).ToFile(localPath).Wait();
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

            return BaseUpload(name, data, urlParams);
        }

        public ArchiveFile UploadFile(string name, Stream stream, string folderPathOrId = null)
        {
            return UploadFile(name, stream.ToBytes().Result, folderPathOrId);
        }

        public ArchiveFile UploadFile(string localPath, string folderPathOrId = null)
        {
            var fileInfo = new FileInfo(localPath);
            return UploadFile(fileInfo.Name, fileInfo.ToBytes().Result, folderPathOrId);
        }

        /// <summary>
		/// Deletes a file
		/// Note: If the specified id belongs to a folder, the folder will be deleted instead!
		/// </summary>
		/// <param name="id">Id of the file delete</param>
        public void DeleteFile(string id)
		{
            BaseDelete(id).Wait();
        }

        /// <summary>
        /// Retrieves a folder. If no path or id is specified, root folder will be retrieved
        /// </summary>
        /// <param name="pathOrId"></param>
        /// <returns></returns>
        public ArchiveFolder GetFolder(string pathOrId = null)
        {
            if (string.IsNullOrEmpty(pathOrId))
                pathOrId = "root";

            if (IsArchiveId(pathOrId) || IsPredefinedFolder(pathOrId))
                return BaseGet(pathOrId).Result;
            else
            {
                ParametersInjection = new Dictionary<string, string>();
                ParametersInjection.Add("path", pathOrId);
                return BaseGet().Result;
            }
        }

        /// <summary>
        /// Retrieves the root folder.
        /// </summary>
        /// <returns></returns>
        public ArchiveFolder GetRoot()
        { 
            return GetFolder();
        }

        public ArchiveFolder CreateFolder(string folderName, string path = null)
        {
            var folder = new ArchiveFolder(){ Name = folderName };

            if (path != null)
                ParametersInjection = new Dictionary<string, string> {{"path", path}};

            return BaseCreate(folder).Result;
        }

        /// <summary>
        /// Deletes a folder
        /// </summary>
        /// <param name="pathOrId">Id or path of the folder to delete</param>
        public void DeleteFolder(string pathOrId)
        {
            if (IsArchiveId(pathOrId))
                BaseDelete(pathOrId).Wait();
            else
            {
                ParametersInjection = new Dictionary<string, string> {{"path", pathOrId}};
                BaseDelete().Wait();
            }
        }

        public Task<byte[]> DownloadFileAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task DownloadFileAsync(string id, string localPath)
        {
            throw new NotImplementedException();
        }

        public Task<ArchiveFile> UploadFileAsync(string name, byte[] data, string folderPathOrId = null)
        {
            throw new NotImplementedException();
        }

        public Task<ArchiveFile> UploadFileAsync(string name, Stream stream, string folderPathOrId = null)
        {
            throw new NotImplementedException();
        }

        public Task<ArchiveFile> UploadFileAsync(string localPath, string folderPathOrId = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFileAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ArchiveFolder> GetFolderAsync(string pathOrId = null)
        {
            throw new NotImplementedException();
        }

        public Task<ArchiveFolder> GetRootAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ArchiveFolder> CreateFolderAsync(string folderName, string path = null)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFolderAsync(string pathOrId)
        {
            throw new NotImplementedException();
        }

        private ArchiveFile BaseUpload(string name, byte[] data, Dictionary<string, string> parameters, params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                Parameters = parameters ?? new Dictionary<string, string>(),
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices
            };

            return UploadFile<ArchiveFile>(data, name).Result;
        }

        private byte[] BaseDownload(Dictionary<string, string> parameters, params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                Parameters = parameters ?? new Dictionary<string, string>(),
                BaseUrl = BaseUrl,
                Resource = Resource,
                //SearchParameters = GetSearchParameters(),
                Indices = indices
            };

            return DownloadFile().Result;
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
