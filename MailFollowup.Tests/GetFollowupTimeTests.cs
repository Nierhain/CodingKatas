using FluentAssertions;
using MailFollowup.Tests.TheoryGenerators;

namespace MailFollowup.Tests;
// Given_Then
// (A)rrange (A)ct (A)ssert  
public class GetFollowupTimeTests
{
    private readonly Main _sut;
    public GetFollowupTimeTests()
    {
        _sut = new Main();
    }

    [Fact]
    public void GivenAValidDateTime_ReturnAValidDateTimeAfter()
    {
        //Arrange
        var date = new DateTime();
        var followup = "1hour";
        //Act
        var t = _sut.GetFollowupTime(date, followup);
        //Assert
        t.Should().BeAfter(date);
    }

    [Fact]
    public void Given2Weeks_ReturnDateTimeIn2Weeks()
    {
        //Arrange
        var date = new DateTime(2024, 3, 4);
        var followup = "2weeks";
        var expected = new DateTime(2024, 3, 18);
        //Act
        var t = _sut.GetFollowupTime(date, followup);
        //Assert
        t.Should().Be(expected);
    }

    [Fact]
    public void Given1Week4Hours_ReturnDateTimeIn1WeekAnd4Hours()
    {
        //Arrange
        var date = new DateTime(2024, 4,2, 12, 0, 0);
        var followup = "1week4hours";
        var expected = new DateTime(2024, 4, 9, 16, 0, 0);
        //Act
        var t = _sut.GetFollowupTime(date, followup);
        //Assert
        t.Should().Be(expected);
    }

    [Fact]
    public void GivenAFaultyFollowup_ThrowArgumentException()
    {
        //Arrange
        var date = new DateTime(2024, 4, 2, 12, 0, 0);
        var followup = "undefined";
        //Act
        Action act = () => _sut.GetFollowupTime(date, followup);
        //Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage($"Followup address '{followup}' is invalid.");
    }
}