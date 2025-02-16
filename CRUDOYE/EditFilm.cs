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
    public partial class EditFilm : Form
    {
        private string connectionString = @"Data Source=MSI\ABRA;Initial Catalog=CRUD_COBA;Integrated Security=True";
        private int idFilm;
        public EditFilm(int id)
        {
            InitializeComponent();
            idFilm = id;
            LoadFilmData();
        }
        private void LoadFilmData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Film WHERE id_film = @id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", idFilm);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtJudul.Text = reader["judul"].ToString();
                        txtGenre.Text = reader["genre"].ToString();
                        txtSutradara.Text = reader["sutradara"].ToString();
                        txtTahunRilis.Text = reader["tahun_rilis"].ToString();
                        txtDurasi.Text = reader["durasi"].ToString();
                        txtSinopsis.Text = reader["sinopsis"].ToString();
                        txtRating.Text = reader["rating"].ToString();
                        textHarga.Text = reader["harga"].ToString();

                        byte[] posterBytes = reader["poster"] as byte[];
                        if (posterBytes != null)
                        {
                            using (MemoryStream ms = new MemoryStream(posterBytes))
                            {
                                pbPoster.Image = Image.FromStream(ms);
                            }
                        }
                    }
                }
            }
        }
        private void EditFilm_Load(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbPoster.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("spEditFilm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_film", idFilm);
                    cmd.Parameters.AddWithValue("@judul", txtJudul.Text);
                    cmd.Parameters.AddWithValue("@genre", txtGenre.Text);
                    cmd.Parameters.AddWithValue("@sutradara", txtSutradara.Text);
                    cmd.Parameters.AddWithValue("@tahun_rilis", txtTahunRilis.Text);
                    cmd.Parameters.AddWithValue("@durasi", txtDurasi.Text);
                    cmd.Parameters.AddWithValue("@sinopsis", txtSinopsis.Text);
                    cmd.Parameters.AddWithValue("@rating", txtRating.Text);
                    cmd.Parameters.AddWithValue("@harga", textHarga.Text);

                    // Convert image to byte array
                    if (pbPoster.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pbPoster.Image.Save(ms, pbPoster.Image.RawFormat);
                            cmd.Parameters.AddWithValue("@poster", ms.ToArray());
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@poster", DBNull.Value);
                    }

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data berhasil diupdate!");
                    this.Close();
                }
            }
        }
    }
}
