using System.Text.RegularExpressions;

namespace MailFollowup;

public class Main
{
    private static readonly string[] Months =
        { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "oct", "nov", "dec" };

    public DateTime GetFollowupTime(DateTime now, string address)
    {
        if (!IsAddressValid(address))
            throw new ArgumentException($"Followup address '{address}' is invalid.");
        


        if (IsDate(address))
        {
            return GetFollowupDateFromDate(now, address);
        }
        
        var days = GetDays(address);
        var hours = GetDurationFromString(address, "hour");
        
        return now.AddDays(days).AddHours(hours);
    }

    private DateTime GetFollowupDateFromDate(DateTime now, string address)
    {
        var year = now.Year;
        var month = now.Month;
        var time = now.Hour;
        var day = now.Day;
        if (Months.Any(address.Contains))
        {
            for(var i = 0; i < Months.Length; i++)
            {
                if (!address.Contains(Months[i])) continue;
                month = i + 1;
                break;
            }
                
            day = GetDurationFromMonthString(address, Months[month - 1]);
            if (day <= now.Day && month <= now.Month)
            {
                year++;
            }
        }
            
        if (address.Contains("am") || address.Contains("pm"))
        {
            var isAm = address.Contains("am");
            time = GetDurationFromString(address,isAm ? "am" : "pm");
            
            if (!isAm)
            {
                if (time == 12) time = 12;
                else time = time + 12;
            }
            if (time == 24 || (time == 12 && isAm))
            {
                time = 0;
            }
        }
            
        if (time <= now.Hour && year == now.Year && day == now.Day && month == now.Month)
        {
            day++;
        }
            
        return new DateTime(year, month, day, time, now.Minute, now.Second);
    }

    private bool IsDate(string address)
    {
        return Months.Any(address.Contains) || address.Contains("am") || address.Contains("pm");
    }

    private bool IsAddressValid(string address)
    {
        return (address.Contains("hour") || address.Contains("week") || address.Contains("day") || Months.Any(address.Contains) || address.Contains("am") || address.Contains("pm")) && address.Contains("@followup.cc");
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
        if (!address.Contains(month)) return -1;
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
        return line.LastIndexOfAny(['s', 'k', 'r', 'y', '-']);
    }
}