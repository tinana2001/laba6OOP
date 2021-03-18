using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace laba6OOP
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage(20);
        private bool chooseShape = false; 
        private bool CtrPress = false;
        public GraphicsPath figure;
        private string NameFig = "";
        public Shape shape;
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < _storage.getCount(); i++)
                {
                    if (_storage._values[i].ChackHit(e.X, e.Y))
                    {
                        if (!CtrPress)
                        {
                            unselectedAll();
                        }
                        _storage._values[i].flag = true;
                        chooseShape = true;
                    }
                    else
                    {
                        if (!CtrPress)
                            _storage._values[i].flag = false;
                    }
                }

                   if (chooseShape == false)
                   {
                    
                        if (NameFig == "circle")
                        {
                            shape = new Circle(e.X, e.Y, 30, 30);
                            _storage.CreatItem(shape);

                        }
                        else if (NameFig == "square")
                        {
                            shape = new Square(e.X, e.Y, 35, 20);
                            _storage.CreatItem(shape);
                        }
                        else if (NameFig == "triangle")
                        {
                            shape = new Triangle(e.X, e.Y, 20, 35);
                            _storage.CreatItem(shape);
                        }
                        else if (NameFig == "strange figure")
                        {
                            shape = new SF(e.X, e.Y, 35, 35);
                            _storage.CreatItem(shape);
                        }
                    
                    if (e.X + shape.size1 >= pictureBox1.Width)
                    {
                        while (shape.x + shape.size1 >= pictureBox1.Width)
                            shape.Move(-1, 0);
                    }
                    if (e.Y + shape.size2 >= pictureBox1.Height)
                    {
                        while (shape.y + shape.size2 >= pictureBox1.Height)
                            shape.Move(0, -1);
                    }
                    if (e.X - shape.size1 <= 0)
                    {
                        while (shape.x - shape.size1 <= 0)
                            shape.Move(1, 0);
                    }
                    if (e.Y - shape.size2 <= 0)
                    {
                        while (shape.y - shape.size2 <= 0)
                            shape.Move(0, 1);
                    }

                }
               
                pictureBox1.Invalidate();
                   chooseShape = false;
            }
        }
        private void unselectedAll()
        {
            for (int i = 0; i < _storage.getCount(); i++)
            {
                if (_storage._values[i] != null)
                {
                    _storage._values[i].flag = false;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                CtrPress = true;
            }

            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < _storage.getCount(); ++i)
                {
                    if (_storage._values[i].flag)
                    {
                        _storage.DeleteItem(i);
                        i--;
                    }
                }
                pictureBox1.Invalidate();
            }
            for (int i = 0; i < _storage.getCount(); i++)
            {
                int dx=0;
                int dy=0;
                int dr=0;
                if (_storage._values[i].flag && _storage._values[i].CheckBorder(pictureBox1.Width, pictureBox1.Height) == true)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.A: dx = -1; break;
                        case Keys.D: dx = 1; break;
                        case Keys.W: dy = -1; break;
                        case Keys.S: dy = 1; break;
                        case Keys.Add: dr = 1; break;
                        case Keys.Subtract: dr = -1; break;
                    }
                }
                if (_storage._values[i].flag && _storage._values[i].CheckBorder(pictureBox1.Width, pictureBox1.Height) == false)
                {
                     switch (e.KeyCode)
                     {
                        case Keys.A: dx = 1; break;
                         case Keys.D: dx = -1; break;
                         case Keys.W: dy = 1; break;
                         case Keys.S: dy = -1; break;
                         case Keys.Add: dr = -1; break;
                         case Keys.Subtract: dr = 1; break;
                    }
                }
                _storage._values[i].Move(dx, dy);
                _storage._values[i].ChangeSize(dr);
                pictureBox1.Refresh();
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < _storage.getCount(); i++)
            {
                if (_storage._values[i] != null)
                    _storage._values[i].Draw(g);
            }
        }

        private void comboBoxShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameFig = comboBoxShape.Text;
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _storage.getCount(); i++)
            {
                if (_storage._values[i].flag)
                {

                    switch (comboBoxColor.SelectedIndex)
                    {
                        case 0:
                            _storage._values[i].color = Color.DeepPink;
                            break;
                        case 1:
                            _storage._values[i].color = Color.BlueViolet;
                            break;
                        case 2:
                            _storage._values[i].color = Color.Black;
                            break;

                    }

                }
            }
            pictureBox1.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
                CtrPress = false;
        }
    }
}


