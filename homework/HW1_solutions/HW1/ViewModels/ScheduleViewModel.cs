using System.ComponentModel.DataAnnotations;

namespace HW1.ViewModels;

public class ScheduleViewModel
{
    [Required(ErrorMessage = "Please enter times that everyone is busy.")]
    public string BusyTimes { get; set; }

    [Required(ErrorMessage = "Please indicate whether weekends should be included.")]
    public bool IncludeWeekends { get; set; }
    public HashSet<string> FreeTimes { get; set; }

    public ScheduleViewModel()
    {
        BusyTimes = "";
        IncludeWeekends = false;
        FreeTimes = new HashSet<string>();
    }

    public ScheduleViewModel(string busyTimes, bool includeWeekends = false)
    {
        BusyTimes = busyTimes;
        IncludeWeekends = includeWeekends;
        FreeTimes = new HashSet<string>();
    }
}