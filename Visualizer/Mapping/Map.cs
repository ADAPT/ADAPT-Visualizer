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

namespace AgGateway.ADAPT.Visualizer.Mapping
{
    public class Map
    {
        private readonly List<MapObject> _mapObjects = new();
        private MapBoundingBox? _mapBoundingBox;
        private bool _isAllPoints = true;

        public IReadOnlyList<MapObject> MapObjects => _mapObjects;

        public bool IsAllPoints => _isAllPoints;

        public void AddMapObject(MapObject mapObject)
        {
            _mapObjects.Add(mapObject);
            if (!(mapObject is MapPoint))
            {
                _isAllPoints = false;
            }
            _mapBoundingBox = null;
        }

        public void Clear()
        {
            _mapObjects.Clear();
            _mapBoundingBox = null;
            _isAllPoints = true;
        }

        public MapBoundingBox MapBoundingBox
        {
            get
            {
                if (_mapBoundingBox == null)
                {
                    _mapBoundingBox = new();
                    foreach (var mapObject in MapObjects)
                    {
                        if (mapObject.Shape != null)
                        {
                            _mapBoundingBox.Update(mapObject.Shape);
                        }
                    }
                }

                return _mapBoundingBox;
            }
        }
    }
}
