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
        var followup = "1hour@followup.cc";
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
        var followup = "2weeks@followup.cc";
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
        var followup = "1week4hours@followup.cc";
        var expected = new DateTime(2024, 4, 9, 16, 0, 0);
        //Act
        var t = _sut.GetFollowupTime(date, followup);
        //Assert
        t.Should().Be(expected);
    }

    [Fact]
    public void GivenAFaultyFollowupTime_ThrowArgumentException()
    {
        //Arrange
        var date = new DateTime(2024, 4, 2, 12, 0, 0);
        var followup = "undefined@followup.cc";
        //Act
        Action act = () => _sut.GetFollowupTime(date, followup);
        //Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage($"Followup address '{followup}' is invalid.");
    }

    [Theory]
    [MemberData(nameof(MailFollowupGenerators.WeeksAndHours), MemberType = typeof(MailFollowupGenerators))]
    public void GivenValidDatesAndWeekAndHoursFollowups_ReturnCorrectDateTimes(MailFollowupObject mail)
    {
        //Act
        var actual = _sut.GetFollowupTime(mail.Now, mail.FollowupAddress);
        //Assert
        actual.Should().Be(mail.Expected);
    }

    [Fact]
    public void GivenAFaultyFollowupAddress_ThrowArgumentException()
    {
        //Arrange
        var date = new DateTime(2024, 4, 2, 12, 0, 0);
        var followup = "2weeks4hours";
        //Act
        Action act = () => _sut.GetFollowupTime(date, followup);
        //Assert
        act.Should().Throw<ArgumentException>()
            .WithMessage($"Followup address '{followup}' is invalid.");
    }

    [Theory]
    [MemberData(nameof(MailFollowupGenerators.DaysAndHours), MemberType = typeof(MailFollowupGenerators))]
    public void GivenADurationInDays_ThenReturnValidDateTime(MailFollowupObject mail)
    {
        //Act
        var actual = _sut.GetFollowupTime(mail.Now, mail.FollowupAddress);
        //Assert
        actual.Should().Be(mail.Expected);
    }

    [Theory]
    [MemberData(nameof(MailFollowupGenerators.DatesAndTime), MemberType = typeof(MailFollowupGenerators))]
    public void GivenADateAsFollowup_ThenReturnThatDateAsTheNextOccurence(MailFollowupObject mail)
    {
        
        //Act
        var actual = _sut.GetFollowupTime(mail.Now, mail.FollowupAddress);
        //Assert
        actual.Should().Be(mail.Expected);
    }
}