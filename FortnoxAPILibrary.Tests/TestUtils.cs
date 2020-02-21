using System;
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

        public static string RandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var random = new Random();

            var randomString = new char[length];
            for (var i = 0; i < length; i++)
                randomString[i] = chars[random.Next(chars.Length)];

            return new string(randomString);
        }
    }
}
