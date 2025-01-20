namespace ChairsLibTests;

using ChairsLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Tests follow the triple A pattern - Arrange, Act, Assert.
// Also I have tried to keep the naming convention consistent. Meaning <MethodUnderTest>_<Scenario>_<ExpectedResult>.

[TestClass]
public class ChairsRepositoryTests
{
    private ChairsRepository _repository = null!;

    [TestInitialize]
    public void Setup()
    {
        _repository = new ChairsRepository();
    }

    [TestMethod]
    public void GetAll_ShouldReturnAllChairs()
    {
        // Act
        var chairs = _repository.GetAll();

        // Assert
        Assert.AreEqual(3, chairs.Count);
        Assert.AreEqual("The Egg", chairs[0].Model);
    }

    [TestMethod]
    public void Add_ShouldAddNewChair()
    {
        // Arrange
        var newChair = new Chair { Model = "Barcelona", MaxWeight = 150, HasPillow = false };

        // Act
        var addedChair = _repository.Add(newChair);
        var allChairs = _repository.GetAll();

        // Assert
        Assert.AreEqual(4, allChairs.Count);
        Assert.AreEqual(4, addedChair.Id); // ID should increment correctly
        Assert.AreEqual(newChair.Model, addedChair.Model);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Add_ShouldThrowException_WhenModelIsInvalid()
    {
        // Arrange
        var invalidChair = new Chair { Model = "A", MaxWeight = 100, HasPillow = true };

        // Act
        _repository.Add(invalidChair);
    }

    [TestMethod]
    public void Delete_ShouldRemoveChair_WhenIdIsValid()
    {
        // Act
        var deletedChair = _repository.Delete(1);
        var allChairs = _repository.GetAll();

        // Assert
        Assert.IsNotNull(deletedChair);
        Assert.AreEqual(2, allChairs.Count);
    }

    [TestMethod]
    public void Delete_ShouldThrowException_WhenIdIsInvalid()
    {
        // Act & Assert
        Assert.ThrowsException<ArgumentException>(() => _repository.Delete(999));
    }
}
