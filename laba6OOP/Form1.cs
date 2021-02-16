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
                    Circle circle = new Circle(e.X, e.Y, 35);
                    circle.flag = true; //для того, чтобы при создании выделялся созданный элемент
                    _storage.CreatItem(circle);
                }
                pictureBox1.Refresh();
                chooseShape = false;
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
            ////
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < _storage.getCount(); i++)
            {
                if (_storage._values[i] != null)
                    _storage.getObj(i).Draw(g);
            }
        }

        private void comboBoxShape_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
                CtrPress = false;
        }

    }
}


