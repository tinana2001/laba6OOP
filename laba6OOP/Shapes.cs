using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace laba6OOP
{

    public abstract class Shape
    {

        public Color color = Color.Coral;
        public int x, y, size;
        public GraphicsPath figure;
        public bool flag = false;

        public Shape(int x1, int y1, int size1)
        {
            x = x1;
            y = y1;
            size = size1;
            flag = true;
            figure = new GraphicsPath();
        }
        public virtual void Move(int _x, int _y)
        {
            x = x + _x;
            y = y + _y;
        }
        public virtual void ChangeR(int _size)
        {
            size += _size;
            if (size < 1)
            {
                size = 1;
            }
        }
        public abstract void Draw(Graphics graph);
        public virtual bool CheckBorder(int _x, int _y)
        {
            //if ((x - size <= 0) || (x + size >= _x) || (y - size <= 0) || (y + size >= _y))
            if((figure.GetBounds().X<=0) || (figure.GetBounds().X + figure.GetBounds().Width >= _x)||(figure.GetBounds().Y<=0)||(figure.GetBounds().Y+figure.GetBounds().Height>=_y))
            {
                return false;
            }
            else
                return true;
        }
        public virtual bool ChackHit(int _x, int _y)
        {
            if (figure.IsVisible(_x, _y))//isVisible-определяет, содержится ли данная точка в объекте graphicsPath
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class Circle : Shape
    {
        public Circle(int x1, int y1, int size1) : base(x1, y1, size1)
        {
        }

     

        public override void Draw(Graphics graph)
        {

            /*Pen pen;
            if (flag)
            {
                pen = new Pen(color, 5);
            }
            else
            {
                pen = new Pen(color);
            }
            graph.DrawEllipse(pen, x - size, y - size, 2 * size, 2 * size);*/
            figure.Reset();
            figure.AddEllipse(x-size/2,y-size,size,2*size);
            Pen pen;
            if (flag)
            {
                pen = new Pen(color, 5);
                graph.DrawPath(pen, figure);
            }
            else
            {
                pen = new Pen(color);
                graph.DrawPath(pen, figure);
            }
        }
      
    }
    public class Square : Shape
    {
        public Square(int x1, int y1, int size1) : base(x1, y1, size1)
        {
        }

       

        public override void Draw(Graphics graph)
        {

            /*if (flag)
            {
                pen = new Pen(color, 5);
            }
            else
            {
                pen = new Pen(color);
            }
            graph.DrawRectangle(pen, x-size, y-size, 2*size, 2*size);*/
            figure.Reset();
            Point[] points =
            {
            new Point(x-size,y-size/2),
            new Point(x -size, y + size / 2),
            new Point(x + size, y + size / 2),
            new Point(x + size, y - size / 2),
            };
            figure.AddPolygon(points);
            Pen pen;
            if (flag)
            {
                pen = new Pen(color, 5);
                graph.DrawPath(pen, figure);
            }
            else
            {
                pen = new Pen(color);
                graph.DrawPath(pen, figure);
            }
        }


    }
    public class Triangle : Shape
    {
        public Triangle(int x1, int y1, int size1) : base(x1, y1, size1)
        {
        }

      

        public override void Draw(Graphics graph)
        {
            /*Pen pen;

            if (flag)
            {
                pen = new Pen(color, 5);
            }
            else
            {
                pen = new Pen(color);
            }
            graph.DrawPolygon(pen, new PointF[] { new PointF(x, y + size), new PointF(x + size, y - size), new PointF(x - size, y - size) });*/
            figure.Reset();
            Point[] points =
            {
            new Point(x, y + size),
            new Point(x + size, y - size),
            new Point(x - size, y - size),
            };
            figure.AddPolygon(points);
            Pen pen;
            if (flag)
            {
                pen = new Pen(color, 5);
                graph.DrawPath(pen, figure);
            }
            else
            {
                pen = new Pen(color);
                graph.DrawPath(pen, figure);
            }
        }
       
    }
}