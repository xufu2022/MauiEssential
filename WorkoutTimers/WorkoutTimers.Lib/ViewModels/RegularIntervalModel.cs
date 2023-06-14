using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkoutTimers.Lib.ViewModels
{
    public class RegularIntervalModel
    {
        public string Name { get; set; }

        public TimeSpan Duration { get; set; }

        public int Repetitions { get; set; } = 0;
    }
}
