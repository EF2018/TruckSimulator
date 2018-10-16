using System.Drawing;

namespace TruckSimulatorPL
{
    partial class MapFrm
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
            this.btn_Stop = new System.Windows.Forms.Button();
            this.lblIteration = new System.Windows.Forms.Label();
            this.btn_Start = new System.Windows.Forms.Button();
            this.CurrentIteration = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NameTruck = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQTruck = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQCargo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.btn_GetPoints = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMapName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Location = new System.Drawing.Point(546, 101);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(99, 23);
            this.btn_Stop.TabIndex = 28;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // lblIteration
            // 
            this.lblIteration.AutoSize = true;
            this.lblIteration.Location = new System.Drawing.Point(392, 132);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(0, 13);
            this.lblIteration.TabIndex = 27;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(546, 70);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(99, 25);
            this.btn_Start.TabIndex = 26;
            this.btn_Start.Text = "Start/Continue";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // CurrentIteration
            // 
            this.CurrentIteration.AutoSize = true;
            this.CurrentIteration.Location = new System.Drawing.Point(465, 142);
            this.CurrentIteration.Name = "CurrentIteration";
            this.CurrentIteration.Size = new System.Drawing.Size(0, 13);
            this.CurrentIteration.TabIndex = 25;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameTruck,
            this.FuelBalance});
            this.dataGridView1.Location = new System.Drawing.Point(382, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(263, 175);
            this.dataGridView1.TabIndex = 24;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Количество авто";
            // 
            // txtQTruck
            // 
            this.txtQTruck.Location = new System.Drawing.Point(501, 99);
            this.txtQTruck.Name = "txtQTruck";
            this.txtQTruck.Size = new System.Drawing.Size(39, 20);
            this.txtQTruck.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Количество грузов";
            // 
            // txtQCargo
            // 
            this.txtQCargo.Location = new System.Drawing.Point(501, 73);
            this.txtQCargo.Name = "txtQCargo";
            this.txtQCargo.Size = new System.Drawing.Size(39, 20);
            this.txtQCargo.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(379, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Количество итераций";
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(501, 45);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(39, 20);
            this.txtIterations.TabIndex = 18;
            // 
            // btn_GetPoints
            // 
            this.btn_GetPoints.Location = new System.Drawing.Point(546, 42);
            this.btn_GetPoints.Name = "btn_GetPoints";
            this.btn_GetPoints.Size = new System.Drawing.Size(99, 25);
            this.btn_GetPoints.TabIndex = 17;
            this.btn_GetPoints.Text = "Get new points";
            this.btn_GetPoints.UseVisualStyleBackColor = true;
            this.btn_GetPoints.Click += new System.EventHandler(this.btn_GetNewPoints_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 289);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(661, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem1.Text = "Map";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.сохранитьToolStripMenuItem.Text = "Save map";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.SaveMapToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.загрузитьToolStripMenuItem.Text = "Load map";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.LoadMapToolStripMenuItem_Click);
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMapName.Location = new System.Drawing.Point(16, 36);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(0, 9);
            this.lblMapName.TabIndex = 30;
            this.lblMapName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MapFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 376);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btn_Stop);
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
            this.Name = "MapFrm";
            this.Text = "TruckSimulator 2018";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Label lblIteration;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label CurrentIteration;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameTruck;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelBalance;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtQTruck;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtQCargo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIterations;
        private System.Windows.Forms.Button btn_GetPoints;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.Label lblMapName;
    }
}