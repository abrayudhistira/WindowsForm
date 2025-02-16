using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDOYE
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnTambahFilm_Click(object sender, EventArgs e)
        {

        }

        private void btnEditFilm_Click(object sender, EventArgs e)
        {

        }

        private void btnLihatFilm_Click(object sender, EventArgs e)
        {

        }

        private void btnHapusFilm_Click(object sender, EventArgs e)
        {

        }

        private void btnToFilm_Click(object sender, EventArgs e)
        {
            LihatFilm lihatFilmForm = new LihatFilm();
            lihatFilmForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}
