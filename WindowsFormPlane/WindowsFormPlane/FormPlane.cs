using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormPlane
{
    public partial class FormPlane : Form
    {
        private Bomber bomber;

        public FormPlane()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBomber.Width, pictureBoxBomber.Height);
            Graphics gr = Graphics.FromImage(bmp);

            bomber.DrawBomber(gr);
            pictureBoxBomber.Image = bmp;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            bomber = new Bomber();
            bomber.Init(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Black, Color.DarkRed, true, true);
            bomber.SetPosition(100, 100, pictureBoxBomber.Width, pictureBoxBomber.Height);

            Draw();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    bomber.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    bomber.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    bomber.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    bomber.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
