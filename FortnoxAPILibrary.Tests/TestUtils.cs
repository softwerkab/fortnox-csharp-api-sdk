using System.IO;

namespace FortnoxAPILibrary.Tests
{
    public class TestUtils
    {
        public static string GetTempFilePath()
        {
            var path = Path.GetTempFileName(); //Creates empty file in temp dir
            File.Delete(path); //Deletes the file (only the path is needed)
            return path;
        }
    }
}
