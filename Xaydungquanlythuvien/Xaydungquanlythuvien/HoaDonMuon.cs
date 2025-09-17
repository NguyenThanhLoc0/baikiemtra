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
    public partial class HoaDonMuon : Form
    {
        connectData c = new connectData();
        void loaddata()
        {
            dgvHoaDonMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            c.connect();
            DataSet data = new DataSet();
            string query = "SELECT * FROM HoaDonMuon ";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, c.conn);
            sqlData.Fill(data);
            dgvHoaDonMuon.DataSource = data.Tables[0];
            c.disconnect();
        }
        public void clear_form()
        {
            txtMaHoaDonMuon.Text = "";
            txtMaDocGia.Text = "";
            txtTenDocGia.Text = "";
            txtTenSach.Text = "";
            txtTacGia.Text = "";
            
            txtDonGia.Text = "";
            dateNgayMuon.Text = "";
            txtMaHoaDonMuon.Focus();
            dateNgayTra.Text = "";
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtGhiChu.Text = "";
        }
        public HoaDonMuon()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            double a;
            if (txtMaHoaDonMuon.Text == "" || txtMaDocGia.Text == "" || txtTenDocGia.Text == "" || txtTenSach.Text == "" || txtTacGia.Text == "" || txtDonGia.Text == ""
                || dateNgayMuon.Text == "" || dateNgayTra.Text == "" || txtMaNhanVien.Text == "" || txtTenNhanVien.Text == ""   )
            {
                MessageBox.Show("Chưa nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
            else if (!double.TryParse(this.txtDonGia.Text, out a))
            {
                MessageBox.Show("số tiền phải là số!!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                c.connect();
                DateTime ngaymuon = Convert.ToDateTime(dateNgayMuon.Text);
                string ngaymuonFormatted = ngaymuon.ToString("dd-MM-yyyy");

                DateTime ngaytra = Convert.ToDateTime(dateNgayMuon.Text);
                string ngaytraFormatted = ngaytra.ToString("dd-MM-yyyy");


                string query = "INSERT INTO HoaDonMuon(MaHoaDonMuon, MaDocGia, TenDocGia, TenSach, TacGia, DonGia, NgayMuon, NgayTra, MaNhanVien, TenNhanVien, GhiChu) " +
               "VALUES ('" + txtMaHoaDonMuon.Text + "'," +
               "'" + txtMaDocGia.Text + "'," +
               "N'" + txtTenDocGia.Text + "'," +
               "N'" + txtTenSach.Text + "'," +
               "N'" + txtTacGia.Text + "'," +
               "'" + txtDonGia.Text + "'," +
               "'" + dateNgayMuon.Value.ToString("yyyy-MM-dd") + "'," +
               "'" + dateNgayTra.Value.ToString("yyyy-MM-dd") + "'," +
               "'" + txtMaNhanVien.Text + "'," +
               "N'" + txtTenNhanVien.Text + "'," +
               "N'" + txtGhiChu.Text + "')";
                bool kq = c.exeSQL(query);
                MessageBox.Show("Thêm thành công!!", "Thông báo", MessageBoxButtons.OK);
                loaddata();
                clear_form();

            }



        }

        private void dgvHoaDonMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvHoaDonMuon.CurrentRow.Index;

            txtMaHoaDonMuon.Text = dgvHoaDonMuon.Rows[i].Cells[0].Value.ToString();      // Mã hóa đơn mượn
            txtMaDocGia.Text = dgvHoaDonMuon.Rows[i].Cells[1].Value.ToString();      // Mã khách hàng
            txtTenDocGia.Text = dgvHoaDonMuon.Rows[i].Cells[2].Value.ToString();     // Tên khách hàng
            txtTenSach.Text = dgvHoaDonMuon.Rows[i].Cells[3].Value.ToString();       // Tên sách
            txtTacGia.Text = dgvHoaDonMuon.Rows[i].Cells[4].Value.ToString();        // Tác giả
            txtDonGia.Text = dgvHoaDonMuon.Rows[i].Cells[5].Value.ToString();        // Đơn giá
            dateNgayMuon.Text = dgvHoaDonMuon.Rows[i].Cells[6].Value.ToString();      // Ngày mượn
            dateNgayTra.Text = dgvHoaDonMuon.Rows[i].Cells[7].Value.ToString();       // Ngày trả
            txtMaNhanVien.Text = dgvHoaDonMuon.Rows[i].Cells[8].Value.ToString();    // Mã nhân viên cho mượn
            txtTenNhanVien.Text = dgvHoaDonMuon.Rows[i].Cells[9].Value.ToString();   // Nhân viên cho mượn
            txtGhiChu.Text = dgvHoaDonMuon.Rows[i].Cells[10].Value.ToString();       // Ghi chú
        }

        private void HoaDonMuon_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo đối tượng Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Application.Workbooks.Add(Type.Missing);

                // Xuất tiêu đề cột
                for (int i = 0; i < dgvHoaDonMuon.Columns.Count; i++)
                {
                    excelApp.Cells[1, i + 1] = dgvHoaDonMuon.Columns[i].HeaderText;
                }

                // Xuất dữ liệu từng dòng
                for (int i = 0; i < dgvHoaDonMuon.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvHoaDonMuon.Columns.Count; j++)
                    {
                        if (dgvHoaDonMuon.Rows[i].Cells[j].Value != null)
                        {
                            excelApp.Cells[i + 2, j + 1] = dgvHoaDonMuon.Rows[i].Cells[j].Value.ToString();
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
