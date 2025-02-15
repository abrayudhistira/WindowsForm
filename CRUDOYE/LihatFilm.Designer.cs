namespace CRUDOYE
{
    partial class LihatFilm
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
            this.flpFilms = new System.Windows.Forms.FlowLayoutPanel();
            this.btnToKelola = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // flpFilms
            // 
            this.flpFilms.AutoScroll = true;
            this.flpFilms.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpFilms.Location = new System.Drawing.Point(87, 0);
            this.flpFilms.Name = "flpFilms";
            this.flpFilms.Size = new System.Drawing.Size(767, 472);
            this.flpFilms.TabIndex = 0;
            // 
            // btnToKelola
            // 
            this.btnToKelola.Location = new System.Drawing.Point(-4, 0);
            this.btnToKelola.Name = "btnToKelola";
            this.btnToKelola.Size = new System.Drawing.Size(85, 36);
            this.btnToKelola.TabIndex = 1;
            this.btnToKelola.Text = "Kembali";
            this.btnToKelola.UseSelectable = true;
            this.btnToKelola.Click += new System.EventHandler(this.btnToKelola_Click);
            // 
            // LihatFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 472);
            this.Controls.Add(this.btnToKelola);
            this.Controls.Add(this.flpFilms);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "LihatFilm";
            this.Text = "LihatFilm";
            this.Load += new System.EventHandler(this.LihatFilm_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpFilms;
        private MetroFramework.Controls.MetroButton btnToKelola;
    }
}