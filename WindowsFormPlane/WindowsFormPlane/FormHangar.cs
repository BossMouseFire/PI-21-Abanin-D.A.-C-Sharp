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
    public partial class FormHangar : Form
    {
        private readonly HangarCollection hangarCollection;

        public FormHangar()
        {
            InitializeComponent();
            hangarCollection = new HangarCollection(pictureBoxParking.Width, pictureBoxParking.Height);
            Draw();
        }


        private void ReloadHangars()
        {
            int index = listBoxHangars.SelectedIndex;
            listBoxHangars.Items.Clear();
            for (int i = 0; i < hangarCollection.Keys.Count; i++)
            {
                listBoxHangars.Items.Add(hangarCollection.Keys[i]);
            }
            if (listBoxHangars.Items.Count > 0 && (index == -1 || index >=
           listBoxHangars.Items.Count))
            {
                listBoxHangars.SelectedIndex = 0;
            }
            else if (listBoxHangars.Items.Count > 0 && index > -1 && index <
           listBoxHangars.Items.Count)
            {
                listBoxHangars.SelectedIndex = index;
            }
        }


        /// <summary>
        /// Метод отрисовки ангара
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            if (listBoxHangars.SelectedIndex > -1)
            {
                hangarCollection[listBoxHangars.SelectedItem.ToString()].Draw(gr);
                pictureBoxParking.Image = bmp;
            } else
            {
                pictureBoxParking.Image = bmp;
            }
        }

        private void buttonAddHangar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
            {
                MessageBox.Show("Введите название ангара", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            hangarCollection.AddHangar(textBoxNewLevelName.Text);
            ReloadHangars();
        }
        private void buttonDelHangar_Click(object sender, EventArgs e)
        {
            if (listBoxHangars.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить ангар { listBoxHangars.SelectedItem.ToString()}?", 
                    "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    hangarCollection.DelHangar(listBoxHangars.SelectedItem.ToString());
                    ReloadHangars();
                }
                Draw();
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать самолёт"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void buttonSetPlane_Click(object sender, EventArgs e)
        {
            if (listBoxHangars.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var plane = new Plane(100, 1000, dialog.Color);
                    if (hangarCollection[listBoxHangars.SelectedItem.ToString()] + plane)
                    {
                        Draw();
                    }
                    else
                    {
                        MessageBox.Show("Ангар переполнен");
                    }
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать бомбардировщик"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetBomber_Click(object sender, EventArgs e)
        {
            if (listBoxHangars.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var plane = new Bomber(100, 1000, dialog.Color, dialogDop.Color,
                        true, true);
                        if (hangarCollection[listBoxHangars.SelectedItem.ToString()] + plane)
                        {
                            Draw();
                        }
                        else
                        {
                            MessageBox.Show("Ангар переполнен");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakePlane_Click(object sender, EventArgs e)
        {
            if (listBoxHangars.SelectedIndex > -1 && maskedTextBox.Text != "")
            {
                var plane = hangarCollection[listBoxHangars.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox.Text);

                if (plane != null)
                {
                    FormPlane form = new FormPlane();
                    form.SetPlane(plane);
                    form.ShowDialog();
                }
                Draw();
            }
        }

        private void listBoxHangars_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
