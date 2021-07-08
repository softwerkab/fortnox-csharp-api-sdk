namespace Fortnox.SDK.Requests
{
    internal class FileUploadRequest : BaseRequest
    {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
    }
}