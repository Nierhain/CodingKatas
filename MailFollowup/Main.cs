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
        return address.Contains("hour") || address.Contains("week");
    }

    private int GetDays(string address)
    {
        if (!address.Contains("week")) return 0;
        var weekString = address.Split("week")[0];
        return Convert.ToInt32(weekString) * 7;
    }

    private int GetHours(string address)
    {
        if (!address.Contains("hour")) return 0;
        var hourString = address.Split("hour")[0];
        var lastIndex = hourString.LastIndexOfAny(['s', 'k', 'r']);
        return Convert.ToInt32(hourString.Substring(lastIndex + 1));
    }
}