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
    public partial class PhieuMuon : Form
    {
        private connectData c;
        public PhieuMuon()
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
                dgvPhieuMuon.DataSource = dt;
                dgvPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void btnThem_Click(object sender, EventArgs e)
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
                    string query = "INSERT INTO PhieuMuon (MaPhieuMuon, MaDocGia, MaNhanVien, NgayMuon, NgayHenTra, GhiChu) " +
                                  "VALUES ('" + txtMaPhieuMuon.Text + "', N'" + txtMaDocGia.Text + "', N'" + txtMaNhanVien.Text + "', '"
                                  + dateNgayMuon.Value.ToString("yyyy-MM-dd") + "', '" + dateNgayTra.Value.ToString("yyyy-MM-dd") + "', N'" + txtGhiChu.Text + "')";
                    bool kq = c.exeSQL(query);
                    if (kq)
                    {
                        MessageBox.Show("Thêm phiếu mượn thành công!!", "Thông báo", MessageBoxButtons.OK);
                        loaddata();
                        clear_form();
                    }
                    else
                    {
                        MessageBox.Show("Thêm phiếu mượn thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm phiếu mượn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                 
                }
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
                for (int i = 0; i < dgvPhieuMuon.Columns.Count; i++)
                {
                    excelApp.Cells[1, i + 1] = dgvPhieuMuon.Columns[i].HeaderText;
                }

                // Xuất dữ liệu từng dòng
                for (int i = 0; i < dgvPhieuMuon.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvPhieuMuon.Columns.Count; j++)
                    {
                        if (dgvPhieuMuon.Rows[i].Cells[j].Value != null)
                        {
                            excelApp.Cells[i + 2, j + 1] = dgvPhieuMuon.Rows[i].Cells[j].Value.ToString();
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
