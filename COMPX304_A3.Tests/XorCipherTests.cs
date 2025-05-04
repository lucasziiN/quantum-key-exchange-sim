using Microsoft.VisualStudio.TestTools.UnitTesting;
using COMPX304_A3;
using System.Text;

[TestClass]
public class XorCipherTests
{


    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ApplyNullDataThrowsArgumentNullException()
    {
        // data is null
        byte[] key = new byte[] {1};
        XorCipher.Apply(null, key);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void ApplyNullKeyThrowsArgumentNullException()
    {
        // key is null
        byte[] data = new byte[] { 1, 2, 3 };
        XorCipher.Apply(data, null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ApplyEmptyKeyThrowsArgumentException()
    {
        // key is empty
        byte[] data = new byte[] { 1, 2, 3 };
        XorCipher.Apply(data, new byte[0]);
    }

    [TestMethod]
    public void ApplyEmptyDataReturnsEmptyArray()
    {
        // Arrange
        byte[] data = new byte[0];
        byte[] key = new byte[] { 0xFF };

        // Act
        var result = XorCipher.Apply(data, key);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void ApplyRoundTripReturnsOriginalData()
    {
        // Arrange
        string plain = "HELLO";
        byte[] data = Encoding.UTF8.GetBytes(plain);
        byte[] key = Encoding.UTF8.GetBytes("WORLD");

        // Act
        var cipher = XorCipher.Apply(data, key);
        var round = XorCipher.Apply(cipher, key);

        // Assert
        CollectionAssert.AreEqual(data, round);
    }

    [TestMethod]
    public void ApplyKeyShorterThanDataCyclesThroughKey()
    {
        // Arrange
        byte[] data = { 1, 2, 3, 4 };
        byte[] key = { 1, 2 };
        byte[] expectedCipher = { (byte)(1 ^ 1), (byte)(2 ^ 2), (byte)(3 ^ 1), (byte)(4 ^ 2) };

        // Act
        var cipher = XorCipher.Apply(data, key);

        // Assert
        CollectionAssert.AreEqual(expectedCipher, cipher);
    }

}

