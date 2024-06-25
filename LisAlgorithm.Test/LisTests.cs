using LisAlgorithm.Application.Abstraction;
using LisAlgorithm.Application.Operation;
using System.ComponentModel.DataAnnotations;

namespace LisAlgorithm.Test;

[TestFixture]
public class LisTests
{


    private ILongestIncreasingSequence _service;


    [SetUp]
    public void Setup()
    {
        _service = new LongestIncreasingSequence();
    }

    [Test]
    public void Test1()
    {
        //Arrange
        var input = "6 1 5 9 2";
        var output = "1 5 9";

        //Act
        var expectedResult = _service.FindLongestSequence(input);

        //Assert
        Assert.That(output, Is.EqualTo(expectedResult));

    }
}