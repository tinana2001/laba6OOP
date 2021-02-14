using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace laba6OOP
{
    public class Shape
    {

    }
    
    public class Circle
    {
        public Color color = Color.DeepPink;
        public int x, y, r;
        public bool flag = false;
        public Circle(int x1, int y1, int r1)
        {
            x = x1;
            y = y1;
            r = r1;
        }

        public bool CheckPoint(int x, int y)
        {
            if (((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y)) <= r * r)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(Graphics graph)
        {
            Pen pen;

            if (flag)
            {
                pen = new Pen(color, 10);
            }
            else
            {
                pen = new Pen(color);
            }
            graph.DrawEllipse(pen, x - r, y - r, 2 * r, 2 * r);
        }

    }
}
