﻿using System;
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
                       shape = new Circle(e.X, e.Y, 35, 35);
                       _storage.CreatItem(shape);
                    }
                    if (NameFig == "square")
                    {
                        shape = new Square(e.X, e.Y, 35, 20);
                        _storage.CreatItem(shape);
                    }
                    if (NameFig == "triangle")
                    {
                        shape = new Triangle(e.X, e.Y, 20, 35);
                         _storage.CreatItem(shape);
                    }
                    if (NameFig == "strange figure")
                    {
                        shape = new SF(e.X, e.Y, 35, 35);
                         _storage.CreatItem(shape);
                    }
                    
                    if (e.X + shape.size1 >= pictureBox1.Width)
                    {
                        while (shape.x + shape.size1 >= pictureBox1.Width)
                            shape.Move(-2, 0);
                    }
                    if (e.Y + shape.size2 >= pictureBox1.Height)
                    {
                        while (shape.y + shape.size2 >= pictureBox1.Height)
                            shape.Move(0, -2);
                    }
                    if (e.X - shape.size1 <= 0)
                    {
                        while (shape.x - shape.size1 <= 0)
                            shape.Move(2, 0);
                    }
                    if (e.Y - shape.size2 <= 0)
                    {
                        while (shape.y - shape.size2 <= 0)
                            shape.Move(0, 2);
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

                if (_storage._values[i].flag)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.A:
                            if (shape.figure.GetBounds().X > 5)
                                dx = -5; break;
                        case Keys.D:
                            if (shape.figure.GetBounds().X + shape.figure.GetBounds().Width < pictureBox1.Width - 5)
                                dx = 5; break;
                        case Keys.W:
                            if (shape.figure.GetBounds().Y > 5)
                                dy = -5; break;
                        case Keys.S:
                            if (shape.figure.GetBounds().Y + shape.figure.GetBounds().Height < pictureBox1.Height - 5)
                                dy = 5; break;
                        case Keys.Add:
                            if ((shape.figure.GetBounds().X + shape.figure.GetBounds().Width < pictureBox1.Width) && (shape.figure.GetBounds().X > 0) && (shape.figure.GetBounds().Y > 0) && (shape.figure.GetBounds().Y + shape.figure.GetBounds().Height < pictureBox1.Height))
                                dr = 5; break;
                        case Keys.Subtract:
                            if ((shape.size1 > 5) && (shape.size2 > 5))
                                dr = -5; break;
                    }
                }
                _storage._values[i].Move(dx, dy);
                _storage._values[i].ChangeSize(dr, dr);
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


