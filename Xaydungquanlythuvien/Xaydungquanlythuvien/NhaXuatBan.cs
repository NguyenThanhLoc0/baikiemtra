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
    public partial class NhaXuatBan : Form
    {
        connectData c = new connectData();
        void loaddata()
        {
            dgvNhaXuatBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            c.connect();
            DataSet data = new DataSet();
            string query = "select MaNhaXuatBan as N'Mã nhà xuất bản',TenNhaXuatBan as N'tên nhà xuất bản',DiaChi as N'Địa chỉ',Email as N'Email',SoDienThoai as N'Số điện thoại', GhiChu as N'Ghi chú' from NhaXuatBan";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, c.conn);
            sqlData.Fill(data);
            dgvNhaXuatBan.DataSource = data.Tables[0];
            //command.CommandText = "select MaNhanVien as N'Mã nhân viên',HoDemNV as N'Họ đệm',TenNV as N'Tên nhân viên',GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',SoDienThoai as N'Số điện thoại', GhiChu as N'Ghi chú' from NhanVien";
            c.disconnect();
        }
        public void clear_form()
        {
            txtMaNhaXuatBan.Text = "";
            txtTenNhaXuatBan.Text = null;
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtSoDienThoai.Text = "";
            txtGhiChu.Text = "";
            txtMaNhaXuatBan.Focus();
        }
        public NhaXuatBan()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            double a;
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtMaNhaXuatBan.Text == "" || txtTenNhaXuatBan.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "" || txtSoDienThoai.Text == "" )
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!double.TryParse(this.txtSoDienThoai.Text, out a))
            {
                MessageBox.Show("Điện thoại phải là số!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                c.connect();
                
                string query = "insert into NhaXuatBan(MaNhaXuatBan,TenNhaXuatBan,DiaChi,Email,SoDienThoai,GhiChu) " +
                        "values ('" + txtMaNhaXuatBan.Text + "',N'" + txtTenNhaXuatBan.Text + "',N'" + txtDiaChi.Text + "',N'" + txtEmail.Text + "','" + txtSoDienThoai.Text
                        + "',N'" + txtGhiChu.Text + "')";
                bool kq = c.exeSQL(query);
                MessageBox.Show("Thêm thành công!!", "Thông báo", MessageBoxButtons.OK);
                loaddata();
                clear_form();

            }
        }

        private void dgvNhaXuatBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvNhaXuatBan.CurrentRow.Index;
            txtMaNhaXuatBan.Text = dgvNhaXuatBan.Rows[i].Cells[0].Value.ToString();
            txtTenNhaXuatBan.Text = dgvNhaXuatBan.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvNhaXuatBan.Rows[i].Cells[2].Value.ToString();
            txtEmail.Text = dgvNhaXuatBan.Rows[i].Cells[3].Value.ToString();
            txtSoDienThoai.Text = dgvNhaXuatBan.Rows[i].Cells[4].Value.ToString();
            txtGhiChu.Text = dgvNhaXuatBan.Rows[i].Cells[5].Value.ToString();
        }

        private void NhaXuatBan_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            double a;
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Email không hợp lệ!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (txtMaNhaXuatBan.Text == "" || txtTenNhaXuatBan.Text == "" || txtDiaChi.Text == "" || txtEmail.Text == "" || txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!double.TryParse(this.txtSoDienThoai.Text, out a))
            {
                MessageBox.Show("Điện thoại phải là số!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                c.connect();

                string query = "UPDATE NhaXuatBan SET TenNhaXuatBan = N'" + txtTenNhaXuatBan.Text + "', " +
               "DiaChi = N'" + txtDiaChi.Text + "', " +
               "SoDienThoai = '" + txtSoDienThoai.Text + "', " +
               "Email = N'" + txtEmail.Text + "', " +
               "GhiChu = N'" + txtGhiChu.Text + "' " +
               "WHERE MaNhaXuatBan = '" + txtMaNhaXuatBan.Text + "'";
                bool kq = c.exeSQL(query);
                MessageBox.Show("Sửa thành công!!", "Thông báo", MessageBoxButtons.OK);
                loaddata();
                clear_form();

            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            c.connect();
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa? ", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {

                string query = "delete from NhaXuatBan where MaNhaXuatBan = '" + txtMaNhaXuatBan.Text + "'";
                bool kq1 = c.exeSQL(query);
                MessageBox.Show("Xóa thành công!!", "Thông báo", MessageBoxButtons.OK);
                loaddata();
                clear_form();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (kq == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
