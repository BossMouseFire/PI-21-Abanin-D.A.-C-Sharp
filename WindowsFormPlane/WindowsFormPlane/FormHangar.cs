using NLog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormPlane
{
    public partial class FormHangar : Form
    {
        private readonly HangarCollection hangarCollection;

        private readonly Logger logger;

        public FormHangar()
        {
            InitializeComponent();
            hangarCollection = new HangarCollection(pictureBoxParking.Width, pictureBoxParking.Height);
            logger = LogManager.GetCurrentClassLogger();
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
            logger.Info($"Добавили парковку {textBoxNewLevelName.Text}");
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
                    logger.Info($"Удалили ангар{ listBoxHangars.SelectedItem.ToString()}");
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
            try
            {
                if (plane != null && listBoxHangars.SelectedIndex > -1)
                {

                    if (hangarCollection[listBoxHangars.SelectedItem.ToString()] + plane)
                    {
                        logger.Info($"Добавлен самолёт {plane}");
                        Draw();
                    }
                }
            }
            catch (HangarOverflowException ex)
            {
                MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                logger.Warn($"Ошибка при добавлении самолёта: {ex.Message}");
            }
            catch (HangarAlreadyHaveException ex)
            {
                MessageBox.Show(ex.Message, "Дублирование", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                logger.Warn($"Ошибка при добавлении самолёта: {ex.Message}");
                MessageBox.Show(ex.Message, "Неизвестная ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                try
                {
                    var plane = hangarCollection[listBoxHangars.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox.Text);
                    if (plane != null)
                    {
                        FormPlane form = new FormPlane();
                        form.SetPlane(plane);
                        form.ShowDialog();

                        logger.Info($"Изъят самолёт {plane} с места{ maskedTextBox.Text}");
                        Draw();
                    }
                }
                catch (HangarNotFoundException ex)
                {
                    logger.Warn($"Ошибка при заборе самолёта: {ex.Message}");
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (Exception ex)
                {
                    logger.Warn($"Ошибка при заборе самолёта: {ex.Message}");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
        }

        private void listBoxHangars_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Перешли в ангар { listBoxHangars.SelectedItem.ToString()}");
            Draw();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    hangarCollection.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    logger.Warn($"Ошибка при сохранении данных: {ex.Message}");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loadingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    hangarCollection.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReloadHangars();
                    Draw();
                }
                catch (FormatException ex)
                {
                    logger.Warn($"Ошибка при загрузке данных: {ex.Message}");
                    MessageBox.Show(ex.Message, "Формат файла", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                catch (TypeLoadException ex)
                {
                    logger.Warn($"Ошибка при загрузке данных: {ex.Message}");
                    MessageBox.Show(ex.Message, "Загрузка самолёта", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Warn($"Ошибка при загрузке данных: {ex.Message}");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузке",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (listBoxHangars.SelectedIndex > -1)
            {
                hangarCollection[listBoxHangars.SelectedItem.ToString()].Sort();
                Draw();
                logger.Info("Сортировка уровней");
            }

        }
    }
}
