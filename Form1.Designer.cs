namespace Garant_SN
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comBox = new System.Windows.Forms.GroupBox();
            this.baudRateList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.closePort = new System.Windows.Forms.Button();
            this.openPort = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comList = new System.Windows.Forms.ComboBox();
            this.dataFromPort = new System.Windows.Forms.TextBox();
            this.saveData = new System.Windows.Forms.Button();
            this.printData = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.retrySN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.comBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // comBox
            // 
            this.comBox.Controls.Add(this.baudRateList);
            this.comBox.Controls.Add(this.label4);
            this.comBox.Controls.Add(this.label2);
            this.comBox.Controls.Add(this.closePort);
            this.comBox.Controls.Add(this.openPort);
            this.comBox.Controls.Add(this.label3);
            this.comBox.Controls.Add(this.label1);
            this.comBox.Controls.Add(this.comList);
            this.comBox.Location = new System.Drawing.Point(12, 12);
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(346, 112);
            this.comBox.TabIndex = 0;
            this.comBox.TabStop = false;
            this.comBox.Text = "Работа с COM-портом";
            // 
            // baudRateList
            // 
            this.baudRateList.FormattingEnabled = true;
            this.baudRateList.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.baudRateList.Location = new System.Drawing.Point(75, 77);
            this.baudRateList.Name = "baudRateList";
            this.baudRateList.Size = new System.Drawing.Size(138, 21);
            this.baudRateList.TabIndex = 10;
            this.baudRateList.Text = "9600";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Скорость:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Crimson;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(219, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 82);
            this.label2.TabIndex = 8;
            // 
            // closePort
            // 
            this.closePort.Location = new System.Drawing.Point(245, 61);
            this.closePort.Name = "closePort";
            this.closePort.Size = new System.Drawing.Size(92, 39);
            this.closePort.TabIndex = 7;
            this.closePort.Text = "Закрыть";
            this.closePort.UseVisualStyleBackColor = true;
            this.closePort.Click += new System.EventHandler(this.closePort_Click);
            // 
            // openPort
            // 
            this.openPort.Location = new System.Drawing.Point(245, 18);
            this.openPort.Name = "openPort";
            this.openPort.Size = new System.Drawing.Size(92, 37);
            this.openPort.TabIndex = 6;
            this.openPort.Text = "Открыть";
            this.openPort.UseVisualStyleBackColor = true;
            this.openPort.Click += new System.EventHandler(this.openPort_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите COM-порт:";
            // 
            // comList
            // 
            this.comList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comList.FormattingEnabled = true;
            this.comList.Location = new System.Drawing.Point(10, 49);
            this.comList.Name = "comList";
            this.comList.Size = new System.Drawing.Size(203, 21);
            this.comList.TabIndex = 0;
            this.comList.Text = "Не выбран";
            // 
            // dataFromPort
            // 
            this.dataFromPort.Location = new System.Drawing.Point(12, 131);
            this.dataFromPort.Multiline = true;
            this.dataFromPort.Name = "dataFromPort";
            this.dataFromPort.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataFromPort.Size = new System.Drawing.Size(346, 375);
            this.dataFromPort.TabIndex = 1;
            // 
            // saveData
            // 
            this.saveData.Location = new System.Drawing.Point(55, 513);
            this.saveData.Name = "saveData";
            this.saveData.Size = new System.Drawing.Size(146, 33);
            this.saveData.TabIndex = 2;
            this.saveData.Text = "Сохранить";
            this.saveData.UseVisualStyleBackColor = true;
            this.saveData.Click += new System.EventHandler(this.saveData_Click);
            // 
            // printData
            // 
            this.printData.Location = new System.Drawing.Point(212, 513);
            this.printData.Name = "printData";
            this.printData.Size = new System.Drawing.Size(146, 33);
            this.printData.TabIndex = 3;
            this.printData.Text = "Распечатать";
            this.printData.UseVisualStyleBackColor = true;
            this.printData.Click += new System.EventHandler(this.printData_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // retrySN
            // 
            this.retrySN.Image = ((System.Drawing.Image)(resources.GetObject("retrySN.Image")));
            this.retrySN.Location = new System.Drawing.Point(12, 513);
            this.retrySN.Name = "retrySN";
            this.retrySN.Size = new System.Drawing.Size(33, 33);
            this.retrySN.TabIndex = 6;
            this.retrySN.UseVisualStyleBackColor = true;
            this.retrySN.Click += new System.EventHandler(this.RetrySN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(391, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 73);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(391, 110);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(112, 73);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(371, 555);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.retrySN);
            this.Controls.Add(this.printData);
            this.Controls.Add(this.saveData);
            this.Controls.Add(this.dataFromPort);
            this.Controls.Add(this.comBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Запись серийных номеров БОС";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.comBox.ResumeLayout(false);
            this.comBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox comBox;
        private System.Windows.Forms.TextBox dataFromPort;
        private System.Windows.Forms.Button saveData;
        private System.Windows.Forms.Button printData;
        private System.Windows.Forms.Button openPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closePort;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.ComboBox baudRateList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button retrySN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

