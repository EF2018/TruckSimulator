

namespace TruckSimulator
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_GetPoints = new System.Windows.Forms.Button();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQCargo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQTruck = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameTruck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentIteration = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.myChartTimePermutation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lblIteration = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myChartTimePermutation)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Location = new System.Drawing.Point(15, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(418, 289);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // btn_GetPoints
            // 
            this.btn_GetPoints.Location = new System.Drawing.Point(603, 35);
            this.btn_GetPoints.Name = "btn_GetPoints";
            this.btn_GetPoints.Size = new System.Drawing.Size(99, 25);
            this.btn_GetPoints.TabIndex = 2;
            this.btn_GetPoints.Text = "Получить точки";
            this.btn_GetPoints.UseVisualStyleBackColor = true;
            this.btn_GetPoints.Click += new System.EventHandler(this.btn_GetPoints_Click);
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(558, 38);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(39, 20);
            this.txtIterations.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Количество итераций";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(449, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Количество грузов";
            // 
            // txtQCargo
            // 
            this.txtQCargo.Location = new System.Drawing.Point(558, 67);
            this.txtQCargo.Name = "txtQCargo";
            this.txtQCargo.Size = new System.Drawing.Size(27, 20);
            this.txtQCargo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(460, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество авто";
            // 
            // txtQTruck
            // 
            this.txtQTruck.Location = new System.Drawing.Point(558, 93);
            this.txtQTruck.Name = "txtQTruck";
            this.txtQTruck.Size = new System.Drawing.Size(27, 20);
            this.txtQTruck.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameTruck,
            this.FuelBalance});
            this.dataGridView1.Location = new System.Drawing.Point(439, 152);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(263, 178);
            this.dataGridView1.TabIndex = 9;
            // 
            // NameTruck
            // 
            this.NameTruck.HeaderText = "NameTruck";
            this.NameTruck.Name = "NameTruck";
            // 
            // FuelBalance
            // 
            this.FuelBalance.HeaderText = "FuelBalance";
            this.FuelBalance.Name = "FuelBalance";
            // 
            // CurrentIteration
            // 
            this.CurrentIteration.AutoSize = true;
            this.CurrentIteration.Location = new System.Drawing.Point(522, 136);
            this.CurrentIteration.Name = "CurrentIteration";
            this.CurrentIteration.Size = new System.Drawing.Size(0, 13);
            this.CurrentIteration.TabIndex = 10;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(591, 64);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(111, 25);
            this.btn_Start.TabIndex = 11;
            this.btn_Start.Text = "Старт/продолжить";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // myChartTimePermutation
            // 
            chartArea1.Name = "Math functions";
            this.myChartTimePermutation.ChartAreas.Add(chartArea1);
            this.myChartTimePermutation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myChartTimePermutation.Location = new System.Drawing.Point(0, 336);
            this.myChartTimePermutation.Name = "myChartTimePermutation";
            this.myChartTimePermutation.Size = new System.Drawing.Size(714, 87);
            this.myChartTimePermutation.TabIndex = 5;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItem1.Text = "Игра";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.загрузитьToolStripMenuItem.Text = "Загрузить";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lblIteration
            // 
            this.lblIteration.AutoSize = true;
            this.lblIteration.Location = new System.Drawing.Point(449, 126);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(0, 13);
            this.lblIteration.TabIndex = 12;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(603, 95);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(99, 23);
            this.btn_Stop.TabIndex = 15;
            this.btn_Stop.Text = "Стоп";
            this.btn_Stop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 423);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblIteration);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.CurrentIteration);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQTruck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQCargo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIterations);
            this.Controls.Add(this.btn_GetPoints);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.myChartTimePermutation);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myChartTimePermutation)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_GetPoints;
        private System.Windows.Forms.TextBox txtIterations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtQTruck;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label CurrentIteration;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameTruck;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelBalance;
        private System.Windows.Forms.Button btn_Start;
        public System.Windows.Forms.TextBox txtQCargo;
        private System.Windows.Forms.DataVisualization.Charting.Chart myChartTimePermutation;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label lblIteration;
        private System.Windows.Forms.Button btn_Stop;


        //private System.Diagnostics.Stopwatch Watch= new System.Diagnostics.Stopwatch();
    }
}

