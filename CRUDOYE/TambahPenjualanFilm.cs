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
    public partial class TambahPenjualanFilm : Form
    {
        private string connectionString = @"Data Source=MSI\ABRA;Initial Catalog=CRUD_COBA;Integrated Security=True";
        private Dictionary<int, int> filmSelections = new Dictionary<int, int>();
        private Dictionary<int, (string judul, decimal harga)> filmInfo = new Dictionary<int, (string judul, decimal harga)>();
        public TambahPenjualanFilm()
        {
            InitializeComponent();
        }

        private void LihatPenjualanFilm_Load(object sender, EventArgs e)
        {
            LoadPenjualanFilms();
        }
        private void LoadPenjualanFilms()
        {
            LoadFilmSelection();
        }
        private void btnToDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();
        }
        private void LoadFilmSelection()
        {
            flpFilmSelection.Controls.Clear();
            filmInfo.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Ambil id, judul, poster, dan harga dari tabel Film
                string query = "SELECT id_film, judul, poster, harga FROM Film";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        int idFilm = Convert.ToInt32(row["id_film"]);
                        string judul = row["judul"].ToString();
                        byte[] posterBytes = row["poster"] as byte[];
                        decimal harga = Convert.ToDecimal(row["harga"]);

                        // Simpan info film di dictionary
                        filmInfo[idFilm] = (judul, harga);

                        // Buat Panel untuk setiap film
                        Panel panelFilmItem = new Panel
                        {
                            Size = new Size(180, 250),
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(10)
                        };

                        // PictureBox untuk menampilkan poster
                        PictureBox pb = new PictureBox
                        {
                            Size = new Size(180, 150),
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

                        // Label untuk judul film
                        Label lblJudul = new Label
                        {
                            Text = judul,
                            Size = new Size(180, 20),
                            Location = new Point(0, 155),
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        // Label untuk menampilkan harga
                        Label lblHarga = new Label
                        {
                            Text = $"Harga: {harga:C}",
                            Size = new Size(180, 20),
                            Location = new Point(0, 175),
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        // Label untuk menampilkan quantity yang sudah dipilih (default 0)
                        Label lblQuantity = new Label
                        {
                            Text = "Quantity: 0",
                            Size = new Size(180, 20),
                            Location = new Point(0, 195),
                            TextAlign = ContentAlignment.MiddleCenter
                        };

                        // Tombol "Pilih" untuk memilih film
                        Button btnPilih = new Button
                        {
                            Text = "Pilih",
                            Size = new Size(60, 25),
                            Location = new Point(60, 220)
                        };

                        // Event klik tombol "Pilih": tambahkan quantity dan update label serta keranjang
                        btnPilih.Click += (s, e) =>
                        {
                            if (filmSelections.ContainsKey(idFilm))
                                filmSelections[idFilm]++;
                            else
                                filmSelections[idFilm] = 1;

                            lblQuantity.Text = $"Quantity: {filmSelections[idFilm]}";
                            UpdateBasket();
                        };

                        // Tambahkan kontrol ke panel film item
                        panelFilmItem.Controls.Add(pb);
                        panelFilmItem.Controls.Add(lblJudul);
                        panelFilmItem.Controls.Add(lblHarga);
                        panelFilmItem.Controls.Add(lblQuantity);
                        panelFilmItem.Controls.Add(btnPilih);

                        // Tambahkan panel film item ke FlowLayoutPanel
                        flpFilmSelection.Controls.Add(panelFilmItem);
                    }
                }
            }
        }

        private void UpdateBasket()
        {
            pnlKeranjang.Controls.Clear();

            decimal grandTotal = 0;
            int yPos = 10;
            foreach (var entry in filmSelections)
            {
                int idFilm = entry.Key;
                int qty = entry.Value;
                if (filmInfo.ContainsKey(idFilm))
                {
                    var info = filmInfo[idFilm];
                    decimal subtotal = info.harga * qty;
                    grandTotal += subtotal;

                    Label lblItem = new Label
                    {
                        Text = $"{info.judul} x {qty} = {subtotal:C}",
                        Location = new Point(10, yPos),
                        AutoSize = true
                    };
                    pnlKeranjang.Controls.Add(lblItem);
                    yPos += 25;
                }
            }
            Label lblTotal = new Label
            {
                Text = $"Total Harga: {grandTotal:C}",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(10, yPos + 10),
                AutoSize = true
            };
            pnlKeranjang.Controls.Add(lblTotal);
        }

        private void btnToTambah_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Konversi gambar bukti pembayaran menjadi byte array, jika ada
                    byte[] buktiBytes = null;
                    if (picBukti.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            picBukti.Image.Save(ms, picBukti.Image.RawFormat);
                            buktiBytes = ms.ToArray();
                        }
                    }

                    // Simpan setiap film yang dipilih ke dalam database
                    foreach (var entry in filmSelections)
                    {
                        int idFilm = entry.Key;
                        int quantity = entry.Value;
                        decimal harga = filmInfo[idFilm].harga;
                        decimal totalTransaksi = harga * quantity;

                        using (SqlCommand cmd = new SqlCommand("spTambahPenjualan", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@TotalTransaksi", totalTransaksi);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            if (buktiBytes != null)
                                cmd.Parameters.Add("@BuktiPembayaran", SqlDbType.VarBinary, -1).Value = buktiBytes;
                            else
                                cmd.Parameters.Add("@BuktiPembayaran", SqlDbType.VarBinary, -1).Value = DBNull.Value;
                            cmd.Parameters.AddWithValue("@IdFilm", idFilm);
                            // Gunakan UserSession untuk mendapatkan id user yang login
                            cmd.Parameters.AddWithValue("@IdUser", UserSession.UserId);
                            cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Penjualan berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pnlKeranjang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPilihBukti_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Pilih Bukti Pembayaran";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picBukti.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
    }
}
