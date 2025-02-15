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
    public partial class LihatFilm : Form
    {
        private string connectionString = @"Data Source=MSI\ABRA;Initial Catalog=CRUD_COBA;Integrated Security=True";
        public LihatFilm()
        {
            InitializeComponent();
        }

        private void LoadFilms()
        {
            flpFilms.Controls.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT id_film, judul, poster, genre, sutradara, tahun_rilis, durasi, sinopsis, rating FROM Film";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        // Ambil Data
                        string judul = row["judul"].ToString();
                        byte[] posterBytes = row["poster"] as byte[];
                        string genre = row["genre"].ToString();
                        string sutradara = row["sutradara"].ToString();
                        string tahunRilis = row["tahun_rilis"].ToString();
                        string durasi = row["durasi"].ToString();
                        string sinopsis = row["sinopsis"].ToString();
                        string rating = row["rating"].ToString();

                        // Panel untuk setiap film
                        Panel panelFilm = new Panel
                        {
                            Size = new Size(200, 450),
                            Margin = new Padding(10),
                            BorderStyle = BorderStyle.FixedSingle,
                            Cursor = Cursors.Hand
                        };

                        // Event Klik pada Panel
                        panelFilm.Click += (s, e) =>
                        {
                            MessageBox.Show($" Sinopsis : \n\n {sinopsis}");
                        };

                        // PictureBox untuk Poster
                        PictureBox pb = new PictureBox
                        {
                            Size = new Size(200, 250),
                            Location = new Point(0, 0),
                            SizeMode = PictureBoxSizeMode.StretchImage
                        };

                        if (posterBytes != null)
                        {
                            using (MemoryStream ms = new MemoryStream(posterBytes))
                            {
                                pb.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pb.Image = Properties.Resources.logo_orang;
                        }

                        // Label untuk Judul
                        Label lblJudul = new Label
                        {
                            Text = $"Judul: {judul}",
                            Size = new Size(200, 30),
                            Location = new Point(0, 260),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            AutoEllipsis = true
                        };

                        // Label untuk Genre
                        Label lblGenre = new Label
                        {
                            Text = $"Genre: {genre}",
                            Size = new Size(200, 20),
                            Location = new Point(0, 290),
                            TextAlign = ContentAlignment.MiddleLeft
                        };

                        // Label untuk Sutradara
                        Label lblSutradara = new Label
                        {
                            Text = $"Sutradara: {sutradara}",
                            Size = new Size(200, 20),
                            Location = new Point(0, 310),
                            TextAlign = ContentAlignment.MiddleLeft
                        };

                        // Label untuk Tahun Rilis
                        Label lblTahun = new Label
                        {
                            Text = $"Tahun: {tahunRilis}",
                            Size = new Size(200, 20),
                            Location = new Point(0, 330),
                            TextAlign = ContentAlignment.MiddleLeft
                        };

                        // Label untuk Durasi
                        Label lblDurasi = new Label
                        {
                            Text = $"Durasi: {durasi}",
                            Size = new Size(200, 20),
                            Location = new Point(0, 350),
                            TextAlign = ContentAlignment.MiddleLeft
                        };

                        // Label untuk Sinopsis
                        Label lblSinopsis = new Label
                        {
                            Text = $"Sinopsis: {sinopsis}",
                            Size = new Size(200, 40),
                            Location = new Point(0, 370),
                            TextAlign = ContentAlignment.TopLeft,
                            AutoEllipsis = true
                        };

                        // Label untuk Rating
                        Label lblRating = new Label
                        {
                            Text = $"Rating: {rating}",
                            Size = new Size(200, 20),
                            Location = new Point(0, 410),
                            TextAlign = ContentAlignment.MiddleLeft
                        };

                        // Tambahkan ke Panel Film
                        panelFilm.Controls.Add(pb);
                        panelFilm.Controls.Add(lblJudul);
                        panelFilm.Controls.Add(lblGenre);
                        panelFilm.Controls.Add(lblSutradara);
                        panelFilm.Controls.Add(lblTahun);
                        panelFilm.Controls.Add(lblDurasi);
                        panelFilm.Controls.Add(lblSinopsis);
                        panelFilm.Controls.Add(lblRating);

                        // Tambahkan ke FlowLayoutPanel
                        flpFilms.Controls.Add(panelFilm);
                    }
                }
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LihatFilm_Load_1(object sender, EventArgs e)
        {
            LoadFilms();
        }

        private void btnToKelola_Click(object sender, EventArgs e)
        {
            KelolaFilm kelolaFilmForm = new KelolaFilm();
            kelolaFilmForm.Show();
            this.Hide();
        }
    }
}
