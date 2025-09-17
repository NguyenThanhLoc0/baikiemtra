using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xaydungquanlythuvien
{
    public partial class DangXuat : Form
    {
        public DangXuat()
        {
            InitializeComponent();
            DialogResult kq = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất? ", "Thông báo",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
