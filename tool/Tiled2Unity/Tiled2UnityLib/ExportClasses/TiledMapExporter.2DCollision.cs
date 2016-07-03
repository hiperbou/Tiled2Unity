using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Tiled2Unity
{
    using ClipperPolygon = List<ClipperLib.IntPoint>;
    using ClipperPolygons = List<List<ClipperLib.IntPoint>>;

    partial class TiledMapExporter
    {

        private XElement Create2DCollisionElementForLayer(TmxLayer layer)
        {
            // Collision elements look like this
            // (Can also have EdgeCollider2Ds)
            //      <GameOject name="Collision">
            //        <PolygonCollider2D>
            //          <Path>list of points</Path>
            //          <Path>another list of points</Path>
            //        </PolygonCollider2D>
            //      </GameOject>
        

            Grid2D grid = Layer2DCollision.Get2DCollisionGrid(this.tmxMap, layer);
            Logger.WriteLine(grid.print());


            XElement gameObjectCollision2D =
                new XElement("GameObject",
                    new XAttribute("name", "Collision2D"),
                    grid.print());

            return gameObjectCollision2D;
        }
    } // end class
} // end namespace
