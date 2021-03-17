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
        private string NameFig = "";
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
                       if (e.X + 35 <= pictureBox1.Width && e.Y + 35 <= pictureBox1.Height && e.X - 35 >= 0 && e.Y - 35 >= 0)
                       {
                           if (NameFig == "circle")
                           {
                                    Circle circle = new Circle(e.X, e.Y, 35);
                                    _storage.CreatItem(circle);
                           }
                           else if (NameFig == "square")
                           {
                                    Square square = new Square(e.X, e.Y, 35);
                                    _storage.CreatItem(square);
                           } 
                           else if (NameFig == "triangle")
                        {
                            Triangle triangle = new Triangle(e.X, e.Y, 35);
                            _storage.CreatItem(triangle);
                        }
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
                int dx = 0;
                int dy = 0;
                int dr = 0;
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
                _storage._values[i].ChangeR(dr);
                pictureBox1.Invalidate();
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


