using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace laba6OOP
{
   
    public abstract class Shape
    {
        
        public Color color= Color.CadetBlue;
        public int x, y, r;
        public bool flag = false;

        public Shape(int x1, int y1, int r1)
        {
            x = x1;
            y = y1;
            r = r1;
        }
        public virtual void Move(int dx, int dy)
        {
            x = x + dx;
            y = y + dy;
        }
        public virtual void ChangeR(int dr)
        {
            r += dr;
            if (r < 1)
            {
                r = 1;
            }
        }
        public abstract bool CheckPoint(int _x, int _y);
        
        public abstract bool CheckBorder(int _x, int _y);
        public abstract void Draw(Graphics graph);  //drawing figure
        /*public Color ColorChange(Color color)
        {
            color = new Color();
            return color;
        }*/
        
    }

    public class Circle : Shape
    {
        public Circle(int x1, int y1, int r1) : base(x1, y1, r1)
        {
        }

        public override bool CheckPoint(int x, int y)
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

        public override void Draw(Graphics graph)
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
        public override bool CheckBorder(int _x, int _y)
        {
            if ((x - r <= 0) || (x + r >= _x) || (y - r <= 0) || (y + r >= _y))
            {
                return false;
            }
            else
            return true;
        }

    
    }
    public class Square : Shape
    {
        public Square(int x1, int y1, int r1) : base(x1, y1, r1)
        {
        }

        public override bool CheckPoint(int x, int y)
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

        public override void Draw(Graphics graph)
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
            graph.DrawRectangle(pen, x - r, y - r, 2 * r, 2 * r);
        }
        public override bool CheckBorder(int _x, int _y)
        {
            if ((x - r <= 0) || (x + r >= _x) || (y - r <= 0) || (y + r >= _y))
            {
                return false;
            }
            else
                return true;
        }
    }
    
}
