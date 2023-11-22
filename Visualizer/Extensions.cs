/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    ? - initial implementation
  *    Andrew Vardeman - Added PersistToFile and LoadFromFile
  *******************************************************************************/
using System.Collections.Specialized;
using AgGateway.ADAPT.Visualizer.UI;

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

        public static int PersistToFile(this DataGridView dataGridView, string fileName)
        {
            PropertyFile pf = new PropertyFile();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string key = (string) row.Cells[0].Value;
                if (!string.IsNullOrEmpty(key))
                {
                    string value = (string) row.Cells[1].Value;
                    var property = new PropertyFile.Property { PropertyName = key, PropertyValue = value };
                    pf.Properties.Add(property);
                }
            }

            pf.Save(fileName);

            return pf.Properties.Count;
        }

        public static int LoadFromFile(this DataGridView dataGridView, string fileName)
        {
            dataGridView.Rows.Clear();
            PropertyFile? pf = PropertyFile.Load(fileName);
            if (pf != null)
            {
                foreach (var p in pf.Properties)
                {
                    dataGridView.Rows.Add(p.PropertyName, p.PropertyValue);
                }
            }
            return dataGridView.Rows.Count;
        }
    }
}
