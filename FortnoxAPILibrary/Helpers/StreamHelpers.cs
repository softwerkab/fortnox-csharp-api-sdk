using System.IO;

namespace FortnoxAPILibrary.Helpers
{
    public static class StreamHelpers
    {
        public  static Stream ToMemoryStream(this Stream inputStream)
        {
            const int readSize = 256;
            var buffer = new byte[readSize];
            var ms = new MemoryStream();

            var count = inputStream.Read(buffer, 0, readSize);

            while (count > 0)
            {
                ms.Write(buffer, 0, count);
                count = inputStream.Read(buffer, 0, readSize);
            }

            ms.Position = 0;

            inputStream.Close();

            return ms;
        }
    }
}
