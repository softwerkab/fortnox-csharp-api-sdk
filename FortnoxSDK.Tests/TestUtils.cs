using System;
using System.IO;
using Fortnox.SDK;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Exceptions;

namespace FortnoxSDK.Tests
{
    public class TestUtils
    {
        public static FortnoxAuthorization TestAuth = new StaticTokenAuth(TestCredentials.Access_Token, TestCredentials.Client_Secret);
        public static FortnoxClient DefaultFortnoxClient = new FortnoxClient(TestAuth);

        public static long DefaultFinancialYear = 1;
        public static long NonDefaultFinancialYear = 2;

        public static DateTime Recently => DateTime.UtcNow.AddHours(FortnoxServerHourOffset).AddSeconds(-5); 
        public static TimeSpan TestSleepTime = TimeSpan.FromSeconds(5);

        public static int FortnoxServerHourOffset = IsDST ? 2 : 1; // Fortnox Server is UTC+1 or UTC+2 (in case of DST)
        public static bool IsDST => true; //TODO: Handle Daylight saving time (DST) properly.

        public static string GenerateTmpFilePath()
        {
            var path = Path.GetTempFileName(); //Creates empty file in temp dir
            File.Delete(path); //Deletes the file (only the path is needed)
            return path;
        }

        public static string RandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return RandomString(length, chars.ToCharArray());
        }

        public static string RandomString(int length, char[] charset)
        {
            var random = new Random();

            var randomString = new char[length];
            for (var i = 0; i < length; i++)
                randomString[i] = charset[random.Next(charset.Length)];

            return new string(randomString);
        }

        public static int RandomInt(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        public static int RandomInt(int max = 1000000)
        {
            return RandomInt(0, max);
        }

        public static string RandomPersonalNumber()
        {
            var random = new Random();
            var year = random.Next(1, 99);
            var month = random.Next(1, 12);
            var day = random.Next(1, 28);

            var incomplete = new DateTime(year, month, day).ToString("yy-MM-dd").Replace("-", "");
            for (var i = 0; i < 3; i++)
                incomplete += random.Next(0, 9);
            var lastDigit = GetLuhnCheckDigit(incomplete);
            var complete = incomplete + lastDigit;
            return complete.Insert(6, "-");
        }

        private static string GetLuhnCheckDigit(string number)
        {
            var sum = 0;
            var alt = true;
            var digits = number.ToCharArray();
            for (var i = digits.Length - 1; i >= 0; i--)
            {
                var curDigit = (digits[i] - 48);
                if (alt)
                {
                    curDigit *= 2;
                    if (curDigit > 9)
                        curDigit -= 9;
                }
                sum += curDigit;
                alt = !alt;
            }
            if ((sum % 10) == 0)
            {
                return "0";
            }
            return (10 - (sum % 10)).ToString();
        }

        public static int GetUnusedAccountNumber()
        {
            for (var j = 0; j < 10; j++) //try 10x times to create unique account number
            {
                var number = TestUtils.RandomInt(0, 9999);

                if (!AccountExists(number))
                    return number;
            }

            throw new Exception("Could not generate unused account number");
        }

        private static bool AccountExists(int number)
        {
            try
            {
                DefaultFortnoxClient.AccountConnector.Get(number);
                return true;
            }
            catch (FortnoxApiException)
            {
                return false;
            }
        }
    }
}
