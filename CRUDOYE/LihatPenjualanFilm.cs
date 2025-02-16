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
    public partial class LihatPenjualanFilm : Form
    {
        private string connectionString = @"Data Source=MSI\ABRA;Initial Catalog=CRUD_COBA;Integrated Security=True";
        public LihatPenjualanFilm()
        {
            InitializeComponent();
        }

        private void flpPenjualan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnToDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void btnToTambah_Click(object sender, EventArgs e)
        {
            TambahPenjualanFilm tambahPenjualanFilmForm = new TambahPenjualanFilm();
            tambahPenjualanFilmForm.Show();
            this.Hide();
        }

        private void LihatPenjualanFilm_Load(object sender, EventArgs e)
        {
            LoadPenjualanTransactions();
        }

        private void LoadPenjualanTransactions()
        {
            // Pastikan FlowLayoutPanel dengan Name flpPenjualan sudah ada di Designer
            flpPenjualan.Controls.Clear();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Query join antara PenjualanFilm, Film, dan Users
                string query = @"
                    SELECT 
                        pf.id_transaksi, 
                        pf.total_transaksi, 
                        pf.quantity, 
                        pf.bukti_pembayaran, 
                        pf.transaction_date,
                        f.judul, 
                        u.Username
                    FROM PenjualanFilm pf
                    INNER JOIN Film f ON pf.id_film = f.id_film
                    INNER JOIN Users u ON pf.id_user = u.id
                    ORDER BY pf.transaction_date DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        // Ambil data
                        int idTransaksi = Convert.ToInt32(row["id_transaksi"]);
                        decimal totalTransaksi = Convert.ToDecimal(row["total_transaksi"]);
                        int quantity = Convert.ToInt32(row["quantity"]);
                        byte[] buktiBytes = row["bukti_pembayaran"] as byte[];
                        DateTime transactionDate = Convert.ToDateTime(row["transaction_date"]);
                        string judulFilm = row["judul"].ToString();
                        string username = row["Username"].ToString();

                        // Buat panel untuk transaksi
                        Panel panelTransaksi = new Panel
                        {
                            Size = new Size(300, 250),
                            Margin = new Padding(10),
                            BorderStyle = BorderStyle.FixedSingle
                        };

                        // Label Judul Film
                        Label lblFilm = new Label
                        {
                            Text = "Film: " + judulFilm,
                            Size = new Size(300, 20),
                            Location = new Point(5, 5),
                            Font = new Font("Arial", 10, FontStyle.Bold)
                        };

                        // Label User
                        Label lblUser = new Label
                        {
                            Text = "User: " + username,
                            Size = new Size(300, 20),
                            Location = new Point(5, 30)
                        };

                        // Label Transaction Date
                        Label lblDate = new Label
                        {
                            Text = "Tanggal: " + transactionDate.ToString("dd/MM/yyyy HH:mm:ss"),
                            Size = new Size(300, 20),
                            Location = new Point(5, 55)
                        };

                        // PictureBox untuk Bukti Pembayaran
                        PictureBox pbBukti = new PictureBox
                        {
                            Size = new Size(150, 150),
                            Location = new Point(5, 80),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        if (buktiBytes != null)
                        {
                            using (MemoryStream ms = new MemoryStream(buktiBytes))
                            {
                                pbBukti.Image = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            pbBukti.Image = Properties.Resources.logo_orang; // Gambar default bila tidak ada bukti
                        }

                        // Label Quantity
                        Label lblQty = new Label
                        {
                            Text = "Quantity: " + quantity,
                            Size = new Size(140, 20),
                            Location = new Point(160, 80)
                        };

                        // Label Total Transaksi
                        Label lblTotal = new Label
                        {
                            Text = "Total: " + totalTransaksi.ToString("C"),
                            Size = new Size(140, 20),
                            Location = new Point(160, 110)
                        };

                        // Tambahkan kontrol ke panel
                        panelTransaksi.Controls.Add(lblFilm);
                        panelTransaksi.Controls.Add(lblUser);
                        panelTransaksi.Controls.Add(lblDate);
                        panelTransaksi.Controls.Add(pbBukti);
                        panelTransaksi.Controls.Add(lblQty);
                        panelTransaksi.Controls.Add(lblTotal);

                        // Tambahkan panel ke FlowLayoutPanel
                        flpPenjualan.Controls.Add(panelTransaksi);
                    }
                }
            }
        }
    }
}
