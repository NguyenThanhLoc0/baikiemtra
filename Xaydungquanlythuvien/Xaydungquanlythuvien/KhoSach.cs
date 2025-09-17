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
using Excel = Microsoft.Office.Interop.Excel;

namespace Xaydungquanlythuvien
{

    public partial class KhoSach : Form
    {
        connectData c = new connectData();
        void loaddata()
        {
            dgvKhoSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            c.connect();
            DataSet data = new DataSet();
            string query = "select MaSach as N'Mã sách',TenSach as N'Tên sách',TenTacGia as N'Tác giả',TenTheLoai as N'Thể loại',SoLuong as N'Số lượng', GhiChu as N'Ghi chú' from KhoSach";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, c.conn);
            sqlData.Fill(data);
            dgvKhoSach.DataSource = data.Tables[0];
            //command.CommandText = "select MaNhanVien as N'Mã nhân viên',HoDemNV as N'Họ đệm',TenNV as N'Tên nhân viên',GioiTinh as N'Giới tính',NgaySinh as N'Ngày sinh',DiaChi as N'Địa chỉ',SoDienThoai as N'Số điện thoại', GhiChu as N'Ghi chú' from NhanVien";
            c.disconnect();
        }
        public void clear_form()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = null;
            txtTacGia.Text = "";
            txtTheLoai.Text = "";
            txtSoLuong.Text = "";
            txtMaSach.Focus();
            txtGhiChu.Text = "";
        }
        public KhoSach()
        {
            InitializeComponent();
        }

        

        private void lblTenSach_Click(object sender, EventArgs e)
        {

        }


        private void KhoSach_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void dgvKhoSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvKhoSach.CurrentRow.Index;
            txtMaSach.Text = dgvKhoSach.Rows[i].Cells[0].Value.ToString();
            txtTenSach.Text = dgvKhoSach.Rows[i].Cells[1].Value.ToString();
            txtTacGia.Text = dgvKhoSach.Rows[i].Cells[2].Value.ToString();
            txtTheLoai.Text = dgvKhoSach.Rows[i].Cells[3].Value.ToString();
            txtSoLuong.Text = dgvKhoSach.Rows[i].Cells[4].Value.ToString();
            txtGhiChu.Text = dgvKhoSach.Rows[i].Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            double a;
            if (txtMaSach.Text == "" || txtTenSach.Text == "" || txtTacGia.Text == "" || txtTheLoai.Text == "" || txtSoLuong.Text == "" )
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!double.TryParse(this.txtSoLuong.Text, out a))
            {
                MessageBox.Show("số sách phải là số!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                c.connect();
                string query = "insert into KhoSach(MaSach,TenSach,TenTacGia,TenTheLoai,SoLuong,GhiChu) " +
                        "values ('" + txtMaSach.Text + "',N'" + txtTenSach.Text + "',N'" + txtTacGia.Text + "',N'" + txtTheLoai.Text + "','" 
                        + txtSoLuong.Text + "',N'" +  txtGhiChu.Text + "')";
                bool kq = c.exeSQL(query);
                MessageBox.Show("Thêm thành công!!", "Thông báo", MessageBoxButtons.OK);
                loaddata();
                clear_form();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            double a;
            if (txtMaSach.Text == "" || txtTenSach.Text == "" || txtTacGia.Text == "" || txtTheLoai.Text == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!double.TryParse(this.txtSoLuong.Text, out a))
            {
                MessageBox.Show("Số sách phải là số!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                c.connect();

                string query = "UPDATE KhoSach SET TenSach = N'" + txtTenSach.Text + "'," +
                "TenTacGia = N'" + txtTacGia.Text + "',TenTheLoai = N'" + txtTheLoai.Text + "'," +
                "SoLuong = '" + txtSoLuong.Text + "',GhiChu = N'" + txtGhiChu.Text + "' " +
                "WHERE MaSach = '" + txtMaSach.Text + "'";
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

                string query = "delete from KhoSach where MaSach = '" + txtMaSach.Text + "'";
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

        private void btnTimsach_Click(object sender, EventArgs e)
        {
            if (txtTimSach.Text.Length > 0)
            {
                c.connect();
                DataSet data = new DataSet();
                string query = "select MaSach as N'Mã sách',TenSach as N'Tên sách',TacGia as N'Tác giả',TheLoai as N'Thể loại',SoLuong as N'Số lượng', GhiChu as N'Ghi chú' from KhoSach where MaSach like '%" + txtTimSach.Text + "%' or TenSach like '%" + txtTimSach.Text + "%' or TacGia like '%" + txtTimSach.Text + "%'";
                SqlDataAdapter sqlData = new SqlDataAdapter(query, c.conn);
                sqlData.Fill(data);
                dgvKhoSach.DataSource = data.Tables[0];

            }
            else
            {
                KhoSach_Load(sender, e);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // Xuất tiêu đề cột
                for (int i = 0; i < dgvKhoSach.Columns.Count; i++)
                {
                    excelApp.Cells[1, i + 1] = dgvKhoSach.Columns[i].HeaderText;
                }

                // Xuất dữ liệu từng dòng
                for (int i = 0; i < dgvKhoSach.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvKhoSach.Columns.Count; j++)
                    {
                        if (dgvKhoSach.Rows[i].Cells[j].Value != null)
                        {
                            excelApp.Cells[i + 2, j + 1] = dgvKhoSach.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // Tự động căn chỉnh cột
                excelApp.Columns.AutoFit();

                // Hiện Excel
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
            }
        }
    }
}
