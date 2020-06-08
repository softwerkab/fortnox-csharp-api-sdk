using FortnoxAPILibrary.Connectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxAPILibrary.Tests
{
    public static class MyAssert
    {
        /// <summary>
        /// Checks if the last request was successfull
        /// </summary>
        /// <param name="connector"></param>
        public static void HasNoError(IConnector connector)
        {
            if (connector.HasError)
                throw new AssertFailedException($"Request failed due to '{connector.Error.Message}'.");
        }

        public static void IsPDF(byte[] data)
        {
            try
            {
                Assert.AreEqual(data[0], 0x25); // %
                Assert.AreEqual(data[1], 0x50); // P
                Assert.AreEqual(data[2], 0x44); // D
                Assert.AreEqual(data[3], 0x46); // F
                Assert.AreEqual(data[4], 0x2D); // -
            }
            catch (AssertFailedException)
            {
                throw new AssertFailedException("File is not valid PDF file.");
            }
        }
    }
}