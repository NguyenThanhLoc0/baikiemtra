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
    public partial class HoaDonNhapHang : Form
    {
        public HoaDonNhapHang()
        {
            InitializeComponent();
            c = new connectData();
            loaddata();
        }

        private connectData c;
        private void loaddata()
        {
            try
            {
                c.connect();
                string query = "SELECT MaNhapHang AS N'Mã nhập hàng', MaNhaXuatBan AS N'Mã NXB', MaSach AS N'Mã sách', " +
                               "SoLuongNhap AS N'Số lượng nhập', NgayNhap AS N'Ngày nhập', GhiChu AS N'Ghi chú' " +
                               "FROM NhapHang";
                SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvNhapHang.DataSource = dt;
                c.disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_form()
        {
            txtMaNhapHang.Clear();
            txtMaNhaXuatBan.Clear();
            txtMaSach.Clear();
            txtSoLuongNhap.Clear();
            
            txtGhiChu.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int a;
            if (txtMaNhapHang.Text == "" || txtMaNhaXuatBan.Text == "" || txtMaSach.Text == "" || txtSoLuongNhap.Text == "" || dateNgayNhap.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!int.TryParse(txtSoLuongNhap.Text, out a) || a <= 0)
            {
                MessageBox.Show("Số lượng nhập phải là số nguyên dương!!", "Thông báo", MessageBoxButtons.OK);
            }
            
            else
            {
                try
                {
                    c.connect();
                    DateTime ngaynhap = Convert.ToDateTime(dateNgayNhap.Text);
                    string ngaynhapFormatted = ngaynhap.ToString("yyyy-MM-dd");
                    string query = "INSERT INTO NhapHang (MaNhapHang, MaNhaXuatBan, MaSach, SoLuongNhap, NgayNhap, GhiChu) " +
                                  "VALUES ('" + txtMaNhapHang.Text + "', N'" + txtMaNhaXuatBan.Text + "', N'" + txtMaSach.Text + "', '"
                                  + txtSoLuongNhap.Text + "', '" + ngaynhapFormatted + "', N'" + txtGhiChu.Text + "')";
                    bool kq = c.exeSQL(query);
                    if (kq)
                    {
                        MessageBox.Show("Thêm hóa đơn nhập hàng thành công!!", "Thông báo", MessageBoxButtons.OK);
                        loaddata();
                        clear_form();
                    }
                    else
                    {
                        MessageBox.Show("Thêm hóa đơn nhập hàng thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm hóa đơn: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                for (int i = 0; i < dgvNhapHang.Columns.Count; i++)
                {
                    excelApp.Cells[1, i + 1] = dgvNhapHang.Columns[i].HeaderText;
                }

                // Xuất dữ liệu từng dòng
                for (int i = 0; i < dgvNhapHang.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvNhapHang.Columns.Count; j++)
                    {
                        if (dgvNhapHang.Rows[i].Cells[j].Value != null)
                        {
                            excelApp.Cells[i + 2, j + 1] = dgvNhapHang.Rows[i].Cells[j].Value.ToString();
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
