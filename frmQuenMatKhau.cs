using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlybanhang.Class;
using System.Net.Mail;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace quanlybanhang
{
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
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
        private void btnLayLai_Click(object sender, EventArgs e)
        {
            if (!Functions.IsEmail(txtEmail.Text.Trim()))
            {
                errorProvider.SetError(txtEmail, "Nhập đúng định dạng email");
            }
            else { errorProvider.SetError(txtEmail, null); }
            if (HasAnyError()) MessageBox.Show("Chưa nhập đúng email");
            else
            {
               string sql = "select email from taikhoan where email='" + txtEmail.Text.Trim() + "'";
                if (Functions.GetFieldValues(sql)!="")
                {
                    string newPassword = GenerateRandomPassword();
                    SendEmail(Functions.GetFieldValues(sql),newPassword);
                    sql="update taikhoan set matkhau='"+Functions.MahoaSha1(newPassword)+"' where email='"+txtEmail.Text.Trim()+"'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Gửi thành công");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("email không tồn tại");
                }
            }
        }
        private void SendEmail(string email, string newPassword)
        {
             String username = "nguyentienquy26@gmail.com";
             String password = "ujntfbpjblvmobra";// Dùng App Password

           
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            MailMessage message = new MailMessage
            {
                From = new MailAddress(username),
                Subject = "Khôi phục mật khẩu",
                Body = $"Mật khẩu mới của bạn là: {newPassword}\nHãy đăng nhập và đổi mật khẩu ngay lập tức.",
                IsBodyHtml = false
            };

            message.To.Add(email);

            smtp.Send(message);
        }
        private string GenerateRandomPassword()
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < 6; i++) // Mật khẩu 10 ký tự
            {
                sb.Append(validChars[rnd.Next(validChars.Length)]);
            }

            return sb.ToString();
        }
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (!Functions.IsEmail(txtEmail.Text.Trim()))
            {
                errorProvider.SetError(txtEmail, "Nhập đúng định dạng email");
            }
            else { errorProvider.SetError(txtEmail, null); }
        }
    }
}
