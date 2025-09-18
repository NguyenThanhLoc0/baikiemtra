using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Xaydungquanlythuvien
{
    public partial class KhoSach1 : Form
    {
        private connectData c;

        public KhoSach1()
        {
            InitializeComponent();
            c = new connectData();
            loaddata();
        }

        private void loaddata()
        {
            try
            {
                c.connect();
                string query = "SELECT ks.MaSach AS N'Mã sách', ks.TenSach AS N'Tên sách', tg.TenTacGia AS N'Tác giả', " +
                               "tl.TenTheLoai AS N'Thể loại', ks.SoLuong AS N'Số lượng', ks.GhiChu AS N'Ghi chú' " +
                               "FROM KhoSach ks " +
                               "LEFT JOIN TacGia tg ON ks.MaTacGia = tg.MaTacGia " +
                               "LEFT JOIN TheLoai tl ON ks.MaTheLoai = tl.MaTheLoai";
                SqlDataAdapter adapter = new SqlDataAdapter(query, c.conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvKhoSach1.DataSource = dt;
                dgvKhoSach1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                c.disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_form()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtTacGia.Clear();
            txtTheLoai.Clear();
            txtSoLuong.Clear();
            txtGhiChu.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int a;
            if (txtMaSach.Text == "" || txtTenSach.Text == "" || txtTacGia.Text == "" || txtTheLoai.Text == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!int.TryParse(txtSoLuong.Text, out a) || a < 0)
            {
                MessageBox.Show("Số sách phải là số nguyên dương!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    c.connect();
                    string query = "INSERT INTO KhoSach (MaSach, TenSach, MaTacGia, MaTheLoai, SoLuong, GhiChu) " +
                                  "VALUES ('" + txtMaSach.Text + "', N'" + txtTenSach.Text + "', N'" + txtTacGia.Text + "', N'" + txtTheLoai.Text + "', '"
                                  + txtSoLuong.Text + "', N'" + txtGhiChu.Text + "')";
                    bool kq = c.exeSQL(query);
                    if (kq)
                    {
                        MessageBox.Show("Thêm thành công!!", "Thông báo", MessageBoxButtons.OK);
                        loaddata();
                        clear_form();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int a;
            if (txtMaSach.Text == "" || txtTenSach.Text == "" || txtTacGia.Text == "" || txtTheLoai.Text == "" || txtSoLuong.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!int.TryParse(txtSoLuong.Text, out a) || a < 0)
            {
                MessageBox.Show("Số sách phải là số nguyên dương!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    c.connect();
                    string query = "UPDATE KhoSach SET TenSach = N'" + txtTenSach.Text + "', " +
                                  "MaTacGia = N'" + txtTacGia.Text + "', MaTheLoai = N'" + txtTheLoai.Text + "', " +
                                  "SoLuong = '" + txtSoLuong.Text + "', GhiChu = N'" + txtGhiChu.Text + "' " +
                                  "WHERE MaSach = '" + txtMaSach.Text + "'";
                    bool kq = c.exeSQL(query);
                    if (kq)
                    {
                        MessageBox.Show("Sửa thành công!!", "Thông báo", MessageBoxButtons.OK);
                        loaddata();
                        clear_form();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSach.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                c.connect();
                DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn xóa? ", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (kq == DialogResult.Yes)
                {
                    string query = "DELETE FROM KhoSach WHERE MaSach = '" + txtMaSach.Text + "'";
                    bool kq1 = c.exeSQL(query);
                    if (kq1)
                    {
                        MessageBox.Show("Xóa thành công!!", "Thông báo", MessageBoxButtons.OK);
                        loaddata();
                        clear_form();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sách: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                
            }
        }

        private void dgvKhoSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhoSach1.Rows[e.RowIndex];
                txtMaSach.Text = row.Cells["Mã sách"].Value.ToString();
                txtTenSach.Text = row.Cells["Tên sách"].Value.ToString();
                txtTacGia.Text = row.Cells["Tác giả"].Value.ToString(); // Hiển thị TenTacGia từ join
                txtTheLoai.Text = row.Cells["Thể loại"].Value.ToString(); // Hiển thị TenTheLoai từ join
                txtSoLuong.Text = row.Cells["Số lượng"].Value.ToString();
                txtGhiChu.Text = row.Cells["Ghi chú"].Value.ToString();
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
                for (int i = 0; i < dgvKhoSach1.Columns.Count; i++)
                {
                    excelApp.Cells[1, i + 1] = dgvKhoSach1.Columns[i].HeaderText;
                }

                // Xuất dữ liệu từng dòng
                for (int i = 0; i < dgvKhoSach1.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvKhoSach1.Columns.Count; j++)
                    {
                        if (dgvKhoSach1.Rows[i].Cells[j].Value != null)
                        {
                            excelApp.Cells[i + 2, j + 1] = dgvKhoSach1.Rows[i].Cells[j].Value.ToString();
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

        private void dgvKhoSach1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvKhoSach1.Rows[e.RowIndex];
            txtMaSach.Text = row.Cells["Mã sách"].Value.ToString();
            txtTenSach.Text = row.Cells["Tên sách"].Value.ToString();
            txtTacGia.Text = row.Cells["Tác giả"].Value.ToString(); // Hiển thị TenTacGia từ join
            txtTheLoai.Text = row.Cells["Thể loại"].Value.ToString(); // Hiển thị TenTheLoai từ join
            txtSoLuong.Text = row.Cells["Số lượng"].Value.ToString();
            txtGhiChu.Text = row.Cells["Ghi chú"].Value.ToString();
        }
    }
}