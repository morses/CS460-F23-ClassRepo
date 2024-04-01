using Standups.Models;

namespace Standups.ViewModels
{
    public class MeetingsVM
    {
        public Supuser CurrentUser { get; set; }
        public List<Supmeeting> Meetings { get; set; }

        public int classtime = 12;
        public DayOfWeek[] classdays = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday };

        public int NumberOfReports
        {
            get
            {
                return Meetings.Count;
            }
        }
    }
}