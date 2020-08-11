using System.IO;
using FortnoxAPILibrary.Entities;
using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global
namespace FortnoxAPILibrary.Connectors
{
    public interface IArchiveConnector : IEntityConnector
	{
		Sort.Order? SortOrder { get; set; }
		Sort.By.Archive? SortBy { get; set; }
        Filter.Archive? FilterBy { get; set; }

        byte[] DownloadFile(string id, IdType idType = IdType.Id);
        FileInfo DownloadFile(string id, string localPath, IdType idType = IdType.Id);
        ArchiveFile UploadFile(string name, byte[] data, string folderPathOrId = null);
        ArchiveFile UploadFile(string name, Stream stream, string folderPathOrId = null);
        ArchiveFile UploadFile(string localPath, string folderPathOrId = null);
        void DeleteFile(string id);

        ArchiveFolder GetFolder(string pathOrId = null);
        ArchiveFolder GetRoot();
        ArchiveFolder CreateFolder(string folderName, string path = null);
        void DeleteFolder(string pathOrId);


        Task<byte[]> DownloadFileAsync(string id, IdType idType = IdType.Id);
        Task<FileInfo> DownloadFileAsync(string id, string localPath, IdType idType = IdType.Id);
        Task<ArchiveFile> UploadFileAsync(string name, byte[] data, string folderPathOrId = null);
        Task<ArchiveFile> UploadFileAsync(string name, Stream stream, string folderPathOrId = null);
        Task<ArchiveFile> UploadFileAsync(string localPath, string folderPathOrId = null);
        Task DeleteFileAsync(string id);

        Task<ArchiveFolder> GetFolderAsync(string pathOrId = null);
        Task<ArchiveFolder> GetRootAsync();
        Task<ArchiveFolder> CreateFolderAsync(string folderName, string path = null);
        Task DeleteFolderAsync(string pathOrId);
    }

    public enum IdType
    {
        /// <summary>
        /// Primary file identificator corresponding to "Id" property of ArchiveFile.
        /// </summary>
        Id,
        /// <summary>
        /// Alternative file identificator corresponding to "ArchiveFileId" property of ArchiveFile.
        /// Use when the value was retrieved from InvoiceFileConnection "FileId" property
        /// </summary>
        FileId
    }
}
