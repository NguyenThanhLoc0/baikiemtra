


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Xaydungquanlythuvien
{
    public partial class NhanVien : Form
    {
        connectData c = new connectData();
        void loaddata()
        {
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            c.connect();
            DataSet data = new DataSet();
            string query = "select MaNhanVien as N'Mã nhân viên',HoDem as N'Họ đệm',TenNhanVien as N'Tên nhân viên',GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',SoDienThoai as N'Số điện thoại', GhiChu as N'Ghi chú' from NhanVien";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, c.conn);
            sqlData.Fill(data);
            dgvNhanVien.DataSource = data.Tables[0];
            //command.CommandText = "select MaNhanVien as N'Mã nhân viên',HoDemNV as N'Họ đệm',TenNV as N'Tên nhân viên',GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',SoDienThoai as N'Số điện thoại', GhiChu as N'Ghi chú' from NhanVien";
            c.disconnect();
        }
        public void clear_form()
        {
            txtMaNhanVien.Text = "";
            txtHoDem.Text = null;
            txtTenNhanVien.Text = "";
            cboGioiTinh.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            lblNgaySinh.Text = "";
            txtMaNhanVien.Focus();
        }
        public NhanVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            double a;
            if (txtMaNhanVien.Text == "" || txtHoDem.Text == "" || txtTenNhanVien.Text == "" || cboGioiTinh.Text == "" || txtSoDienThoai.Text == "" || txtDiaChi.Text == ""
                || lblNgaySinh.Text == "")
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
                DateTime ngaysinh = Convert.ToDateTime(lblNgaySinh.Text);
                string ngaysinhFormatted = ngaysinh.ToString("dd-MM-yyyy");
                string query = "insert into NhanVien(MaNhanVien,HoDem,TenNhanVien,GioiTinh,NgaySinh,DiaChi,SoDienThoai,GhiChu) " +
                        "values ('" + txtMaNhanVien.Text + "',N'" + txtHoDem.Text + "',N'" + txtTenNhanVien.Text + "',N'" + cboGioiTinh.Text + "','" + ngaysinhFormatted
                        + "',N'" + txtDiaChi.Text + "',N'" + txtSoDienThoai.Text + "',N'" + txtGhiChu.Text + "')";
                bool kq = c.exeSQL(query);
                MessageBox.Show("Thêm thành công!!", "Thông báo", MessageBoxButtons.OK);
                loaddata();
                clear_form();
                
            }
        }

        private void txtHoDem_TextChanged(object sender, EventArgs e)
        {

        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            loaddata();
            cboGioiTinh.Items.Clear();   // xóa các item cũ nếu có
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("...");
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvNhanVien.CurrentRow.Index;
            txtMaNhanVien.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
            txtHoDem.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
            cboGioiTinh.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
            lblNgaySinh.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
            txtSoDienThoai.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
            txtGhiChu.Text = dgvNhanVien.Rows[i].Cells[7].Value.ToString();
        }

        
        private void btnSua_Click(object sender, EventArgs e)
        {
            double a;
            if (txtMaNhanVien.Text == "" || txtHoDem.Text == "" || txtTenNhanVien.Text == "" || cboGioiTinh.Text == "" || txtSoDienThoai.Text == "" || txtDiaChi.Text == "" || lblNgaySinh.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!double.TryParse(this.txtSoDienThoai.Text, out a))
            {
                MessageBox.Show("Điện thoại phải là số!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                DateTime ngaysinh = Convert.ToDateTime(lblNgaySinh.Text);
                string ngaysinhFormatted = ngaysinh.ToString("yyyy-MM-dd");
                c.connect();

                string query = "update NhanVien set HoDem = N'" + txtHoDem.Text + "'," +
                    "TenNhanVien = N'" + txtTenNhanVien.Text + "',GioiTinh = N'" + cboGioiTinh.Text + "'," +
                    "NgaySinh = '" + ngaysinhFormatted + "',DiaChi = N'" + txtDiaChi.Text + "'," +
                    "SoDienThoai = '" + txtSoDienThoai.Text + "',GhiChu = N'" + txtGhiChu.Text + "' " +
                    "where MaNhanVien = '" + txtMaNhanVien.Text + "'";
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

                string query = "delete from NhanVien where MaNhanVien = '" + txtMaNhanVien.Text + "'";
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length > 0)
            {
                c.connect();
                DataSet data = new DataSet();
                string query = "select MaNhanVien as N'Mã nhân viên',HoDemNV as N'Họ đệm',TenNV as N'Tên nhân viên',GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',SoDienThoai as N'Số điện thoại', GhiChu as N'Ghi chú' from NhanVien where MaNhanVien like '%" + txtTimKiem.Text + "%' or TenNV like '%" + txtTimKiem.Text + "%' or HoDemNV like '%" + txtTimKiem.Text + "%'";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, c.conn);
                sqlData.Fill(data);
                dgvNhanVien.DataSource = data.Tables[0];

            }
            else
            {
                NhanVien_Load(sender, e);
            }
        }

        private void lblNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
