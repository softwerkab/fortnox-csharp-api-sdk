using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

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
            File.WriteAllBytes(localPath, DownloadFile(id));
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

            var urlParams = new Dictionary<string, string>();
            if (folderPathOrId != null)
            {
                if (IsArchiveId(folderPathOrId))
                    urlParams.Add("folderId", folderPathOrId);
				else
                    urlParams.Add("path", folderPathOrId);
            }

            return BaseUpload(name, data, urlParams);
        }

        public ArchiveFile UploadFile(string name, Stream stream, string folderPathOrId = null)
        {
            return UploadFile(name, stream.ToBytes(), folderPathOrId);
        }

        public ArchiveFile UploadFile(string localPath, string folderPathOrId = null)
        {
            return UploadFile(Path.GetFileName(localPath), System.IO.File.ReadAllBytes(localPath), folderPathOrId);
        }

        /// <summary>
		/// Deletes a file
		/// Note: If the specified id belongs to a folder, the folder will be deleted instead!
		/// </summary>
		/// <param name="id">Id of the file delete</param>
        public void DeleteFile(string id)
		{
            BaseDelete(id);
        }

        /// <summary>
        /// Retrieves a folder. If no path or id is specified, root folder will be retrieved
        /// </summary>
        /// <param name="pathOrId"></param>
        /// <returns></returns>
        public ArchiveFolder GetFolder(string pathOrId = null)
        {
            if (IsArchiveId(pathOrId))
                return BaseGet(pathOrId);
            else
            {
                BaseGetParametersInjection = new Dictionary<string, string>();
                BaseGetParametersInjection.Add("path", pathOrId);
                return BaseGet();
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

            var urlParams = new Dictionary<string, string>();
            if (path != null)
                urlParams.Add("path", path);

            return BaseCreate(folder, urlParams);
        }

        /// <summary>
        /// Deletes a folder
        /// </summary>
        /// <param name="pathOrId">Id or path of the folder to delete</param>
        public void DeleteFolder(string pathOrId)
        {
            if (IsArchiveId(pathOrId))
                BaseDelete(pathOrId);
            else
            {
                BaseDeleteParametersInjection = new Dictionary<string, string>();
                BaseDeleteParametersInjection.Add("path", pathOrId);
                BaseDelete();
            }
        }

        private ArchiveFile BaseUpload(string name, byte[] data, Dictionary<string, string> parameters, params string[] indices)
        {
            Parameters = parameters ?? new Dictionary<string, string>();

            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));
            var requestUriString = GetUrl(searchValue);
            requestUriString = AddParameters(requestUriString);

            RequestUriString = requestUriString;

            return UploadFile<ArchiveFile>(data, name);
        }

        private byte[] BaseDownload(Dictionary<string, string> parameters, params string[] indices)
        {
            Parameters = parameters ?? new Dictionary<string, string>();

            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));
            var requestUriString = GetUrl(searchValue);
            requestUriString = AddParameters(requestUriString);

            RequestUriString = requestUriString;

            return DownloadFile();
        }

        private static bool IsArchiveId(string str)
        {
            return Guid.TryParse(str, out _);
        }
    }
}
