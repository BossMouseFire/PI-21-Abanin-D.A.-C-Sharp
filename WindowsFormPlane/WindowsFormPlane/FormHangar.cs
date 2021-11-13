using System;
using System.Drawing;
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
            var formPlaneConfig = new FormPlaneConfig();
            formPlaneConfig.AddEvent(AddPlane);
            formPlaneConfig.Show();
        }
       
        private void AddPlane (Vehicle plane)
        {
            if (plane != null && listBoxHangars.SelectedIndex > -1)
            {
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (hangarCollection.SaveData(saveFileDialog.FileName))
                {
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не сохранилось", "Результат",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (hangarCollection.LoadData(openFileDialog.FileName))
                {
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadHangars();
                    Draw();
                }
                else
                {
                    MessageBox.Show("Не загрузили", "Результат", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
