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
    public partial class TraPhieuMuon : Form
    {
        private connectData c;
        public TraPhieuMuon()
        {
            InitializeComponent();
            c = new connectData();
            loaddata();
            dateNgayMuon.Value = DateTime.Now; // Đặt ngày mượn mặc định là ngày hiện tại
            dateNgayTra.Value = DateTime.Now.AddDays(7); // Đặt ngày hẹn trả mặc định sau 7 ngày
        }

        private void loaddata()
        {
            try
            {
                c.connect();
                string query = "SELECT MaPhieuMuon AS N'Mã phiếu mượn', MaDocGia AS N'Mã độc giả', MaNhanVien AS N'Mã nhân viên', " +
                               "NgayMuon AS N'Ngày mượn', NgayHenTra AS N'Ngày hẹn trả', GhiChu AS N'Ghi chú' " +
                               "FROM PhieuMuon";
                SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTraPhieuMuon.DataSource = dt;
                dgvTraPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                c.disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_form()
        {
            txtMaPhieuMuon.Clear();
            txtMaDocGia.Clear();
            txtMaNhanVien.Clear();
            dateNgayMuon.Value = DateTime.Now; // Đặt lại ngày mượn mặc định
            dateNgayTra.Value = DateTime.Now.AddDays(7); // Đặt lại ngày hẹn trả mặc định
            txtGhiChu.Clear();
        }

        private void dgvTraPhieuMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvTraPhieuMuon.CurrentRow.Index;
            txtMaPhieuMuon.Text = dgvTraPhieuMuon.Rows[i].Cells[0].Value.ToString();
            txtMaDocGia.Text = dgvTraPhieuMuon.Rows[i].Cells[1].Value.ToString();
            txtMaNhanVien.Text = dgvTraPhieuMuon.Rows[i].Cells[2].Value.ToString();
            dateNgayMuon.Text = dgvTraPhieuMuon.Rows[i].Cells[3].Value.ToString();
            dateNgayTra.Text = dgvTraPhieuMuon.Rows[i].Cells[4].Value.ToString();
            txtGhiChu.Text = dgvTraPhieuMuon.Rows[i].Cells[5].Value.ToString();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuMuon.Text == "" || txtMaDocGia.Text == "" || txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (dateNgayMuon.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày mượn không hợp lệ hoặc lớn hơn ngày hiện tại!!", "Thông báo", MessageBoxButtons.OK);
            }
            else if (dateNgayTra.Value <= dateNgayMuon.Value)
            {
                MessageBox.Show("Ngày hẹn trả không hợp lệ hoặc nhỏ hơn hoặc bằng ngày mượn!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    c.connect();
                    string query = "UPDATE PhieuMuon SET MaDocGia = N'" + txtMaDocGia.Text + "', " +
                                  "MaNhanVien = N'" + txtMaNhanVien.Text + "', " +
                                  "NgayMuon = '" + dateNgayMuon.Value.ToString("yyyy-MM-dd") + "', " +
                                  "NgayHenTra = '" + dateNgayTra.Value.ToString("yyyy-MM-dd") + "', " +
                                  "GhiChu = N'" + txtGhiChu.Text + "' " +
                                  "WHERE MaPhieuMuon = '" + txtMaPhieuMuon.Text + "'";
                    bool kq = c.exeSQL(query);
                    if (kq)
                    {
                        MessageBox.Show("Sửa phiếu mượn thành công!!", "Thông báo", MessageBoxButtons.OK);
                        loaddata();
                        clear_form();
                    }
                    else
                    {
                        MessageBox.Show("Sửa phiếu mượn thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa phiếu mượn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuMuon.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu mượn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    c.connect();
                    string query = "DELETE FROM PhieuMuon WHERE MaPhieuMuon = '" + txtMaPhieuMuon.Text + "'";
                    bool kq = c.exeSQL(query);
                    if (kq)
                    {
                        MessageBox.Show("Xóa phiếu mượn thành công!!", "Thông báo", MessageBoxButtons.OK);
                        loaddata();
                        clear_form();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu mượn thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa phiếu mượn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                c.connect();
                string query = "SELECT MaPhieuMuon AS N'Mã phiếu mượn', MaDocGia AS N'Mã độc giả', MaNhanVien AS N'Mã nhân viên', " +
                               "NgayMuon AS N'Ngày mượn', NgayHenTra AS N'Ngày hẹn trả', GhiChu AS N'Ghi chú' " +
                               "FROM PhieuMuon WHERE MaPhieuMuon LIKE '%" + txtTimKiem.Text + "%' OR MaDocGia LIKE '%" + txtTimKiem.Text + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTraPhieuMuon.DataSource = dt;
                c.disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                for (int i = 0; i < dgvTraPhieuMuon.Columns.Count; i++)
                {
                    excelApp.Cells[1, i + 1] = dgvTraPhieuMuon.Columns[i].HeaderText;
                }

                // Xuất dữ liệu từng dòng
                for (int i = 0; i < dgvTraPhieuMuon.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvTraPhieuMuon.Columns.Count; j++)
                    {
                        if (dgvTraPhieuMuon.Rows[i].Cells[j].Value != null)
                        {
                            excelApp.Cells[i + 2, j + 1] = dgvTraPhieuMuon.Rows[i].Cells[j].Value.ToString();
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

        private void dgvTraPhieuMuon_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTraPhieuMuon.Rows[e.RowIndex];
            txtMaPhieuMuon.Text = row.Cells["Mã sách"].Value.ToString();
            txtMaDocGia.Text = row.Cells["Tên sách"].Value.ToString();
            txtMaNhanVien.Text = row.Cells["Tác giả"].Value.ToString(); // Hiển thị TenTacGia từ join
            dateNgayMuon.Text = row.Cells["Thể loại"].Value.ToString(); // Hiển thị TenTheLoai từ join
            dateNgayTra.Text = row.Cells["Số lượng"].Value.ToString();
            txtGhiChu.Text = row.Cells["Ghi chú"].Value.ToString();
        }
    }
}
