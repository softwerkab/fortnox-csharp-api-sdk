using System.IO;
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
        FileInfo DownloadFile(string id, string localPath);
        ArchiveFile UploadFile(string name, byte[] data, string folderPathOrId = null);
        ArchiveFile UploadFile(string name, Stream stream, string folderPathOrId = null);
        ArchiveFile UploadFile(string localPath, string folderPathOrId = null);
        void DeleteFile(string id);

        ArchiveFolder GetFolder(string pathOrId = null);
        ArchiveFolder GetRoot();
        ArchiveFolder CreateFolder(string folderName, string path = null);
        void DeleteFolder(string pathOrId);


        Task<byte[]> DownloadFileAsync(string id);
        Task<FileInfo> DownloadFileAsync(string id, string localPath);
        Task<ArchiveFile> UploadFileAsync(string name, byte[] data, string folderPathOrId = null);
        Task<ArchiveFile> UploadFileAsync(string name, Stream stream, string folderPathOrId = null);
        Task<ArchiveFile> UploadFileAsync(string localPath, string folderPathOrId = null);
        Task DeleteFileAsync(string id);

        Task<ArchiveFolder> GetFolderAsync(string pathOrId = null);
        Task<ArchiveFolder> GetRootAsync();
        Task<ArchiveFolder> CreateFolderAsync(string folderName, string path = null);
        Task DeleteFolderAsync(string pathOrId);
    }
}
