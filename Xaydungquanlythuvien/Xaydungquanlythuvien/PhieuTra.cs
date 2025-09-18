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
    
    public partial class PhieuTra : Form
    {
        private connectData c;
        public PhieuTra()
        {
            InitializeComponent();
            c = new connectData();
            loaddata();
            dtpNgayTra.Value = DateTime.Now;
        }

        private void loaddata()
        {
            try
            {
                c.connect();
                string query = "SELECT MaPhieuTra AS N'Mã phiếu trả', MaPhieuMuon AS N'Mã phiếu mượn', " +
                               "NgayTra AS N'Ngày trả', GhiChu AS N'Ghi chú' " +
                               "FROM PhieuTra";
                SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvPhieuTra.DataSource = dt;
                c.disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_form()
        {
            txtMaPhieuTra.Clear();
            txtMaPhieuMuon.Clear();
            dtpNgayTra.Value = DateTime.Now; // Đặt lại ngày trả mặc định
            txtGhiChu.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaPhieuTra.Text == "" || txtMaPhieuMuon.Text == "" || dtpNgayTra.Value == null)
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (dtpNgayTra.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày trả không hợp lệ hoặc lớn hơn ngày hiện tại!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    c.connect();
                    string query = "INSERT INTO PhieuTra (MaPhieuTra, MaPhieuMuon, NgayTra, GhiChu) " +
                                  "VALUES ('" + txtMaPhieuTra.Text + "', N'" + txtMaPhieuMuon.Text + "', '"
                                  + dtpNgayTra.Value.ToString("yyyy-MM-dd") + "', N'" + txtGhiChu.Text + "')";
                    bool kq = c.exeSQL(query);
                    if (kq)
                    {
                        MessageBox.Show("Thêm phiếu trả thành công!!", "Thông báo", MessageBoxButtons.OK);
                        loaddata();
                        clear_form();
                    }
                    else
                    {
                        MessageBox.Show("Thêm phiếu trả thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm phiếu trả: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // Xuất tiêu đề cột
                for (int i = 0; i < dgvPhieuTra.Columns.Count; i++)
                {
                    excelApp.Cells[1, i + 1] = dgvPhieuTra.Columns[i].HeaderText;
                }

                // Xuất dữ liệu từng dòng
                for (int i = 0; i < dgvPhieuTra.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvPhieuTra.Columns.Count; j++)
                    {
                        if (dgvPhieuTra.Rows[i].Cells[j].Value != null)
                        {
                            excelApp.Cells[i + 2, j + 1] = dgvPhieuTra.Rows[i].Cells[j].Value.ToString();
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
