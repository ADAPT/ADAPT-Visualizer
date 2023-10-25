/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
  * Copyright (C) 2015-16 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Andrew Vardeman - initial implementation
  *******************************************************************************/
using AgGateway.ADAPT.ApplicationDataModel.LoggedData;

namespace AgGateway.ADAPT.Visualizer.UI
{
    public class ProcessDataRequest
    {
        public ProcessDataRequest(TreeNode node, bool limitData, int maxRows, int maxColumns)
        {
            Node = node;
            LimitData = limitData;
            MaxRows = maxRows;
            MaxColumns = maxColumns;
        }

        public TreeNode Node { get; }

        public bool LimitData { get; }

        public int MaxRows { get; }

        public int MaxColumns { get; }

        public List<SpatialRecord>? SpatialRecords { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var that = (ProcessDataRequest)obj;
            return Node == that.Node && LimitData == that.LimitData &&
                   MaxRows == that.MaxRows && MaxColumns == that.MaxColumns;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Node, LimitData, MaxRows, MaxColumns);
        }
    }
}
