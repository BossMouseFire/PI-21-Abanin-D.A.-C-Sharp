using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormPlane
{
    public partial class FormPlaneConfig : Form
    {
        Vehicle plane = null;

        private event Action<Vehicle> eventAddPlane;
        public FormPlaneConfig()
        {
            InitializeComponent();

            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }

        private void DrawPlane()
        {
            if (plane != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxPlane.Width, pictureBoxPlane.Height);
                Graphics gr = Graphics.FromImage(bmp);
                plane.SetPosition(5, 5, pictureBoxPlane.Width, pictureBoxPlane.Height);
                plane.DrawTransport(gr);
                pictureBoxPlane.Image = bmp;
            }
        }

        private void labelPlane_MouseDown(object sender, MouseEventArgs e)
        {
            labelPlane.DoDragDrop(labelPlane.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelBomber_MouseDown(object sender, MouseEventArgs e)
        {
            labelBomber.DoDragDrop(labelBomber.Text, DragDropEffects.Move | DragDropEffects.Copy);

        }

        private void panelPlane_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panelPlane_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный самолёт":
                    plane = new Plane(100, 100, Color.Black);
                    break;
                case "Бомбардировщик":
                    plane = new Bomber(100, 100, Color.Black, Color.Red, true, true);
                    break;
            }
            DrawPlane();
        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            panel.DoDragDrop(panel.BackColor, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            var color = e.Data.GetData(typeof(Color));
            if (color != null && plane != null)
            {
                plane.SetMainColor((Color)color);
                DrawPlane();
            }
        }

        private void labelAddColor_DragDrop(object sender, DragEventArgs e)
        {
            var color = e.Data.GetData(typeof(Color));
            Bomber bomber = plane as Bomber;
            if (color != null && bomber != null)
            {
                bomber.SetAddColor((Color)color);
                DrawPlane();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            eventAddPlane?.Invoke(plane);
            Close();
        }

        public void AddEvent(Action<Vehicle> ev)
        {
            if (eventAddPlane == null)
            {
                eventAddPlane = ev;
            }
            else
            {
                eventAddPlane += ev;
            }
        }

        private void numericMaxSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (plane != null)
            {
                int speed = Convert.ToInt32(numericMaxSpeed.Value);
                plane.MaxSpeed = speed;
            }
        }

        private void numericWeightPlane_ValueChanged(object sender, EventArgs e)
        {
            if (plane != null)
            {
                int weight = Convert.ToInt32(numericWeightPlane.Value);
                plane.Weight = weight;
            }
        }

        private void checkBoxBombs_CheckedChanged(object sender, EventArgs e)
        {
            Bomber bomber = plane as Bomber;
            if (bomber != null)
            {
                bomber.StateBombs = checkBoxBombs.Checked;
                DrawPlane();
            }
        }

        private void checkBoxRadar_CheckedChanged(object sender, EventArgs e)
        {
            Bomber bomber = plane as Bomber;
            if (bomber != null)
            {
                bomber.StateGun = checkBoxRadar.Checked;
                DrawPlane();
            }
        }
    }
}
