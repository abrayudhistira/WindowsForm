namespace CRUDOYE
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToFilm = new MetroFramework.Controls.MetroButton();
            this.btnToPenjualanFilm = new MetroFramework.Controls.MetroButton();
            this.chartPenjualan = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLogout = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartPenjualan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("NewsGoth Lt BT", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(350, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cinema XXI";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnToFilm
            // 
            this.btnToFilm.Location = new System.Drawing.Point(168, 368);
            this.btnToFilm.Name = "btnToFilm";
            this.btnToFilm.Size = new System.Drawing.Size(85, 43);
            this.btnToFilm.TabIndex = 6;
            this.btnToFilm.Text = "Kelola Film";
            this.btnToFilm.UseSelectable = true;
            this.btnToFilm.Click += new System.EventHandler(this.btnToFilm_Click);
            // 
            // btnToPenjualanFilm
            // 
            this.btnToPenjualanFilm.Location = new System.Drawing.Point(452, 368);
            this.btnToPenjualanFilm.Name = "btnToPenjualanFilm";
            this.btnToPenjualanFilm.Size = new System.Drawing.Size(144, 43);
            this.btnToPenjualanFilm.TabIndex = 7;
            this.btnToPenjualanFilm.Text = "Riwayat Penjualan Film";
            this.btnToPenjualanFilm.UseSelectable = true;
            this.btnToPenjualanFilm.Click += new System.EventHandler(this.btnToPenjualanFilm_Click);
            // 
            // chartPenjualan
            // 
            chartArea3.Name = "ChartArea1";
            this.chartPenjualan.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartPenjualan.Legends.Add(legend3);
            this.chartPenjualan.Location = new System.Drawing.Point(12, 49);
            this.chartPenjualan.Name = "chartPenjualan";
            this.chartPenjualan.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartPenjualan.Series.Add(series3);
            this.chartPenjualan.Size = new System.Drawing.Size(776, 300);
            this.chartPenjualan.TabIndex = 9;
            this.chartPenjualan.Text = "chart1";
            this.chartPenjualan.Click += new System.EventHandler(this.chartPenjualan_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundImage = global::CRUDOYE.Properties.Resources.logout_icon;
            this.btnLogout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.DisplayFocus = true;
            this.btnLogout.Location = new System.Drawing.Point(773, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(27, 30);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.UseSelectable = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartPenjualan);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnToPenjualanFilm);
            this.Controls.Add(this.btnToFilm);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartPenjualan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroButton btnToFilm;
        private MetroFramework.Controls.MetroButton btnToPenjualanFilm;
        private MetroFramework.Controls.MetroButton btnLogout;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPenjualan;
    }
}