namespace WindowsFormPlane
{
    partial class FormHangar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxParking = new System.Windows.Forms.PictureBox();
            this.buttonSetPlane = new System.Windows.Forms.Button();
            this.buttonSetBomber = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonTakePlane = new System.Windows.Forms.Button();
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNewLevelName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddHangar = new System.Windows.Forms.Button();
            this.listBoxHangars = new System.Windows.Forms.ListBox();
            this.buttonDelHangar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxParking
            // 
            this.pictureBoxParking.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBoxParking.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxParking.Name = "pictureBoxParking";
            this.pictureBoxParking.Size = new System.Drawing.Size(673, 450);
            this.pictureBoxParking.TabIndex = 0;
            this.pictureBoxParking.TabStop = false;
            // 
            // buttonSetPlane
            // 
            this.buttonSetPlane.Location = new System.Drawing.Point(679, 228);
            this.buttonSetPlane.Name = "buttonSetPlane";
            this.buttonSetPlane.Size = new System.Drawing.Size(109, 40);
            this.buttonSetPlane.TabIndex = 1;
            this.buttonSetPlane.Text = "Припарковать самолёт";
            this.buttonSetPlane.UseVisualStyleBackColor = true;
            this.buttonSetPlane.Click += new System.EventHandler(this.buttonSetPlane_Click);
            // 
            // buttonSetBomber
            // 
            this.buttonSetBomber.Location = new System.Drawing.Point(679, 274);
            this.buttonSetBomber.Name = "buttonSetBomber";
            this.buttonSetBomber.Size = new System.Drawing.Size(109, 47);
            this.buttonSetBomber.TabIndex = 2;
            this.buttonSetBomber.Text = "Припарковать бомбардировщик";
            this.buttonSetBomber.UseVisualStyleBackColor = true;
            this.buttonSetBomber.Click += new System.EventHandler(this.buttonSetBomber_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonTakePlane);
            this.groupBox1.Controls.Add(this.maskedTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(679, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Забрать самолёт";
            // 
            // buttonTakePlane
            // 
            this.buttonTakePlane.Location = new System.Drawing.Point(10, 62);
            this.buttonTakePlane.Name = "buttonTakePlane";
            this.buttonTakePlane.Size = new System.Drawing.Size(75, 23);
            this.buttonTakePlane.TabIndex = 2;
            this.buttonTakePlane.Text = "Забрать";
            this.buttonTakePlane.UseVisualStyleBackColor = true;
            this.buttonTakePlane.Click += new System.EventHandler(this.buttonTakePlane_Click);
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Location = new System.Drawing.Point(55, 36);
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(29, 20);
            this.maskedTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Место:";
            // 
            // textBoxNewLevelName
            // 
            this.textBoxNewLevelName.Location = new System.Drawing.Point(679, 25);
            this.textBoxNewLevelName.Name = "textBoxNewLevelName";
            this.textBoxNewLevelName.Size = new System.Drawing.Size(114, 20);
            this.textBoxNewLevelName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(712, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ангары:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddHangar
            // 
            this.buttonAddHangar.Location = new System.Drawing.Point(679, 52);
            this.buttonAddHangar.Name = "buttonAddHangar";
            this.buttonAddHangar.Size = new System.Drawing.Size(114, 23);
            this.buttonAddHangar.TabIndex = 6;
            this.buttonAddHangar.Text = "Добавить ангар";
            this.buttonAddHangar.UseVisualStyleBackColor = true;
            this.buttonAddHangar.Click += new System.EventHandler(this.buttonAddHangar_Click);
            // 
            // listBoxHangars
            // 
            this.listBoxHangars.FormattingEnabled = true;
            this.listBoxHangars.Location = new System.Drawing.Point(679, 81);
            this.listBoxHangars.Name = "listBoxHangars";
            this.listBoxHangars.Size = new System.Drawing.Size(114, 95);
            this.listBoxHangars.TabIndex = 7;
            this.listBoxHangars.SelectedIndexChanged += new System.EventHandler(this.listBoxHangars_SelectedIndexChanged);
            // 
            // buttonDelHangar
            // 
            this.buttonDelHangar.Location = new System.Drawing.Point(679, 183);
            this.buttonDelHangar.Name = "buttonDelHangar";
            this.buttonDelHangar.Size = new System.Drawing.Size(114, 23);
            this.buttonDelHangar.TabIndex = 8;
            this.buttonDelHangar.Text = "Удалить ангар";
            this.buttonDelHangar.UseVisualStyleBackColor = true;
            this.buttonDelHangar.Click += new System.EventHandler(this.buttonDelHangar_Click);
            // 
            // FormHangar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDelHangar);
            this.Controls.Add(this.listBoxHangars);
            this.Controls.Add(this.buttonAddHangar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewLevelName);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSetBomber);
            this.Controls.Add(this.buttonSetPlane);
            this.Controls.Add(this.pictureBoxParking);
            this.Name = "FormHangar";
            this.Text = "Парковка";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParking)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxParking;
        private System.Windows.Forms.Button buttonSetPlane;
        private System.Windows.Forms.Button buttonSetBomber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonTakePlane;
        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNewLevelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddHangar;
        private System.Windows.Forms.ListBox listBoxHangars;
        private System.Windows.Forms.Button buttonDelHangar;
    }
}