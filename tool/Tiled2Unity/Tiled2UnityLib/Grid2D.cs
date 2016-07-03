using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

// Given a TmxMap and TmxLayer, crank out a Clipper polytree solution
namespace Tiled2Unity
{
    public class Grid2D {
        int[,] grid;
        int width;
        int height;

        public Grid2D(int width, int height) {
            setGridSize(width, height);
        }

        public void setGridSize(int width, int height) {
            this.width = width;
            this.height = height;
            grid = new int[width, height];
        }

        public void setValue(int x, int y, int value) {
            if (x < 0 || y < 0 || x >= width || y >= height) return;
            grid[x, y] = value;
        }

        public int getValue(int x, int y) {
            if (x < 0 || y < 0 || x >= width || y >= height) return 0;
            return grid[x, y];
        }

        public bool hasNear(int x, int y, int type) {
            if (getValue(x + 1, y) == type) return true;
            if (getValue(x - 1, y) == type) return true;
            if (getValue(x, y + 1) == type) return true;
            if (getValue(x, y - 1) == type) return true;

            return false;
        }

        public string print() {
            string concatedString = "";

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    concatedString += Convert.ToString(grid[x, y]);
                    if(y<height-1 || x<width-1) concatedString += ",";
                }
                concatedString += "\n";
            }
            return concatedString;
        }

        public string printArray() {
            string concatedString = "";

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    concatedString += Convert.ToString(grid[x, y]);
                    if (y < height - 1 || x < width - 1) concatedString += ",";
                }
            }
            return concatedString;
        }
    }
}
