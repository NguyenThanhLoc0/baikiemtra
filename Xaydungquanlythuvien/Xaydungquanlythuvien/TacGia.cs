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
    public partial class TacGia : Form
    {
        public TacGia()
        {
            InitializeComponent();
        }

        connectData c = new connectData();
        void loaddata()
        {
            dgvTacGia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            c.connect();
            DataSet data = new DataSet();
            string query = "select MaTacGia as N'Mã tác giả',TenTacGia as N'Tên tác giả',DiaChi as N'Địa chỉ',SoDienThoai as N'Số điện thoại',NgaySinh as N'Ngày sinh',Email as N'Email',GhiChu as N'Ghi chú' from TacGia";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, c.conn);
            sqlData.Fill(data);
            dgvTacGia.DataSource = data.Tables[0];
            //command.CommandText = "select MaNhanVien as N'Mã nhân viên',HoDemNV as N'Họ đệm',TenNV as N'Tên nhân viên',GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',SoDienThoai as N'Số điện thoại', GhiChu as N'Ghi chú' from NhanVien";
            c.disconnect();
        }
        public void clear_form()
        {
            txtMaTacGia.Text = "";
            txtTenTacGia.Text = null;
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            dateNgaySinh.Text = "";
            txtEmail.Text = "";
            txtGhiChu.Text = "";
            txtMaTacGia.Focus();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            double a;
            if (txtMaTacGia.Text == "" || txtTenTacGia.Text == "" || txtDiaChi.Text == "" || txtSoDienThoai.Text == "" || dateNgaySinh.Text == "" || txtEmail.Text == "")
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
                string query = "insert into TacGia(MaTacGia,TenTacGia,DiaChi,SoDienThoai,NgaySinh,Email,GhiChu) " +
                "values ('" + txtMaTacGia.Text + "',N'" + txtTenTacGia.Text + "',N'" + txtDiaChi.Text + "',N'" + txtSoDienThoai.Text + "','" + ngaysinhFormatted
                + "',N'" + txtEmail.Text + "',N'" + txtGhiChu.Text + "')";
                bool kq = c.exeSQL(query);
                MessageBox.Show("Thêm thành công!!", "Thông báo", MessageBoxButtons.OK);
                loaddata();
                clear_form();

            }
        }

        private void dgvTacGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvTacGia.CurrentRow.Index;
            txtMaTacGia.Text = dgvTacGia.Rows[i].Cells[0].Value.ToString();
            txtTenTacGia.Text = dgvTacGia.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvTacGia.Rows[i].Cells[2].Value.ToString();
            txtSoDienThoai.Text = dgvTacGia.Rows[i].Cells[3].Value.ToString();
            dateNgaySinh.Text = dgvTacGia.Rows[i].Cells[4].Value.ToString();
            txtEmail.Text = dgvTacGia.Rows[i].Cells[5].Value.ToString();
            txtGhiChu.Text = dgvTacGia.Rows[i].Cells[6].Value.ToString();
            
        }

        private void TacGia_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            double a;
            if (txtMaTacGia.Text == "" || txtTenTacGia.Text == "" || txtDiaChi.Text == "" || txtSoDienThoai.Text == "" || dateNgaySinh.Text == "" || txtEmail.Text == "")
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

                string query = "update TacGia set TenTacGia = N'" + txtTenTacGia.Text + "'," +
                    "DiaChi = N'" + txtDiaChi.Text + "',SoDienThoai = N'" + txtSoDienThoai.Text + "'," +
                    "NgaySinh = '" + ngaysinhFormatted + "',Email = N'" + txtEmail.Text + "'," +
                    "GhiChu = N'" + txtGhiChu.Text + "' " +
                    "where MaTacGia = '" + txtMaTacGia.Text + "'";
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

                string query = "delete from TacGia where MaTacGia = '" + txtMaTacGia.Text + "'";
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
