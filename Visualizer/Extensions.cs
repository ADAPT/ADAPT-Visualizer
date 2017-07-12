using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgGateway.ADAPT.Visualizer
{
    public static class Extensions
    {
        public static string ToNiceDateTime(this DateTime dt)
        {
            if (dt.TimeOfDay.Ticks == 0)
                return dt.ToShortDateString();
            else
                return dt.ToString();
        }

        public static string ToNiceDateTime(this DateTime? dtn)
        {
            if (dtn.HasValue) return ToNiceDateTime((DateTime)dtn);
            return "-";
        }
    }
}
