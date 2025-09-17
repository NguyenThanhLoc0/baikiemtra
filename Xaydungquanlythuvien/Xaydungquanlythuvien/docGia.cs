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
    public partial class docGia : Form
    {
        connectData c = new connectData();
        void loaddata()
        {
            dgvDocGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            c.connect();
            DataSet data = new DataSet();
            string query = "select MaDocGia as N'Mã độc giả',TenDocGia as N'Tên độc giả',SoDienThoai as N'Số điện thoại',GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',DanhGia as N'Đánh giá', GhiChu as N'Ghi chú' from DocGia";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, c.conn);
            sqlData.Fill(data);
            dgvDocGia.DataSource = data.Tables[0];
            //command.CommandText = "select MaNhanVien as N'Mã nhân viên',HoDemNV as N'Họ đệm',TenNV as N'Tên nhân viên',GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',SoDienThoai as N'Số điện thoại', GhiChu as N'Ghi chú' from NhanVien";
            c.disconnect();
        }
        public void clear_form()
        {
            txtMaDocGia.Text = "";
            txtTenDocGia.Text = null;
            txtSoDienThoai.Text = "";
            cboGioiTinh.Text = "";
            dateNgaySinh.Text = "";
            txtDiaChi.Text = "";
            cboDanhGia.Text = "";
            txtGhiChu.Text = "";
            txtMaDocGia.Focus();
        }
        public docGia()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            double a;
            if (txtMaDocGia.Text == "" || txtTenDocGia.Text == "" || txtSoDienThoai.Text == "" || cboGioiTinh.Text == "" || dateNgaySinh.Text == "" || txtDiaChi.Text == ""
                || cboDanhGia.Text == "")
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
                DateTime ngaysinh = Convert.ToDateTime(dateNgaySinh.Text);
                string ngaysinhFormatted = ngaysinh.ToString("dd-MM-yyyy");
                string query = "insert into DocGia(MaDocGia,TenDocGia,SoDienThoai,GioiTinh,NgaySinh,DiaChi,DanhGia,GhiChu) " +
                        "values ('" + txtMaDocGia.Text + "',N'" + txtTenDocGia.Text + "',N'" + txtSoDienThoai.Text + "',N'" + cboGioiTinh.Text + "','" + ngaysinhFormatted
                        + "',N'" + txtDiaChi.Text + "',N'" + cboDanhGia.Text + "',N'" + txtGhiChu.Text + "')";
                bool kq = c.exeSQL(query);
                MessageBox.Show("Thêm thành công!!", "Thông báo", MessageBoxButtons.OK);
                loaddata();
                clear_form();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            double a;
            if (txtMaDocGia.Text == "" || txtTenDocGia.Text == "" || txtSoDienThoai.Text == "" || cboGioiTinh.Text == "" || dateNgaySinh.Text == "" || txtDiaChi.Text == ""
                || cboDanhGia.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!double.TryParse(this.txtSoDienThoai.Text, out a))
            {
                MessageBox.Show("Điện thoại phải là số!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                DateTime ngaysinh = Convert.ToDateTime(dateNgaySinh.Text);
                string ngaysinhFormatted = ngaysinh.ToString("yyyy-MM-dd");
                c.connect();

                string query = "update DocGia set TenDocGia = N'" + txtTenDocGia.Text + "'," +
                    "SoDienThoai = N'" + txtSoDienThoai.Text + "',GioiTinh = N'" + cboGioiTinh.Text + "'," +
                    "NgaySinh = '" + ngaysinhFormatted + "',DiaChi = N'" + txtDiaChi.Text + "'," +
                    "DanhGia = '" + cboDanhGia.Text + "',GhiChu = N'" + txtGhiChu.Text + "' " +
                    "where MaDocGia = '" + txtMaDocGia.Text + "'";
                bool kq = c.exeSQL(query);
                MessageBox.Show("Sửa thành công!!", "Thông báo", MessageBoxButtons.OK);
                loaddata();
                clear_form();

            }
        }

        private void dgvDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvDocGia.CurrentRow.Index;
            txtMaDocGia.Text = dgvDocGia.Rows[i].Cells[0].Value.ToString();
            txtTenDocGia.Text = dgvDocGia.Rows[i].Cells[1].Value.ToString();
            txtSoDienThoai.Text = dgvDocGia.Rows[i].Cells[2].Value.ToString();
            cboGioiTinh.Text = dgvDocGia.Rows[i].Cells[3].Value.ToString();
            dateNgaySinh.Text = dgvDocGia.Rows[i].Cells[4].Value.ToString();
            txtDiaChi.Text =    dgvDocGia.Rows[i].Cells[5].Value.ToString();
            cboDanhGia.Text = dgvDocGia.Rows[i].Cells[6].Value.ToString();
            txtGhiChu.Text = dgvDocGia.Rows[i].Cells[7].Value.ToString();
        }

        private void docGia_Load(object sender, EventArgs e)
        {
            loaddata();
            cboGioiTinh.Items.Clear();   // xóa các item cũ nếu có
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.Items.Add("...");
            
            cboDanhGia.Items.Add(" khách hàng tệ");
            cboDanhGia.Items.Add("khách hàng mới");
            cboDanhGia.Items.Add("khách hàng tiềm năng");
            cboDanhGia.Items.Add("khách hàng VIP");
            cboDanhGia.Items.Add("...");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            c.connect();
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa? ", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {

                string query = "delete from DocGia where MaDocGia = '" + txtMaDocGia.Text + "'";
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
                string query = "select MaDocGia as N'Mã độc giả',TenDocGia as N'Tên độc giả',SoDienThoai as N'Số điện thoại',GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',DanhGia as N'Đánh giá', GhiChu as N'Ghi chú' from DocGia where MaDocGia like '%" + txtTimKiem.Text + "%' or TenDocGia like '%" + txtTimKiem.Text + "%' or SoDienThoai like '%" + txtTimKiem.Text + "%'";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, c.conn);
                sqlData.Fill(data);
                dgvDocGia.DataSource = data.Tables[0];

            }
            else
            {
                docGia_Load(sender, e);
            }
        }
    }
}
