using System;
using System.Collections.Generic;
using System.IO;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    public interface IArchiveConnector : IConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Archive? SortBy { get; set; }
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
