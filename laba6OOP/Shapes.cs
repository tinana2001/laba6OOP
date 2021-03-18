using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace laba6OOP
{

    public abstract class Shape
    {

        public Color color = Color.Coral;
        public int x, y, size1, size2;
        public GraphicsPath figure;
        public bool flag = false;

        public Shape(int x1, int y1, int _size1, int _size2)
        {
            x = x1;
            y = y1;
            size1 = _size1;
            size2 = _size2;
            flag = true;
            figure = new GraphicsPath();
        }
        public virtual void Move(int _x, int _y)
        {
                x = x + _x;
                y = y + _y;
        }
        public virtual void ChangeSize(Keys k, int w, int h)
        {
            if (flag)
            {
                switch (k)
                {
                    case Keys.Add:
                        if ((figure.GetBounds().X + figure.GetBounds().Width < w-5) && (figure.GetBounds().X > 5) && (figure.GetBounds().Y > 5) && (figure.GetBounds().Y + figure.GetBounds().Height < h-5))
                        {
                            {
                                size1 = size1 + 3;
                                size2 = size2 + 3;
                            }
                        }
                        break;
                    case Keys.Subtract:
                        if ((size1 > 5) && (size2 > 5))
                        {
                            size1 = size1 - 3;
                            size2 = size2 - 3;
                        }
                        break;
                }
            }
        }
        public void move(Keys k, int w, int h)
        {
            if (flag)
            {
                switch (k)
                {
                    case Keys.D:
                        if (figure.GetBounds().X + figure.GetBounds().Width < w-5)
                            x = x + 3;
                        break;
                    case Keys.A:
                        if (figure.GetBounds().X > 5)
                            x = x - 3;
                        break;
                    case Keys.W:
                        if (figure.GetBounds().Y > 5)
                            y = y - 3;
                        break;
                    case Keys.S:
                        if (figure.GetBounds().Y + figure.GetBounds().Height < h-5)
                            y = y + 3;
                        break;
                }
            }
        }
        public abstract void Draw(Graphics graph);
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
        public Circle(int x1, int y1, int size1, int size2) : base(x1, y1, size1, size2)
        {
        }
        public override void Draw(Graphics graph)
        {
            figure.Reset();
            figure.AddEllipse(x - size1, y - size2, 2 * size1, 2 * size2);
            Pen pen;
            if (flag)
            {
                pen = new Pen(color, 6);
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
        public Square(int x1, int y1, int size1, int size2) : base(x1, y1, size1, size2)
        {
        }
        public override void Draw(Graphics graph)
        {
            figure.Reset();
            Point[] points =
            {
            new Point(x-size1,y-size2),
            new Point(x -size1, y + size2 ),
            new Point(x + size1, y + size2),
            new Point(x + size1, y - size2),
            };
            figure.AddPolygon(points);
            Pen pen;
            if (flag)
            {
                pen = new Pen(color, 6);
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
        public Triangle(int x1, int y1, int size1, int size2) : base(x1, y1, size1, size2)
        {
        }
        public override void Draw(Graphics graph)
        {
            figure.Reset();
            Point[] points =
            {
            new Point(x, y + size2),
            new Point(x + size1, y - size2),
            new Point(x - size1, y - size2),
            };
            figure.AddPolygon(points);
            Pen pen;
            if (flag)
            {
                pen = new Pen(color, 6);
                graph.DrawPath(pen, figure);
            }
            else
            {
                pen = new Pen(color);
                graph.DrawPath(pen, figure);
            }
        }

    }
    public class SF : Shape
    {
        public SF(int x1, int y1, int size1, int size2) : base(x1, y1, size1, size2)
        {
        }
        public override void Draw(Graphics graph)
        {
            figure.Reset();
            Point[] points =
            {
            new Point(x-size1, y + size2),
            new Point(x + size1, y+  size2),
            new Point(x - size1/2, y + size2/2),
            new Point(x + size1, y - size2),
            new Point(x , y - size2),
            };
            figure.AddPolygon(points);
            Pen pen;
            if (flag)
            {
                pen = new Pen(color, 6);
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