using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

// Given a TmxMap and TmxLayer, crank out a Clipper polytree solution
namespace Tiled2Unity
{
    public class Layer2DCollision
    {
        public static Grid2D Get2DCollisionGrid(TmxMap tmxMap, TmxLayer tmxLayer) {
            Grid2D grid = new Grid2D(tmxLayer.Width, tmxLayer.Height);

            // Limit to polygon "type" that matches the collision layer name (unless we are overriding the whole layer to a specific Unity Layer Name)
            bool usingUnityLayerOverride = !String.IsNullOrEmpty(tmxLayer.UnityLayerOverrideName);

            for (int x = 0; x < tmxLayer.Width; x++) {
                for (int y = 0; y < tmxLayer.Height; y++) {
                    uint rawTileId = tmxLayer.GetRawTileIdAt(x, y);
                    if (rawTileId == 0) continue;
                    uint tileId = TmxMath.GetTileIdWithoutFlags(rawTileId);
                    TmxTile tile = tmxMap.Tiles[tileId];
                    foreach (TmxObject obj in tile.ObjectGroup.Objects) {
                        TmxObjectPolygon polygon = (obj as TmxObjectPolygon);
                        TmxHasPoints polygonHasPoints = (polygon as TmxHasPoints);
                        if (polygonHasPoints == null) continue;
                        //if (!usingUnityLayerOverride || String.Compare(polygon.Type, tmxLayer.Name, true) != 0) continue;
                        grid.setValue(x, y, 1);
                    }

                }
            }
            return grid;
        }
    }
}
