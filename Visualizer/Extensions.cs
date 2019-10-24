using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public static int PersistToCollection(this DataGridView dataGridView, StringCollection stringCollection)
        {
            stringCollection.Clear();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string key = (string)row.Cells[0].Value;
                if (!string.IsNullOrEmpty(key))
                {
                    stringCollection.Add(string.Format("{0};{1}", key, row.Cells[1].Value));
                }
            }

            return stringCollection.Count;
        }

        public static int LoadFromCollection(this DataGridView dataGridView, StringCollection stringCollection)
        {
            dataGridView.Rows.Clear();
            foreach (string s in stringCollection)
            {
                string[] parts = s.Split(';');
                if ((parts.Count() >= 2) && (!string.IsNullOrEmpty(parts[0])))
                {
                    dataGridView.Rows.Add(parts[0], parts[1]);
                }
            }

            return dataGridView.Rows.Count;
        }
    }
}
