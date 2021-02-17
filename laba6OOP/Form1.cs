using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba6OOP
{
    public partial class Form1 : Form
    {
        private Storage _storage = new Storage(20);
        private bool chooseShape = false; //нужен чтобы при нажатии ctrl при попадании в фигуру новые объекты не создавались
        bool CtrPress = false;
        public string NameFig = "";
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
                    if (_storage._values[i].CheckPoint(e.X, e.Y))
                    {
                        if (!CtrPress)
                        {
                            unselectedAll();
                        }
                        if (_storage._values[i].flag)
                            _storage._values[i].flag = false;
                        else
                            _storage._values[i].flag = true;
                        chooseShape = true;
                    }
                    else
                    {
                        if (!CtrPress)
                            _storage._values[i].flag = false;//чтобы выделялся жирным ТОЛЬКО первый 
                    }
                }

                if (chooseShape == false)
                {
                    if (e.X + 35 <= pictureBox1.Width && e.Y + 35 <= pictureBox1.Height && e.X - 35 >= (pictureBox1.Width - pictureBox1.Width) && e.Y - 35 >= (pictureBox1.Height - pictureBox1.Height))
                    {
                        if (NameFig == "circle")
                        {
                            Circle circle = new Circle(e.X, e.Y, 35);
                            circle.flag = true;
                            _storage.CreatItem(circle);
                        }
                        else if (NameFig == "square")
                        {
                            Square square = new Square(e.X, e.Y, 35);
                            square.flag = true;
                            _storage.CreatItem(square);
                        }

                    }

                }
                pictureBox1.Refresh();
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

                pictureBox1.Refresh();
            }
            pictureBox1.Focus();
            for (int i = 0; i < _storage.getCount(); i++)
            {

                if (_storage._values[i].flag && _storage._values[i].CheckBorder(pictureBox1.Width, pictureBox1.Height)==true)
                {
                    int dx = 0;
                    int dy = 0;
                    switch (e.KeyCode)
                    {
                        case Keys.A: dx = -5; break;
                        case Keys.D: dx = 5; break;
                        case Keys.W: dy = -5; break;
                        case Keys.S: dy = 5; break;
                    }
                    if (_storage._values[i].flag&&_storage._values[i].CheckBorder(pictureBox1.Width, pictureBox1.Height)==false)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.A: dx = 5; break;
                            case Keys.D: dx = -5; break;
                            case Keys.W: dy = 5; break;
                            case Keys.S: dy = -5; break;
                        }
                    }
                    _storage._values[i].Move(dx, dy);
                    
                }


                if (_storage._values[i].flag && _storage._values[i].CheckBorder(pictureBox1.Width, pictureBox1.Height))
                {
                    int dr = 0;

                    if (e.KeyCode == Keys.Z)
                    {
                        dr = 1;
                    }
                    else if (e.KeyCode == Keys.Q)
                    {
                        dr = -1;
                    }
                    _storage._values[i].ChangeR(dr);

                    if (!_storage._values[i].CheckBorder(pictureBox1.Width, pictureBox1.Height))
                    {
                        if (e.KeyCode == Keys.Z)
                        {

                            dr = -1;
                        }
                        else if (e.KeyCode == Keys.Q)
                        {
                            dr = 1;
                        }
                        _storage._values[i].ChangeR(dr);
                    }
                    pictureBox1.Refresh();
                }
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
                            Color color = Color.DeepPink;

                            break;
                        case 1:
                            _storage._values[i].color = Color.BlueViolet;
                            Color color1 = Color.BlueViolet;

                            break;
                        case 2:
                            _storage._values[i].color = Color.Black;
                            Color color2 = Color.Black;
                            break;

                    }

                }
            }
            pictureBox1.Refresh();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
                CtrPress = false;
        }
    }
}


