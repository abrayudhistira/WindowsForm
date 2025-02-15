using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDOYE
{
    public partial class KelolaFilm : Form
    {
        private string connectionString = @"Data Source=MSI\ABRA;Initial Catalog=CRUD_COBA;Integrated Security=True";
        public KelolaFilm()
        {
            InitializeComponent();
        }

        private void KelolaFilm_Load(object sender, EventArgs e)
        {

        }

        private void btnTambahFilm_Click(object sender, EventArgs e)
        {
            string judul = textJudul.Text;
            string genre = textGenre.Text;
            string sutradara = textSutradara.Text;
            int tahunRilis;
            int durasi;
            string sinopsis = textSinopsis.Text;
            decimal rating;

            // Validasi input
            if (string.IsNullOrEmpty(judul) || string.IsNullOrEmpty(genre) || string.IsNullOrEmpty(sutradara) ||
                !int.TryParse(textTahunRilis.Text, out tahunRilis) || !int.TryParse(textDurasi.Text, out durasi) ||
                !decimal.TryParse(textRating.Text, out rating))
            {
                MessageBox.Show("Semua kolom harus diisi dengan benar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Konversi gambar poster menjadi byte array (jika ada)
            byte[] posterBytes = null;
            if (picPoster.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Simpan gambar ke stream dengan format aslinya
                    picPoster.Image.Save(ms, picPoster.Image.RawFormat);
                    posterBytes = ms.ToArray();
                }
            }

            // Insert ke database
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO Film (judul, genre, sutradara, tahun_rilis, durasi, sinopsis, rating, poster) " +
                                   "VALUES (@Judul, @Genre, @Sutradara, @TahunRilis, @Durasi, @Sinopsis, @Rating, @Poster)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Judul", judul);
                    cmd.Parameters.AddWithValue("@Genre", genre);
                    cmd.Parameters.AddWithValue("@Sutradara", sutradara);
                    cmd.Parameters.AddWithValue("@TahunRilis", tahunRilis);
                    cmd.Parameters.AddWithValue("@Durasi", durasi);
                    cmd.Parameters.AddWithValue("@Sinopsis", sinopsis);
                    cmd.Parameters.AddWithValue("@Rating", rating);

                    // Jika posterBytes null, masukkan DBNull.Value
                    if (posterBytes != null)
                        cmd.Parameters.AddWithValue("@Poster", posterBytes);
                    else
                        cmd.Parameters.AddWithValue("@Poster", DBNull.Value);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Film berhasil ditambahkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Gagal menambahkan film.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPilihPoster_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Pilih Gambar Poster";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picPoster.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnToDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void btnLihatFilm_Click(object sender, EventArgs e)
        {
            LihatFilm lihatFilmForm = new LihatFilm();
            lihatFilmForm.Show();
            this.Hide();
        }
    }
}
