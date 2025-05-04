using Microsoft.VisualStudio.TestTools.UnitTesting;
using COMPX304_A3;

[TestClass]
public class QubitTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Constructor_BitOutOfRange_ThrowsArgumentOutOfRangeException()
    {
        new Qubit(2, 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Constructor_BasisOutOfRange_ThrowsArgumentOutOfRangeException()
    { 
        new Qubit(0, 3);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Set_BitOutOfRange_ThrowsArgumentOutOfRangeException()
    {
        var q = new Qubit(0, 0);
        q.Set(4, 0);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Set_BasisOutOfRange_ThrowsArgumentOutOfRangeException()
    {
        var q = new Qubit(0, 0);
        q.Set(0, 5);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Measure_BasisOutOfRange_ThrowsArgumentOutOfRangeException()
    {
        new Qubit(0, 0).Measure(-1);
    }
    


    [TestMethod]
    public void Measure_SameBasis_ReturnsStoredValue()
    {
        // Arrange: make a qubit set to bit=1, basis=0
        var qubit = new Qubit(1, 0);

        // Act: measure in the same basis (0)
        int result = qubit.Measure(0);

        // Assert: should get back exactly what was set (1)
        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Measure_WrongBasis_CollapsesAndSticks()
    {
        // Arrange: make a qubit set to bit=1, basis=0
        var qubit = new Qubit(1, 0);

        // Act: first, measure in the different basis (1) => collapse
        int result = qubit.Measure(1);

        // Assert: collapsed bit must be a valid 0 or 1
        Assert.IsTrue(result == 0 || result == 1);

        // Act & Assert: measuring again in basis=1 must return the same collapsed value
        Assert.AreEqual(result, qubit.Measure(1));
    }

    [TestMethod]
    public void Set_AfterCollapse_AllowsNewState()
    {
        // Arrange: make a qubit set to bit=1, basis=0
        var qubit = new Qubit(1, 0);

        // Act: first, measure in a different basis (1) => collapse
        qubit.Measure(1);

        // Then reset it explicitly to bit=0, basis=1  
        qubit.Set(0, 1);

        // Assert: measuring again in basis=1 should now return the reset value (0)
        Assert.AreEqual(0, qubit.Measure(1)); 
    }

}

