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
        private ITransport plane;

        public FormPlane()
        {
            InitializeComponent();
        }

        public void SetPlane(ITransport plane)
        {
            Random rnd = new Random();
            this.plane = plane;
            plane.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxBomber.Width, pictureBoxBomber.Height);
            Draw();
         }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxBomber.Width, pictureBoxBomber.Height);
            Graphics gr = Graphics.FromImage(bmp);

            plane?.DrawTransport(gr);
            pictureBoxBomber.Image = bmp;
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    plane.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    plane.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    plane.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    plane.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }

        
    }
}
