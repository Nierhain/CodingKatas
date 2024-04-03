using System.Text.RegularExpressions;

namespace MailFollowup;

public class Main
{
    private static readonly string[] Months =
        { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "oct", "nov", "dec" };

    public DateTime GetFollowupTime(DateTime now, string address)
    {
        if (!IsAddressValid(address))
        {
            throw new ArgumentException($"Followup address '{address}' is invalid.");
        }

        if (Months.Any(address.Contains))
        {
            var month = 0;
            for(int i = 0; i < Months.Length; i++)
            {
                if (!address.Contains(Months[i])) continue;
                month = i + 1;
                break;
            }

            var day = GetDurationFromMonthString(address, Months[month - 1]);
            var next = new DateTime(now.Year, month, day, now.Hour, now.Minute, now.Second);

            if (next < now)
            {
                next = next.AddYears(1);
            }

            return next;
        }

        var days = GetDays(address);
        var hours = GetDurationFromString(address, "hour");
        
        return now.AddDays(days).AddHours(hours);
    }

    private bool IsAddressValid(string address)
    {
        return (address.Contains("hour") || address.Contains("week") || address.Contains("day") || Months.Any(address.Contains)) && address.Contains("@followup.cc");
    }

    private int GetDurationFromString(string address, string duration)
    {
        if (!address.Contains(duration)) return 0;
        var temp = address.Split(duration)[0];
        var tempDuration = temp.Substring(GetLastIndexOfLetters(temp) + 1);
        return Convert.ToInt32(tempDuration);
    }
    
    private int GetDurationFromMonthString(string address, string month)
    {
        if (!address.Contains(month)) return 0;
        var temp = address.Split(month)[1];
        var tempDuration = temp.Substring(0, temp.IndexOfAny(['-', '@']));
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