using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyKhachSanDeMo
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=HANGUYEN\SQLEXPRESS;Initial Catalog=QuanLyKhachSanDemo;Integrated Security=True";
            con.ConnectionString = connectionString;
            con.Open();
            loadDataToGridview();
        }
        private void loadDataToGridview()
        {
            string sql = "Select * from Phong";
            SqlDataAdapter adp = new SqlDataAdapter(sql,con);
            DataTable tablePhong = new DataTable();
            adp.Fill(tablePhong);
            dataGridView1.DataSource = tablePhong;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaphong.Text = dataGridView1.CurrentRow.Cells["Maphong"].Value.ToString();
            txtTenphong.Text = dataGridView1.CurrentRow.Cells["Tenphong"].Value.ToString();
            txtDongia.Text = dataGridView1.CurrentRow.Cells["Dongia"].Value.ToString();
        }

        private void bntThemmoi_Click(object sender, EventArgs e)
        {
            txtMaphong.Text = "";
            txtTenphong.Text = "";
            txtDongia.Text = "";
            txtMaphong.Enabled = true;
        }

        private void bntLuu_Click(object sender, EventArgs e)
        {
            string sql = @"INSERT INTO Phong(Maphong, Tenphong, Dongia) VALUES('"+txtMaphong.Text+"','"+txtTenphong.Text+"', '"+txtDongia.Text+"')";
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.ExecuteNonQuery();
            loadDataToGridview();
        }

        private void bntSua_Click(object sender, EventArgs e)
        {
            string sql = @"UPDATE Phong SET Maphong='" + txtMaphong.Text + "', Tenphong='" + txtTenphong.Text + "', Dongia='" + txtDongia.Text + "'" +
               "WHERE (Maphong ='"+txtMaphong.Text+"')";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            loadDataToGridview();

        }

        private void bntXoa_Click(object sender, EventArgs e)
        {
            string sql = @"DELETE Phong where Maphong='" + txtMaphong.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            loadDataToGridview();
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
