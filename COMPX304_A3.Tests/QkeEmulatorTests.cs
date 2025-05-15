using Microsoft.VisualStudio.TestTools.UnitTesting;
using COMPX304_A3;
using System.Text;

[TestClass]
public class QkeEmulatorTests
{


    [TestMethod]
    [ExpectedException(typeof(OverflowException))]
    public void ExchangeKey_NegativeStreamLength_ThrowsOverflowException()
    {
        // Arrays should blow up on negative length
        new QkeEmulator().ExchangeKey(-1);
    }

    [TestMethod]
    public void ExchangeKey_ZeroStreamLength_ReturnsEmptyKey()
    {
        // Arrange + Act
        var key = new QkeEmulator().ExchangeKey(0);

        // Assert
        Assert.IsNotNull(key);
        Assert.AreEqual(0, key.Length);
    }

    [TestMethod]
    public void ExchangeKey_PositiveStreamLength_KeyLengthDoesNotExceedStreamLength()
    {
        // Arrange + Act
        const int N = 1000;
        var key = new QkeEmulator().ExchangeKey(N);
        
        // Assert
        Assert.IsTrue(key.Length <= N,$"Key length ({key.Length}) must be less or equal to stream length ({N})");
    }

    [TestMethod]
    public void ExchangeKey_PositiveStreamLength_ReturnsOnlyBitsZeroOrOne()
    {
        // Arrange + Act
        var key = new QkeEmulator().ExchangeKey(100);

        // Assert
        Assert.IsTrue(key.All(b => b == 0 || b == 1),"Shared key contains invalid bit values");
    }

    [DataTestMethod]
    [DataRow(16)]
    [DataRow(256)]
    [DataRow(1024)]
    public void SecureExchange_StreamLength_RoundTripDecryptsCorrectly(int streamLength)
    {
        // Arrange
        var emulator = new QkeEmulator();
        string message = "HELLO";
        byte[] plaintext = Encoding.UTF8.GetBytes(message);

        // Act
        int[] keyBits = emulator.ExchangeKey(streamLength);
        byte[] keyBytes = keyBits.Select(b => (byte)b).ToArray();
        byte[] cipher = XorCipher.Apply(plaintext, keyBytes);
        byte[] round = XorCipher.Apply(cipher, keyBytes);

        // Assert: secure exchange yields back the original
        CollectionAssert.AreEqual(plaintext, round, $"Failed secure exchange for streamLength={streamLength}");
    }
}

