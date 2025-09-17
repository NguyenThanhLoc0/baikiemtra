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
            KhoSach frm = new KhoSach();
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
            HoaDonMuon frm = new HoaDonMuon();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
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

        
    }
}
