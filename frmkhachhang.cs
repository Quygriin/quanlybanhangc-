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
namespace quanlybanhang
{
    
    public partial class frmkhachhang : Form
    {
        string sqlstr = @"Data Source=ACER-NITRO5;Initial Catalog=quanlybanhangc#;Integrated Security=True";
        SqlConnection sqlcon = null;
        SqlDataAdapter sqldata = null;
        DataSet ds = null;
        public frmkhachhang()
        {
            InitializeComponent();
            if (sqlcon == null)
            {
                sqlcon = new SqlConnection(sqlstr);

            }
            string query = " select * from tblkhach";
            sqldata = new SqlDataAdapter(query, sqlcon);
            SqlCommandBuilder sqlbuilder = new SqlCommandBuilder(sqldata);
            ds = new DataSet();
            sqldata.Fill(ds, "tblkhach");
            dgvkhachhang.DataSource = ds.Tables["tblkhach"];

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtmakh.Text)) {
                errorProvider1.SetError(txtmakh, "không được để trống");
                return;
            }
        }

        private void txttenkh_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txttenkh.Text))
            {
                errorProvider1.SetError(txttenkh, "không được để trống");
                return;
            }else if(txttenkh.Text.Trim().Any(char.IsDigit)) {
                errorProvider1.SetError(txttenkh, "tên không được chứa số");
                return ;
            }
        }

        private void txtdiachi_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtdiachi.Text))
            {
                errorProvider1.SetError(txtdiachi, "không được để trống");
                return;
            }
        }

        private void txtdienthoai_TextChanged(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtdienthoai.Text))
            {
                errorProvider1.SetError(txtdienthoai, "không được để trống");
                return;
            }
            else if (!long.TryParse(txtdienthoai.Text.Trim(), out _)) {
                MessageBox.Show("số điện thoại phải là dãy số ");
            }
            
        }

        private void dgvkhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int vt = -1;
        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt < 0 || vt >= ds.Tables["tblkhach"].Rows.Count)
            {
                return ;
            }
            DataRow row = ds.Tables["tblkhach"].Rows[vt];
            txtmakh.Text = row["makhach"].ToString();
            txttenkh.Text = row["tenkhach"].ToString();
            txtdiachi.Text = row["diachi"].ToString();
            txtdienthoai.Text = row["dienthoai"].ToString() ;
            
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmakh.Text) || string.IsNullOrWhiteSpace(txttenkh.Text) || string.IsNullOrWhiteSpace(txtdiachi.Text) || string.IsNullOrWhiteSpace(txtdienthoai.Text))
            {
                MessageBox.Show("không được bỏ trống thông tin");
                return;
            }
            else if (txttenkh.Text.Trim().Any(char.IsDigit))
            {
                MessageBox.Show("tên không hợp lệ");
                return;

            }
            else if (!long.TryParse(txtdienthoai.Text, out _))
            {
                MessageBox.Show("số điện thoại không hợp lệ");
                return;
            }else if (!(txtdienthoai.Text.Trim().Length == 10))
            {
                MessageBox.Show("số điện thoại phải 10 số");
                return;
            }
            DataRow row = ds.Tables["tblkhach"].NewRow();
            row["makhach"] = txtmakh.Text.Trim();
            row["tenkhach"]=txttenkh.Text.Trim();
            row["diachi"]= txtdiachi.Text.Trim();
            row["dienthoai"]=txtdienthoai.Text.Trim() ;

            ds.Tables["tblkhach"].Rows.Add(row);
            int kq = sqldata.Update(ds.Tables["tblkhach"]);
            if (kq > 0)
            {
                MessageBox.Show("thêm dữ liệu thành công");
                return ;
            }
            else
            {
                MessageBox.Show("thêm dữ liệu thất bại");
                return ;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtmakh.Text) || string.IsNullOrWhiteSpace(txttenkh.Text) || string.IsNullOrWhiteSpace(txtdiachi.Text) || string.IsNullOrWhiteSpace(txtdienthoai.Text))
            {
                MessageBox.Show("không được bỏ trống thông tin");
                return;
            }
            else if (txttenkh.Text.Trim().Any(char.IsDigit))
            {
                MessageBox.Show("tên không hợp lệ");
                return;

            }
            else if (!long.TryParse(txtdienthoai.Text, out _))
            {
                MessageBox.Show("số điện thoại không hợp lệ");
                return;
            }
            else if (!(txtdienthoai.Text.Trim().Length == 10))
            {
                MessageBox.Show("số điện thoại phải 10 số");
                return;
            }
            if (vt < 0 || vt >= ds.Tables["tblkhach"].Rows.Count)
            {
                MessageBox.Show("chọn một đối tượng để chỉnh sửa");
                return;
            }
            foreach (DataRow row1 in ds.Tables["tblkhach"].Rows)
            {
                // Kiểm tra nếu mã chất liệu trùng, nhưng bỏ qua dòng hiện tại
                if (row1["makhach"].ToString() == txtmakh.Text.Trim() &&
                    row1 != ds.Tables["tblkhach"].Rows[vt]) // vt là vị trí dòng đang chỉnh sửa
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DataRow row = ds.Tables["tblkhach"].Rows [vt];
            row.BeginEdit ();
            row["makhach"]=txtmakh.Text.Trim();
            row["tenkhach"]=txttenkh.Text.Trim();
            row["diachi"]=txtdiachi.Text.Trim();
            row["dienthoai"]=txtdienthoai.Text.Trim ();
            row.EndEdit ();
            int kq = sqldata.Update(ds.Tables["tblkhach"]);
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
            if (vt < 0 || vt >= ds.Tables["tblkhach"].Rows.Count)
            {
                MessageBox.Show("chọn một đối tượng để xóa");
                return;
            }
            DialogResult kq = MessageBox.Show("bạn có chắc muốn xóa dữ liệu này không ?", "hộp thoại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (kq == DialogResult.No)
            {
                return;
            }
            else
            {
                foreach (DataGridViewRow row in dgvkhachhang.SelectedRows)
                {
                    ds.Tables["tblkhach"].Rows[row.Index].Delete();
                }
            }
            int kq1 = sqldata.Update(ds.Tables["tblkhach"]);
            if (kq1 > 0)
            {
                MessageBox.Show("đã xóa  đôi tượng thành công");

            }
            else
            {
                MessageBox.Show("xóa thất bại");
            }
        }
    }
}
