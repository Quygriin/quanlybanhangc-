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
using quanlybanhang.Class;

namespace quanlybanhang
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            Functions.Connect();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text.Trim() == "") { MessageBox.Show("Vui lòng nhập tài khoản"); }
            else if (txtMatKhau.Text.Trim() == "") { MessageBox.Show("Vui lòng nhập mật khẩu"); }
            else
            {
                String sql="select * from taikhoan where taikhoan= '"+txtTaiKhoan.Text.Trim()+"' and matkhau='"+Functions.MahoaSha1(txtMatKhau.Text.Trim()) +"'";
                if (Functions.CheckKey(sql))
                {
                    MessageBox.Show("Đăng nhập thành công");
                    frmMain f = new frmMain();
                    f.ShowDialog();
                  
                }
                else
                {
                    MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác"+sql);
                }
            }
        }

        private void lDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmDangKy f= new frmDangKy();
            f.ShowDialog();
         
        }

        private void lQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMatKhau f= new frmQuenMatKhau();
            f.ShowDialog();
            
        }
    }
}
