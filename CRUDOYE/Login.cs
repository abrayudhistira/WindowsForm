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

namespace CRUDOYE
{
    public partial class Login : Form
    {
        //koneksi db
        private string connectionString = @"Data Source=MSI\ABRA;Initial Catalog=CRUD_COBA;Integrated Security=True";

        // Flag untuk status visible password
        private bool isPasswordVisible = false;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text;
            string password = textPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT id, Username FROM Users WHERE Username=@Username AND Password=@Password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        // Ambil id_user dan username dari hasil query
                        int userId = Convert.ToInt32(dr["id"]);
                        string userNameDb = dr["Username"].ToString();

                        // Simpan data ke session
                        UserSession.UserId = userId;
                        UserSession.Username = userNameDb;

                        // Buka form utama setelah login berhasil
                        Dashboard mainForm = new Dashboard();
                        mainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnToRegister_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.Show();
            this.Hide();
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {

        }
    }
}
