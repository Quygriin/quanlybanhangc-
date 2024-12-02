using Microsoft.Office.Interop.Excel;
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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();

        }
        ErrorProvider errorProvider = new ErrorProvider();
        private bool HasAnyError()
        {
            foreach (Control control in this.Controls)
            {
                if (!string.IsNullOrEmpty(errorProvider.GetError(control)))
                {
                    return true; // Có lỗi
                }
            }
            return false; // Không có lỗi
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string sql = "select * from taikhoan where taikhoan='" + txtTaiKhoan.Text.Trim() + "'";
           

            if (!Functions.CheckAccount(txtTaiKhoan.Text.Trim()))
            {
                
                errorProvider.SetError(txtTaiKhoan, "Tài khoản không gồm ký tự đặc biệt 6-255 ký tự");
            }
            else { errorProvider.SetError(txtTaiKhoan, null); }


            if (txtMatKhau.Text.Trim().Length < 6)
            {
                
                errorProvider.SetError(txtMatKhau, "Nhap mat khau it nhat 6 ki tu");
            }
            else
            {
                errorProvider.SetError(txtMatKhau, null); 
            }

            if (txtMatKhau.Text.Trim() != txtXacNhanMK.Text.Trim())
            {
                errorProvider.SetError(txtXacNhanMK, "Nhập lại sai"); 
            }
            else { errorProvider.SetError(txtXacNhanMK, null);  }

            if (!Functions.IsEmail(txtEmail.Text.Trim()))
            {
                errorProvider.SetError(txtEmail, "Nhập đúng định dạng email");
            }
            else { errorProvider.SetError(txtEmail, null); }
            if (HasAnyError()) { MessageBox.Show("Chưa nhập đủ thông tin"); }
            else
            {
                if (Functions.GetFieldValues(sql) != "")
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                }
                else
                {
                    sql= "select * from taikhoan where email='" + txtEmail.Text.Trim() + "'";
                    if (Functions.GetFieldValues(sql) == "")
                    {
                        sql = "INSERT INTO taikhoan(taikhoan, matkhau, email) VALUES ('" + txtTaiKhoan.Text.Trim() + "','" +
                             Functions.MahoaSha1(txtMatKhau.Text.Trim()) + "','" + txtEmail.Text + "')";
                        Functions.RunSQL(sql);
                        MessageBox.Show("Đăng ký thành công");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Email đã được đăng ký");
                    }
                }
            }
           
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.CheckAccount(txtTaiKhoan.Text.Trim()))
            {

                errorProvider.SetError(txtTaiKhoan, "Tài khoản không gồm ký tự đặc biệt 6-255 ký tự");
            }
            else { errorProvider.SetError(txtTaiKhoan, null); }

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim().Length < 6)
            {
                errorProvider.SetError(txtMatKhau, "Nhap mat khau it nhat 6 ki tu");
            }
            else
            {
                errorProvider.SetError(txtMatKhau, null);
            }
        }

        private void txtXacNhanMK_TextChanged(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Trim() != txtXacNhanMK.Text.Trim())
            {
                errorProvider.SetError(txtXacNhanMK, "Nhập lại sai");
            }
            else { errorProvider.SetError(txtXacNhanMK, null); }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsEmail(txtEmail.Text.Trim()))
            {
                errorProvider.SetError(txtEmail, "Nhập đúng định dạng email");
            }
            else { errorProvider.SetError(txtEmail, null); }
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {

        }
    }

}
