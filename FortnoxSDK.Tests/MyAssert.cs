using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FortnoxSDK.Tests;

public static class MyAssert
{
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