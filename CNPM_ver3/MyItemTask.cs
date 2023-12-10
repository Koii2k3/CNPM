using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNPM_ver3
{
    /*
     This class is used for saving task object (Make timeline part)
     */
    public class MyItemsTask
    {
        public string taskName;
        public DateTime beginTime;
        public DateTime endTime;
        public int higlight;
        public MyItemsTask(string taskName, DateTime beginTime, DateTime endTime, int higlight)
        {
            this.taskName = taskName;
            this.beginTime = beginTime;
            this.endTime = endTime;
            this.higlight = higlight;
        }

        public int GetDayInterval()
        {
            TimeSpan span = this.endTime.Subtract(this.beginTime);
            return span.Days + 1;
        }
        public int GetLaterTimeInterval(DateTime startWeekTime)
        {
            TimeSpan span = this.endTime.Subtract(startWeekTime);
            return span.Days + 1;
        }
        // Start task > end current week
        public int GetLaterTimeInterval1(DateTime endWeekTime)
        {
            TimeSpan span = this.endTime.Subtract(endWeekTime);
            return span.Days + 1;
        }
    }
}
