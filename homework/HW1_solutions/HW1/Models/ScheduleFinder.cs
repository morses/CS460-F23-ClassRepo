using System.Linq;

namespace HW1.Models;

/// <summary>
/// Given a list of busy times and a boolean indicating whether weekends should be included,
/// compute a list of free times.  The input is a string of busy times, e.g. "M10 T9 W8 R10 F11"
/// and the output is a list of free times in the same format.  Using a Set data structure for this
/// makes it easy to compute the difference between the set of all possible times and the set of
/// busy times.
/// </summary>

public class ScheduleFinder
{
    // store the input data for any future reference
    public string BusyTimesStr { get; set; }
    public bool IncludeWeekends { get; set; }

    public HashSet<string> BusyTimes { get;  private set; }     // i.e. {"M10","T9","W8","R10","F11"}
    public HashSet<string> FreeTimes { get; private set; }      // i.e. {"M8","M9","M11",...} see tests for examples

    public ScheduleFinder(string busyTimes, bool includeWeekends = false)
    {
        BusyTimesStr = busyTimes;
        IncludeWeekends = includeWeekends;

        // use a nice modular, testable design.  Split things apart into small, easily testable pieces.
        BusyTimes = new HashSet<string>(ParseTimesFromString(BusyTimesStr));
        FreeTimes = new HashSet<string>(GenerateAllPossibleTimes(IncludeWeekends));
        FreeTimes.ExceptWith(BusyTimes);    // set difference
    }

    // These are public static so they're easy to test.  Plus, they are pure functions 
    // that don't depend on any state of an instance of this class so don't need to be instance methods.
    public static List<string> ParseTimesFromString(string str)
    {
        if (str == null)
        {
            return new List<string>();
        }
        string processedInput = ReplaceAllNonAlphanumericCharsWithSpaces(str);
        string[] timesStr = processedInput.Trim().Split(' ',StringSplitOptions.RemoveEmptyEntries);
        List<string> times = timesStr.Select(t => t.Trim().ToUpper()).ToList();
        return times;
    }

    public static List<string> GenerateAllPossibleTimes(bool includeWeekends)
    { 
        string[] days = includeWeekends ? new string[] { "SU", "M", "T", "W", "R", "F", "SA" } : new string[] { "M", "T", "W", "R", "F" };
        string[] times = new string[] { "8","9","10","11","12","13","14","15","16" };

        List<string> cartesianProduct = days.SelectMany(d => times.Select(t => d + t)).ToList();
        return cartesianProduct;
    }

    // This allows us to recover if someone doesn't use a space as a separator, as well as allowing returns
    // or tabs or even commas, semicolons, etc.
    public static string ReplaceAllNonAlphanumericCharsWithSpaces(string str)
    {
        return System.Text.RegularExpressions.Regex.Replace(str, "[^a-zA-Z0-9]", " ");
    }

}