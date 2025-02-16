namespace CRUDOYE
{
    partial class TambahPenjualanFilm
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
            this.flpFilmSelection = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlKeranjang = new System.Windows.Forms.Panel();
            this.btnPilihBukti = new MetroFramework.Controls.MetroButton();
            this.picBukti = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBukti)).BeginInit();
            this.SuspendLayout();
            // 
            // btnToDashboard
            // 
            this.btnToDashboard.Location = new System.Drawing.Point(-1, -3);
            this.btnToDashboard.Name = "btnToDashboard";
            this.btnToDashboard.Size = new System.Drawing.Size(97, 37);
            this.btnToDashboard.TabIndex = 0;
            this.btnToDashboard.Text = "Kembali";
            this.btnToDashboard.UseSelectable = true;
            this.btnToDashboard.Click += new System.EventHandler(this.btnToDashboard_Click);
            // 
            // btnToTambah
            // 
            this.btnToTambah.Location = new System.Drawing.Point(215, 244);
            this.btnToTambah.Name = "btnToTambah";
            this.btnToTambah.Size = new System.Drawing.Size(97, 37);
            this.btnToTambah.TabIndex = 1;
            this.btnToTambah.Text = "Checkout";
            this.btnToTambah.UseSelectable = true;
            this.btnToTambah.Click += new System.EventHandler(this.btnToTambah_Click);
            // 
            // flpFilmSelection
            // 
            this.flpFilmSelection.AutoScroll = true;
            this.flpFilmSelection.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpFilmSelection.Location = new System.Drawing.Point(406, 0);
            this.flpFilmSelection.Name = "flpFilmSelection";
            this.flpFilmSelection.Size = new System.Drawing.Size(698, 467);
            this.flpFilmSelection.TabIndex = 2;
            // 
            // pnlKeranjang
            // 
            this.pnlKeranjang.AutoScroll = true;
            this.pnlKeranjang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKeranjang.Location = new System.Drawing.Point(8, 316);
            this.pnlKeranjang.Name = "pnlKeranjang";
            this.pnlKeranjang.Size = new System.Drawing.Size(377, 148);
            this.pnlKeranjang.TabIndex = 3;
            this.pnlKeranjang.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlKeranjang_Paint);
            // 
            // btnPilihBukti
            // 
            this.btnPilihBukti.Location = new System.Drawing.Point(8, 287);
            this.btnPilihBukti.Name = "btnPilihBukti";
            this.btnPilihBukti.Size = new System.Drawing.Size(75, 23);
            this.btnPilihBukti.TabIndex = 5;
            this.btnPilihBukti.Text = "Browse";
            this.btnPilihBukti.UseSelectable = true;
            this.btnPilihBukti.Click += new System.EventHandler(this.btnPilihBukti_Click);
            // 
            // picBukti
            // 
            this.picBukti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBukti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBukti.Location = new System.Drawing.Point(8, 145);
            this.picBukti.Name = "picBukti";
            this.picBukti.Size = new System.Drawing.Size(131, 136);
            this.picBukti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBukti.TabIndex = 4;
            this.picBukti.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.792453F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bukti Pembayaran";
            // 
            // LihatPenjualanFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 467);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPilihBukti);
            this.Controls.Add(this.picBukti);
            this.Controls.Add(this.pnlKeranjang);
            this.Controls.Add(this.flpFilmSelection);
            this.Controls.Add(this.btnToTambah);
            this.Controls.Add(this.btnToDashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LihatPenjualanFilm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LihatPenjualanFilm";
            this.Load += new System.EventHandler(this.LihatPenjualanFilm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBukti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnToDashboard;
        private MetroFramework.Controls.MetroButton btnToTambah;
        private System.Windows.Forms.FlowLayoutPanel flpFilmSelection;
        private System.Windows.Forms.Panel pnlKeranjang;
        private System.Windows.Forms.PictureBox picBukti;
        private MetroFramework.Controls.MetroButton btnPilihBukti;
        private System.Windows.Forms.Label label1;
    }
}