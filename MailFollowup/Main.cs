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
        var hours = GetHours(address);
        
        return now.AddDays(days).AddHours(hours);
    }

    private bool IsAddressValid(string address)
    {
        return (address.Contains("hour") || address.Contains("week")) && address.Contains("@followup.cc");
    }

    private int GetDays(string address)
    {
        string weekString = "0", dayString = "0";
        if (address.Contains("week"))
        {
            var temp = address.Split("week")[0];
            weekString = temp.Substring(GetLastIndexOfLetters(temp) + 1);
        }

        if (address.Contains("day"))
        {
            var temp = address.Split("day")[0];
            dayString = temp.Substring(GetLastIndexOfLetters(temp) + 1);
        }
        return Convert.ToInt32(weekString) * 7 + Convert.ToInt32(dayString);
    }

    private int GetLastIndexOfLetters(string line)
    {
        return line.LastIndexOfAny(['s', 'k', 'r', 'y']);
    }

    private int GetHours(string address)
    {
        if (!address.Contains("hour")) return 0;
        var hourString = address.Split("hour")[0];
        var lastIndex = GetLastIndexOfLetters(hourString);
        return Convert.ToInt32(hourString.Substring(lastIndex + 1));
    }
}