namespace MailFollowup.Tests.TheoryGenerators;

public record MailFollowupObject(DateTime Now, string FollowupAddress, DateTime Expected);
public class MailFollowupGenerators
{
    public static IEnumerable<object[]> DaysAndHours =>
    new List<object[]>()
    {
        new object[] { new MailFollowupObject( new DateTime(2024, 1, 1, 12,0,0 ), "3days2hours@followup.cc", new DateTime(2024, 1, 4, 14, 0,0 ))},
        new object[] { new MailFollowupObject( new DateTime(2024, 1, 1, 12,0,0 ), "2hours3days@followup.cc", new DateTime(2024, 1, 4, 14, 0,0 ))},
        new object[] { new MailFollowupObject( new DateTime(2024, 1, 1, 12,0,0 ), "3days2weeks2hours@followup.cc", new DateTime(2024, 1, 18, 14, 0,0 ))},
        new object[] { new MailFollowupObject( new DateTime(2024, 7, 28, 12,0,0 ), "2days8hour@followup.cc", new DateTime(2024, 7, 30, 20, 0,0 ))},
        new object[] { new MailFollowupObject( new DateTime(2003, 2, 2, 12,0,0 ), "2weeks1day@followup.cc", new DateTime(2003, 2, 17, 12, 0,0 ))},
        new object[] { new MailFollowupObject( new DateTime(2012, 2, 26, 12,0,0 ), "16days6hours@followup.cc", new DateTime(2012, 3, 13, 18, 0,0 ))},
    };

    public static IEnumerable<object[]> WeeksAndHours =>
        new List<object[]>()
        {
            new object[] { new MailFollowupObject( new DateTime(2024, 1, 1, 12,0,0 ), "3weeks5hours@followup.cc", new DateTime(2024, 1, 22, 17, 0,0 ))},
            new object[] { new MailFollowupObject( new DateTime(2024, 7, 28, 12,0,0 ), "2weeks1hour@followup.cc", new DateTime(2024, 8, 11, 13, 0,0 ))},
            new object[] { new MailFollowupObject( new DateTime(2003, 2, 2, 12,0,0 ), "1week@followup.cc", new DateTime(2003, 2, 9, 12, 0,0 ))},
            new object[] { new MailFollowupObject( new DateTime(2012, 2, 26, 12,0,0 ), "25weeks20hours@followup.cc", new DateTime(2012, 8, 20, 8, 0,0 ))},
        };
}