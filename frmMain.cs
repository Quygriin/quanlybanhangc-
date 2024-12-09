using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlybanhang
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class.Functions.Disconnect();
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Class.Functions.Connect(); //Mở kết nối
            this.WindowState = FormWindowState.Normal;

        }
        private void closeform()
        {
            // Đóng tất cả các Form con đang mở
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
        }
        private void mnuChatLieu_Click(object sender, EventArgs e)
        {
            closeform();
            frmChatlieu fcl = new frmChatlieu();
            fcl.MdiParent = this;
            fcl.Show();
        }

        private void mnuFindHoaDon_Click(object sender, EventArgs e)
        {
            closeform();
            frmTimHDBan f = new frmTimHDBan();
            //f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            //f.Dock = DockStyle.Fill;
            //pnFrmMain.Controls.Add(f);
           
            f.MdiParent = this;
            f.Show();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            closeform();
            frmHoaDonBan f = new frmHoaDonBan();
            //f.FormBorderStyle = FormBorderStyle.None;
            //f.MinimumSize = new Size(300, 300);
           f.MdiParent = this;
           f.Show();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            closeform();
            frmDMHang f = new frmDMHang();
            //f.FormBorderStyle = FormBorderStyle.None;
            //f.MinimumSize = new Size(300, 300);
            //f.WindowState = FormWindowState.Normal;
            f.MdiParent = this;
            f.Show();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            closeform();
            frmnhanvien fnv = new frmnhanvien();
            fnv.MdiParent = this;
            fnv.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
                closeform();
            frmkhachhang fkh = new frmkhachhang();
            fkh.MdiParent = this;  
            fkh.Show();
        }

        private void mnuBCHangTon_Click(object sender, EventArgs e)
        {
            closeform();
            frmBaoCaoHangTon fkh = new frmBaoCaoHangTon();
            fkh.MdiParent = this;
            fkh.Show();
        }

        private void mnuBCDoanhThu_Click(object sender, EventArgs e)
        {
            closeform();
            frmBaoCaoDoanhThu fkh = new frmBaoCaoDoanhThu();
            fkh.MdiParent = this;
            fkh.Show();
        }

        private void mnuFindHang_Click(object sender, EventArgs e)
        {
            closeform();
            frmTimHang fkh = new frmTimHang();
            fkh.MdiParent = this;
            fkh.Show();
        }

        private void mnutrogiup_Click(object sender, EventArgs e)
        {

        }
    }
}
