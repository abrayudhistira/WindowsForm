using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CRUDOYE
{
    public partial class Dashboard : Form
    {
        private string connectionString = @"Data Source=MSI\ABRA;Initial Catalog=CRUD_COBA;Integrated Security=True";
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

        private void btnToPenjualanFilm_Click(object sender, EventArgs e)
        {
            LihatPenjualanFilm lihatPenjualanFilmForm = new LihatPenjualanFilm();
            lihatPenjualanFilmForm.Show();
            this.Hide();
        }

        private void chartPenjualan_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadChartData();
        }
        private void LoadChartData()
        {
            // Bersihkan series dan chart area yang sudah ada (jika ada)
            chartPenjualan.Series.Clear();
            chartPenjualan.ChartAreas.Clear();

            // Tambahkan chart area baru
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartPenjualan.ChartAreas.Add(chartArea);

            // Tambahkan series baru, misalnya bertipe Column
            Series series = new Series("Penjualan")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.Int32
            };
            chartPenjualan.Series.Add(series);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                // Query untuk mendapatkan total penjualan per bulan
                // Menggunakan DATEPART untuk mengambil bulan dari transaction_date
                string query = @"
                    SELECT 
                        DATENAME(month, transaction_date) AS Bulan,
                        SUM(total_transaksi) AS TotalPenjualan,
                        DATEPART(month, transaction_date) AS BulanUrut
                    FROM PenjualanFilm
                    GROUP BY DATENAME(month, transaction_date), DATEPART(month, transaction_date)
                    ORDER BY BulanUrut;";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Iterasi data dan tambahkan ke series
                    foreach (DataRow row in dt.Rows)
                    {
                        string bulanName = row["Bulan"].ToString();
                        decimal total = Convert.ToDecimal(row["TotalPenjualan"]);
                        series.Points.AddXY(bulanName, total);
                    }
                }
            }

            // Opsi: Set label pada sumbu X untuk menampilkan nama bulan (opsional)
            chartPenjualan.ChartAreas[0].AxisX.Title = "Bulan";
            chartPenjualan.ChartAreas[0].AxisY.Title = "Total Penjualan";
        }
    }
}
