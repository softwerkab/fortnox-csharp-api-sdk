using System;
using System.Collections.Generic;
using System.IO;
using FortnoxAPILibrary.Entities;
using Microsoft.AspNetCore.StaticFiles;
using File = FortnoxAPILibrary.Entities.File;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class ArchiveConnector : EntityConnector<Folder, EntityWrapper<Folder>, Sort.By.Folder?>
	{
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		public string FolderId { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		public string Id { get; set; }

		/// <remarks/>
		public ArchiveConnector()
		{
			Resource = "archive";
		}

		/// <summary>
		/// Use this to set what folder to read from. 
		/// </summary>
		public enum RootFolder
		{
			/// <remarks/>
			[StringValue("")]
			Root,
			/// <remarks/>
			[StringValue("inbox")]
			Inbox,
			/// <remarks/>
			[StringValue("inbox_v")]
			Inbox_Vouchers,
			/// <remarks/>
			[StringValue("inbox_s")]
			Inbox_SupplierInvoices

		}

		/// <summary>
		/// Gets a list of Files and Folders
		/// </summary>
		/// <returns>A list of Files and Folders</returns>
		public Folder Find(RootFolder rootFolder = RootFolder.Root)
        {
            Parameters = new Dictionary<string, string>();

			if (rootFolder == RootFolder.Root)
			{
				if (!string.IsNullOrWhiteSpace(Path))
				{
					Parameters.Add("path", Path);
				}

				if (!string.IsNullOrWhiteSpace(FolderId))
				{
					Resource = "archive/" + FolderId;
				}
				else if (!string.IsNullOrWhiteSpace(Id))
				{
					Resource = "archive/" + Id;
				}
			}
            else
            {
                Resource = "archive/" + rootFolder.GetStringValue();
            }
			
			return BaseFind(Parameters)?.Entity;
		}

        /// <summary>
		/// Creates a folder.
		/// </summary>
		/// <param name="folder">The folder entity to create</param>
		/// <param name="destination">the id or path to the parent folder to create the folder in.</param>
		/// <returns>The created folder.</returns>
		public Folder CreateFolder(Folder folder, string destination = "")
		{
			Resource = "archive";

			var parameters = new Dictionary<string, string>();

			if (!string.IsNullOrWhiteSpace(destination))
			{
                if (IsFolderId(destination))
                    parameters.Add("folderid", destination);
                else
                    parameters.Add("path", destination);
            }

			return BaseCreate(folder, parameters);
		}
        
        ///<summary>
		///Uploads a file to Fortnox
		///</summary>
		///<param name="localPath">The local path to the file to upload</param>
		///<param name="folderId">The folderId in Fortnox archive to save the file</param>
		///<returns>Information of the uploaded file</returns>
		public File UploadFile(string localPath, string folderId = "")
        {
            Resource = "archive";

			return BaseUploadFile(localPath, folderId);
		}

		/// <summary>
		/// Uploads a file to Fortnox Archive from provided data array.
		/// </summary>
		/// <returns>Created file.</returns>
		public File UploadFileData(byte[] data, string name, string folderId = "")
		{
			if (data == null) throw new ArgumentException("File data must be set.");

			if (string.IsNullOrEmpty(name)) throw new ArgumentException("File name must be set.");

			if (!System.IO.Path.HasExtension(name)) throw new ArgumentException("File name with extention must be set.");

			Resource = "archive";

			var uploadedFile = BaseUploadFile("", folderId, data, name);
            if (uploadedFile == null) return null;

            uploadedFile.ContentType = GetMimeType(name);

			uploadedFile.Data = new byte[data.Length];

			data.CopyTo(uploadedFile.Data, 0);

			return uploadedFile;
		}

		/// <summary>
		/// Uploads a file to Fortnox Archive from provided data stream.
		/// </summary>
		/// <returns>Created file.</returns>
		public File UploadFileData(Stream stream, string name, string folderId = "")
		{
			stream.Position = 0;
			var arr = new byte[stream.Length];
			stream.Read(arr, 0, (int)stream.Length);
			return UploadFileData(arr, name, folderId);
		}

		/// <summary>
		/// Downloads a file fron Fortnox Archive
		/// </summary>
		/// <param name="fileIdOrFilePath">The id or path of the file to download</param>
		/// <param name="localPath">The local path to save the file to </param>
		public void DownloadFile(string fileIdOrFilePath, string localPath)
        {
            Resource = "archive";

			base.DownloadFile(fileIdOrFilePath, localPath);
		}

		/// <summary>
		/// Downloads actual file data from Fortnox Archive into existing file object. Please note that the file object needs a valid file id.
		/// </summary>
		/// <param name="file">File object to be injected with file data.</param>
		public void DownloadFileData(File file)
		{
			if (file == null)
			{
				throw new ArgumentException("File must be set.");
			}

			if (string.IsNullOrEmpty(file.Id))
			{
				throw new ArgumentException("File id must be set.");
			}

			Resource = "archive";

			DownloadFile(file.Id, "", file);
		}

		/// <summary>
		/// Moves a file from one folder to another folder. 
		/// </summary>
		/// <param name="fileId">The id of the file to be moved</param>
		/// <param name="destination">The id or path to the folder to move the file to.</param>
		/// <returns>Information about the file. </returns>
		public new File MoveFile(string fileId, string destination)
        {
            Resource = "archive";

			return base.MoveFile(fileId, destination);
		}

		/// <summary>
		/// Deletes a file from Fortnox Archive.
		/// </summary>
		/// <param name="fileId">The id of the file to be deleted.</param>
		public void DeleteFile(string fileId)
		{
			BaseDelete(fileId);
		}

		/// <summary>
		/// Deletes a folder and all its content from Fortnox Archive.
		/// </summary>
		/// <param name="folderId">The id of the folder to be deleted.</param>
		public void DeleteFolder(string folderId)
		{
			BaseDelete(folderId);
		}

        private static string GetMimeType(string name)
        {
            var contentTypeProvider = new FileExtensionContentTypeProvider();
            var typeKnown = contentTypeProvider.TryGetContentType(name, out var contentType);
            return typeKnown ? contentType : "application/octet-stream";
        }

        private static bool IsFolderId(string destination)
        {
            return Guid.TryParse(destination, out var unused);
        }

        private File BaseUploadFile(string localPath, string folderId, byte[] fileData = null, string fileName = null)
        {
            RequestUriString = GetUrl();

            if (!string.IsNullOrWhiteSpace(folderId))
            {
                RequestUriString += "?folderid=" + Uri.EscapeDataString(folderId);
            }

            return UploadFile<File>(localPath, fileData, fileName);
        }
    }
}
