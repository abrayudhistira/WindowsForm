namespace CRUDOYE
{
    partial class LihatPenjualanFilm
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
            this.btnToDashboard = new MetroFramework.Controls.MetroButton();
            this.btnToTambah = new MetroFramework.Controls.MetroButton();
            this.flpPenjualan = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btnToDashboard
            // 
            this.btnToDashboard.Location = new System.Drawing.Point(-2, -3);
            this.btnToDashboard.Name = "btnToDashboard";
            this.btnToDashboard.Size = new System.Drawing.Size(96, 46);
            this.btnToDashboard.TabIndex = 0;
            this.btnToDashboard.Text = "Kembali";
            this.btnToDashboard.UseSelectable = true;
            this.btnToDashboard.Click += new System.EventHandler(this.btnToDashboard_Click);
            // 
            // btnToTambah
            // 
            this.btnToTambah.Location = new System.Drawing.Point(-2, 126);
            this.btnToTambah.Name = "btnToTambah";
            this.btnToTambah.Size = new System.Drawing.Size(96, 46);
            this.btnToTambah.TabIndex = 1;
            this.btnToTambah.Text = "Tambah";
            this.btnToTambah.UseSelectable = true;
            this.btnToTambah.Click += new System.EventHandler(this.btnToTambah_Click);
            // 
            // flpPenjualan
            // 
            this.flpPenjualan.AutoScroll = true;
            this.flpPenjualan.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpPenjualan.Location = new System.Drawing.Point(100, 0);
            this.flpPenjualan.Name = "flpPenjualan";
            this.flpPenjualan.Size = new System.Drawing.Size(700, 450);
            this.flpPenjualan.TabIndex = 2;
            this.flpPenjualan.Paint += new System.Windows.Forms.PaintEventHandler(this.flpPenjualan_Paint);
            // 
            // LihatPenjualanFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flpPenjualan);
            this.Controls.Add(this.btnToTambah);
            this.Controls.Add(this.btnToDashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LihatPenjualanFilm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LihatPenjualanFilm";
            this.Load += new System.EventHandler(this.LihatPenjualanFilm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnToDashboard;
        private MetroFramework.Controls.MetroButton btnToTambah;
        private System.Windows.Forms.FlowLayoutPanel flpPenjualan;
    }
}