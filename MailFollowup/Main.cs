using System.Text.RegularExpressions;

namespace MailFollowup;

public class Main
{
    public DateTime GetFollowupTime(DateTime now, string address)
    {
        if (!IsAddressValid(address))
        {
            throw new ArgumentException($"Followup address '{address}' is invalid.");
        }
        
        var days = GetDays(address);
        var hours = GetDurationFromString(address, "hour");
        
        return now.AddDays(days).AddHours(hours);
    }

    private bool IsAddressValid(string address)
    {
        return (address.Contains("hour") || address.Contains("week")) && address.Contains("@followup.cc");
    }

    private int GetDurationFromString(string address, string duration)
    {
        if (!address.Contains(duration)) return 0;
        var temp = address.Split(duration)[0];
        var tempDuration = temp.Substring(GetLastIndexOfLetters(temp) + 1);
        return Convert.ToInt32(tempDuration);
    }

    private int GetDays(string address)
    {
        return GetDurationFromString(address, "week") * 7 + GetDurationFromString(address, "day");
    }

    private int GetLastIndexOfLetters(string line)
    {
        return line.LastIndexOfAny(['s', 'k', 'r', 'y']);
    }
}