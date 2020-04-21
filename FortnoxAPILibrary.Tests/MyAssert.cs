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
    }
}