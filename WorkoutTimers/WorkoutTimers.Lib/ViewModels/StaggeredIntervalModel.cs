using System.Collections.ObjectModel;

namespace WorkoutTimers.Lib.ViewModels
{
    public class StaggeredIntervalModel
    {
        public string Name { get; set; }

        public ObservableCollection<TimeSpan> Durations { get; set; } = new ObservableCollection<TimeSpan>();

        public TimeSpan TotalDuration { get {
            return new TimeSpan(Durations.Sum(d=>d.Ticks));
            } 
        }
        public int Repetitions { get; set; } = 0;
    }
}
