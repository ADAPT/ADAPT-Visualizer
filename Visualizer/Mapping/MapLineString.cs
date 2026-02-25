/* Copyright (C) 2015-16 AgGateway and ADAPT Contributors
 * Copyright (C) 2015-16 Deere and Company
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html>
 *
 * Contributors:
 *    Andrew Vardeman - Initial Implementation
 *******************************************************************************/

using AgGateway.ADAPT.ApplicationDataModel.Shapes;

namespace AgGateway.ADAPT.Visualizer.Mapping
{
    public class MapLineString : MapObject
    {
        public LineString? LineString { get; set; }
        public override Shape? Shape => LineString;
    }
}
