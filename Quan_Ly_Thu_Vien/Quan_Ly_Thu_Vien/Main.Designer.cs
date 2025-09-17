using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Thu_Vien
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_taikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_dangxuat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuHangHoa = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHoaDon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tưVấnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMuonTra = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem4,
            this.trợGiúpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1653, 43);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_taikhoan,
            this.menu_dangxuat,
            this.toolStripMenuItem6});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 39);
            this.toolStripMenuItem1.Text = "Hệ Thống";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // menu_taikhoan
            // 
            this.menu_taikhoan.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_taikhoan.Name = "menu_taikhoan";
            this.menu_taikhoan.Size = new System.Drawing.Size(224, 30);
            this.menu_taikhoan.Text = "Tài khoản";
            this.menu_taikhoan.Click += new System.EventHandler(this.menu_tikhoan_Click);
            // 
            // menu_dangxuat
            // 
            this.menu_dangxuat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menu_dangxuat.Name = "menu_dangxuat";
            this.menu_dangxuat.Size = new System.Drawing.Size(224, 30);
            this.menu_dangxuat.Text = "Thoát";
            this.menu_dangxuat.Click += new System.EventHandler(this.menu_dangxuat_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(221, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuNhanVien,
            this.MenuKhachHang,
            this.toolStripMenuItem7,
            this.MenuHangHoa,
            this.MenuHoaDon,
            this.MenuMuonTra});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 39);
            this.toolStripMenuItem2.Text = "Danh mục";
            // 
            // MenuNhanVien
            // 
            this.MenuNhanVien.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuNhanVien.Name = "MenuNhanVien";
            this.MenuNhanVien.Size = new System.Drawing.Size(283, 30);
            this.MenuNhanVien.Text = "Quản lý nhân viên";
            // 
            // MenuKhachHang
            // 
            this.MenuKhachHang.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuKhachHang.Name = "MenuKhachHang";
            this.MenuKhachHang.Size = new System.Drawing.Size(283, 30);
            this.MenuKhachHang.Text = "Quản lý tài khoản";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(280, 6);
            // 
            // MenuHangHoa
            // 
            this.MenuHangHoa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuHangHoa.Name = "MenuHangHoa";
            this.MenuHangHoa.Size = new System.Drawing.Size(283, 30);
            this.MenuHangHoa.Text = "Quản lý sản phẩm";
            // 
            // MenuHoaDon
            // 
            this.MenuHoaDon.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuHoaDon.Name = "MenuHoaDon";
            this.MenuHoaDon.Size = new System.Drawing.Size(283, 30);
            this.MenuHoaDon.Text = "Quản lý hóa đơn";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(274, 39);
            this.toolStripMenuItem4.Text = "Báo cáo - Thống kê";
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tưVấnToolStripMenuItem});
            this.trợGiúpToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(141, 39);
            this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            // 
            // tưVấnToolStripMenuItem
            // 
            this.tưVấnToolStripMenuItem.Name = "tưVấnToolStripMenuItem";
            this.tưVấnToolStripMenuItem.Size = new System.Drawing.Size(224, 40);
            this.tưVấnToolStripMenuItem.Text = "Tư vấn";
            // 
            // MenuMuonTra
            // 
            this.MenuMuonTra.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold);
            this.MenuMuonTra.Name = "MenuMuonTra";
            this.MenuMuonTra.Size = new System.Drawing.Size(283, 30);
            this.MenuMuonTra.Text = "Quản lý mượn trả";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1653, 740);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menu_taikhoan;
        private System.Windows.Forms.ToolStripMenuItem menu_dangxuat;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuKhachHang;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem MenuHangHoa;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tưVấnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuHoaDon;
        private System.Windows.Forms.ToolStripMenuItem MenuNhanVien;
        private ToolStripMenuItem MenuMuonTra;
    }
}