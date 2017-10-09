using System.Collections.Generic;
using System;
using System.Reflection;

namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class ArchiveConnector : EntityConnector<Folder, Folder, Sort.By.Folder>
	{
		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		public string FolderId { get; set; }

		///// <summary>
		///// Use with Find() to limit the search result
		///// </summary>
		//public string Destination { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		public string Id { get; set; }

		/// <remarks/>
		public ArchiveConnector()
		{
			base.Resource = "archive";
		}

		/// <summary>
		/// Use this to set what folder to read from. 
		/// </summary>
		public enum RootFolder
		{
			/// <remarks/>
			[RealValue("")]
			Root,
			/// <remarks/>
			[RealValue("inbox")]
			Inbox,
			/// <remarks/>
			[RealValue("inbox_v")]
			Inbox_Vouchers,
			/// <remarks/>
			[RealValue("inbox_s")]
			Inbox_SupplierInvoices

		}


		/// <summary>
		/// Gets at list of Files and Folders
		/// </summary>
		/// <returns>A list of Files and Folders</returns>
		public Folder Find(RootFolder rootFolder = RootFolder.Root)
		{
            this.Parameters = new Dictionary<string, string>();

			if (rootFolder == RootFolder.Root)
			{
				if (!string.IsNullOrWhiteSpace(Path))
				{
					this.Parameters.Add("path", this.Path);
				}

				if (!string.IsNullOrWhiteSpace(FolderId))
				{
					base.Resource += "/" + FolderId;
				}
				else if (!string.IsNullOrWhiteSpace(Id))
				{
					base.Resource += "/" + Id;
				}
			}
			else if (rootFolder == RootFolder.Inbox)
			{
				base.Resource = "archive/" + GetRealValueFromAttribute(RootFolder.Inbox);
			}
			else if (rootFolder == RootFolder.Inbox_SupplierInvoices)
			{
				base.Resource = "archive/" + GetRealValueFromAttribute(RootFolder.Inbox_SupplierInvoices);
			}
			else if (rootFolder == RootFolder.Inbox_Vouchers)
			{
				base.Resource = "archive/" + GetRealValueFromAttribute(RootFolder.Inbox_Vouchers);	
			}
			
			return base.BaseFind(this.Parameters);
		}

		private static string GetRealValueFromAttribute(RootFolder f)
		{
			string resource = "";

			Type type = f.GetType();
			MemberInfo[] memInfo = type.GetMember(f.ToString());
			object[] attrs = memInfo[0].GetCustomAttributes(typeof(RealValueAttribute), false);
			if (attrs.Length > 0)
			{
				resource = ((RealValueAttribute)attrs[0]).RealValue;
			}
			return resource;
		}

		///<summary>
		///Uploads a file to Fortnox
		///</summary>
		///<param name="localPath">The local path to the file to upload</param>
		///<param name="folderId">The folderId in Fortnox archive to save the file</param>
		///<returns>Information of the uploaded file</returns>
		public File UploadFile(string localPath, string folderId = "")
        {
            base.Resource = "archive";

			return base.BaseUploadFile(localPath, folderId);
		}

		/// <summary>
		/// Downloads a file fron Fortnox Archive
		/// </summary>
		/// <param name="fileIdOrFilePath">The id or path of the file to download</param>
		/// <param name="localPath">The local path to save the file to </param>
		public new void DownloadFile(string fileIdOrFilePath, string localPath)
        {
            base.Resource = "archive";

			base.DownloadFile(fileIdOrFilePath, localPath);
		}

		/// <summary>
		/// Moves a file from one folder to another folder. 
		/// </summary>
		/// <param name="fileId">The id of the file to be moved</param>
		/// <param name="destination">The id or path to the folder to move the file to.</param>
		/// <returns>Information about the file. </returns>
		public new File MoveFile(string fileId, string destination)
        {
            base.Resource = "archive";

			return base.MoveFile(fileId, destination);
		}

        /// <summary>
        /// Creates a folder.
        /// </summary>
        /// <param name="folder">The folder entity to create</param>
        /// <param name="destination">he id or path to the parent folder to create the folder in.</param>
        /// <returns>The created folder.</returns>
        public Folder CreateFolder(Folder folder, string destination = "")
        {
            base.Resource = "archive";

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            if (!String.IsNullOrWhiteSpace(destination))
            {
                Guid test = new Guid();
                if (Guid.TryParse(destination, out test))
                {
                    parameters.Add("folderid", destination);
                }
                else
                {
                    parameters.Add("path", destination);
                }
            }

            return base.BaseCreate(folder, parameters);
        }

		/// <summary>
		/// Deletes a file from Fortnox Archive.
		/// </summary>
		/// <param name="fileId">The id of the file to be deleted.</param>
		public void DeleteFile(string fileId)
		{
			base.BaseDelete(fileId);
		}

		/// <summary>
		/// Deletes a folder and all its content from Fortnox Archive.
		/// </summary>
		/// <param name="folderId">The id of the folder to be deleted.</param>
		public void DeleteFolder(string folderId)
		{
			base.BaseDelete(folderId);
		}

	}
}
