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

namespace Xaydungquanlythuvien
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        connectData c = new connectData();
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            c.connect();
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau .Text;
            SqlCommand cmd = new SqlCommand("select * from DangNhap where TaiKhoan = '" + tk + "' " +
                "and MatKhau = '" + mk + "'", c.conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (txtMatKhau.Text == "" || txtTaiKhoan.Text == "")
            {
                MessageBox.Show("Bạn điền tài khoản và mật khẩu để đăng nhâp", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            }
            else if (reader.Read() == true)
            {
                this.Hide();
                Main f_Main = new Main();
                f_Main.ShowDialog();
                f_Main = null;
                txtMatKhau.Text = "";
                this.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng? Vui lòng nhập lại tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtMatKhau.Text = "";
            }
            c.disconnect();
        }

        private void chkHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn thoát? ", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {

                this.Close();
            }
        }
    }
}
