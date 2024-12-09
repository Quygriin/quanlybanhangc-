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
using System.Data.SqlTypes;

namespace quanlybanhang
{
    public partial class frmnhanvien : Form
    {
        string sqlstr = @"Data Source=LAPTOP-U119GDF0\SQLEXPRESS;Initial Catalog=quanlybanhangc#;Integrated Security=True";
        SqlConnection sqlcon = null;
        SqlDataAdapter sqldata = null;
        DataSet ds = null;
        public frmnhanvien()
        {
            InitializeComponent();
            if (sqlcon == null)
            {
                sqlcon = new SqlConnection(sqlstr);

            }
            string query = " select * from tblnhanvien";
            sqldata = new SqlDataAdapter(query, sqlcon);
            SqlCommandBuilder sqlbuilder = new SqlCommandBuilder(sqldata);
            ds = new DataSet();
            sqldata.Fill(ds, "tblnhanvien");
            dgvnhanvien.DataSource = ds.Tables["tblnhanvien"];
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtmanv.Text)|| string.IsNullOrWhiteSpace(txttennv.Text)|| cmbgioitinh.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtdiachi.Text) || string.IsNullOrWhiteSpace(txtdienthoai.Text)) 
            {
                MessageBox.Show("không được bỏ trống thông tin");
                return; 
            }else if (txttennv.Text.Trim().Any(char.IsDigit))
            {
                MessageBox.Show("tên nhân viên không hợp lệ");
                return ;
            }else if (txtdienthoai.Text.Trim().Length != 10)
            {
                MessageBox.Show("số điện thoại phải 10 số");
            }

            foreach (DataRow row in ds.Tables["tblnhanvien"].Rows)
            {
                if (row["manhanvien"].ToString() == txtmanv.Text.Trim())
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DataRow row1 = ds.Tables["tblnhanvien"].NewRow();
            row1["manhanvien"] = txtmanv.Text.Trim();
            row1["tennhanvien"]=txttennv.Text.Trim();
            row1["gioitinh"]=cmbgioitinh.Text;
            row1["diachi"]=txtdiachi.Text.Trim();
            row1["dienthoai"]= txtdienthoai.Text.Trim();
            row1["ngaysinh"]=datetimengaysinh.Text.Trim();

            ds.Tables["tblnhanvien"].Rows.Add(row1);

            int kq = sqldata.Update(ds.Tables["tblnhanvien"]);
            if (kq > 0)
            {
                MessageBox.Show("thêm thành công");
                return;
            }
            else
            {
                MessageBox.Show("thêm thất bại");
                return;
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmanv_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtmanv.Text))
            {
                errorProvider1.SetError(txtmanv,"không được bỏ trống");
                return;
            }
        }

        private void txtdiachi_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtdiachi.Text))
            {
                errorProvider1.SetError(txtdiachi, "không được bỏ trống");
                return;
            }
        }

        private void txtdienthoai_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtdienthoai.Text))
            {
                errorProvider1.SetError(txtdienthoai, "không được bỏ trống");
                return;
            }else if(!long.TryParse(txtdienthoai.Text.Trim(), out long l) || l < 0)
            {
                errorProvider1.SetError(txtdienthoai,"số điện thoại phải là số");
                return;
            }
                    
        }

        private void cmbgioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (cmbgioitinh.SelectedIndex==-1)
            {
                errorProvider1.SetError(cmbgioitinh, "không được bỏ trống");
                return;
            }
        }
       
        private void datetimengaysinh_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void txttennv_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txttennv.Text))
            {
                errorProvider1.SetError(txttennv, "không được bỏ trống");
                return;
            }
            else if (txttennv.Text.Trim().Any(char.IsDigit)) 
            {
                errorProvider1.SetError(txttennv, "tên không được chứa số");
            }
        }

        private void dgvnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int vt = -1;
        private void dgvnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt < 0 || vt >= ds.Tables["tblnhanvien"].Rows.Count)
            {
                return; // Bỏ qua nếu click vào dòng tiêu đề hoặc dòng trống cuối
            }

            DataRow row = ds.Tables["tblnhanvien"].Rows[vt];
            txtmanv.Text = row["manhanvien"].ToString();
            txttennv.Text = row["tennhanvien"].ToString();
            txtdiachi.Text= row["diachi"].ToString() ;
            txtdienthoai.Text = row["dienthoai"].ToString();
            cmbgioitinh.Text = row["gioitinh"].ToString();
            // Lấy giá trị từ ô chứa ngày tháng trong DataGridView
            string dateValue = dgvnhanvien.Rows[e.RowIndex].Cells["ngaysinh"].Value?.ToString();

            // Kiểm tra nếu giá trị không null hoặc rỗng
            if (!string.IsNullOrEmpty(dateValue) && DateTime.TryParse(dateValue, out DateTime parsedDate))
            {
                // Gán giá trị cho DateTimePicker
                datetimengaysinh.Value = parsedDate;
            }

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (vt < 0 || vt >= ds.Tables["tblnhanvien"].Rows.Count)
            {
                MessageBox.Show("chọn một đối tượng để chỉnh sửa");
            }
            if (string.IsNullOrWhiteSpace(txtmanv.Text) || string.IsNullOrWhiteSpace(txttennv.Text) || cmbgioitinh.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtdiachi.Text) || string.IsNullOrWhiteSpace(txtdienthoai.Text))
            {
                MessageBox.Show("không được bỏ trống thông tin");
                return;
            }
            foreach (DataRow row in ds.Tables["tblnhanvien"].Rows)
            {
                // Kiểm tra nếu mã chất liệu trùng, nhưng bỏ qua dòng hiện tại
                if (row["manhanvien"].ToString() == txtmanv.Text.Trim() &&
                    row != ds.Tables["tblnhanvien"].Rows[vt]) // vt là vị trí dòng đang chỉnh sửa
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DataRow row1 = ds.Tables["tblnhanvien"].Rows[vt];
            row1.BeginEdit();
            row1["manhanvien"] = txtmanv.Text.Trim();
            row1["tennhanvien"] = txttennv.Text.Trim();
            row1["gioitinh"] = cmbgioitinh.Text;
            row1["diachi"] = txtdiachi.Text.Trim();
            row1["dienthoai"] = txtdienthoai.Text.Trim();
            row1["ngaysinh"] = datetimengaysinh.Text.Trim();
            row1.EndEdit();
            int kq = sqldata.Update(ds.Tables["tblnhanvien"]);
            if (kq > 0)
            {
                MessageBox.Show("chỉnh sửa thành công");
                return;
            }
            else
            {
                MessageBox.Show("chỉnh sửa thất bại");
                return;
            }
            
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if(vt < 0 || vt >= ds.Tables["tblnhanvien"].Rows.Count)
            {
                MessageBox.Show("chọn một đối tuợng để xóa");
                return; // Bỏ qua nếu click vào dòng tiêu đề hoặc dòng trống cuối
            }
            DialogResult kq = MessageBox.Show("bạn có chắc muốn xóa dữ liệu này không ?", "hộp thoại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.No)
            {
                return;
            }
            else if (kq == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvnhanvien.SelectedRows)
                {
                    ds.Tables["tblnhanvien"].Rows[row.Index].Delete();
                }
            }
            int kq1 = sqldata.Update(ds.Tables["tblnhanvien"]);
            if (kq1 > 0)
            {
                MessageBox.Show("xóa thành công");
                return;
            }
            else
            {
                MessageBox.Show("xóa thất bại");
                return;
            }
        }

        private void frmnhanvien_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
