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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void mnuQuanLy_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien frm = new NhanVien();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void mnuKhoSach_Click(object sender, EventArgs e)
        {
            KhoSach1 frm = new KhoSach1();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        

        private void mnuDocGia_Click(object sender, EventArgs e)
        {
            docGia frm = new docGia();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void mnuMuonTra_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuHoaDonMuon_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            // Ẩn form Main hiện tại
            this.Hide();

            // Mở lại form Đăng nhập
            DangNhap frmLogin = new DangNhap();
            frmLogin.ShowDialog();

            // Sau khi đóng form Đăng nhập thì thoát luôn Main
            this.Close();
        }

        private void mnuTacGia_Click(object sender, EventArgs e)
        {
            TacGia frm = new TacGia();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void mnuHoaDonNhanHang_Click(object sender, EventArgs e)
        {
            HoaDonNhapHang frm = new HoaDonNhapHang();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void mnuNhaXuatBan_Click(object sender, EventArgs e)
        {
            NhaXuatBan frm = new NhaXuatBan();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void mnuPhieuMuon_Click(object sender, EventArgs e)
        {
            PhieuMuon frm = new PhieuMuon();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void mnuPhieuTra_Click(object sender, EventArgs e)
        {
            PhieuTra frm = new PhieuTra();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void traPhiếuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuTraPhieuMuon_Click(object sender, EventArgs e)
        {
            TraPhieuMuon frm = new TraPhieuMuon();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
