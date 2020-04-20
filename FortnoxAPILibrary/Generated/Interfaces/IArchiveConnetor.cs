using System;
using System.Collections.Generic;
using System.IO;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public interface IArchiveConnector
	{
        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
        Filter.Archive? FilterBy { get; set; }

        byte[] DownloadFile(string id);
        void DownloadFile(string id, string localPath);

        ArchiveFile UploadFile(string name, byte[] data, string folderPathOrId = null);
        ArchiveFile UploadFile(string name, Stream stream, string folderPathOrId = null);
        ArchiveFile UploadFile(string localPath, string folderPathOrId = null);

        void DeleteFile(string id);

        ArchiveFolder GetFolder(string pathOrId = null);
        ArchiveFolder GetRoot();
        ArchiveFolder CreateFolder(string folderName, string path = null);
        void DeleteFolder(string pathOrId);
    }
}
