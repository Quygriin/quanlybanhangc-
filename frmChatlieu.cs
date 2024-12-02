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
    public partial class frmChatlieu : Form
    {
        string sqlstr = @"Data Source=ACER-NITRO5;Initial Catalog=quanlybanhangc#;Integrated Security=True";
        SqlConnection sqlcon = null;
        SqlDataAdapter sqldata = null;
        DataSet ds = null;
        public frmChatlieu()
        {
            InitializeComponent();
            if (sqlcon == null)
            {
                sqlcon = new SqlConnection(sqlstr);
                
            }
            string query = " select * from tblchatlieu";
            sqldata = new SqlDataAdapter(query, sqlcon);
            SqlCommandBuilder sqlbuilder = new SqlCommandBuilder(sqldata);
            ds = new DataSet();
            sqldata.Fill(ds, "tblchatlieu");
            dgvchatlieu.DataSource = ds.Tables["tblchatlieu"];


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            
            if (string.IsNullOrWhiteSpace(txtmachatlieu.Text) || string.IsNullOrWhiteSpace(txttenchatlieu.Text))
            {
                MessageBox.Show("không được bỏ trống");
                return;
            }

            foreach (DataRow row1 in ds.Tables["tblchatlieu"].Rows)
            {
                if (row1["machatlieu"].ToString() == txtmachatlieu.Text.Trim())
                {
                    MessageBox.Show("Mã chất liệu đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            
                DataRow row = ds.Tables["tblchatlieu"].NewRow();
                row["machatlieu"] = txtmachatlieu.Text.Trim();
                row["tenchatlieu"] = txttenchatlieu.Text.Trim();
                ds.Tables["tblchatlieu"].Rows.Add(row);

                int kq = sqldata.Update(ds.Tables["tblchatlieu"]);
                if (kq > 0)
                {
                    MessageBox.Show("thêm thành công!");
                }
                else
                {
                    MessageBox.Show("thêm thất bại!");
                }
            
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmachatlieu_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtmachatlieu.Text))
            {
                errorProvider1.SetError(txtmachatlieu, "không được để trống");
            }
            
        }

        private void txttenchatlieu_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txttenchatlieu.Text))
            {
                errorProvider1.SetError(txttenchatlieu, "không được để trống");
            }
        }
        int vt = -1;
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (vt < 0 || vt >= ds.Tables["tblchatlieu"].Rows.Count)
            {
                MessageBox.Show("chọn một đối tượng để chỉnh sửa");
            }
            if (string.IsNullOrWhiteSpace(txtmachatlieu.Text) || string.IsNullOrWhiteSpace(txttenchatlieu.Text))
            {
                MessageBox.Show("không được bỏ trống");
                return;
            }
            
            foreach (DataRow row1 in ds.Tables["tblchatlieu"].Rows)
            {
                // Kiểm tra nếu mã chất liệu trùng, nhưng bỏ qua dòng hiện tại
                if (row1["machatlieu"].ToString() == txtmachatlieu.Text.Trim() &&
                    row1 != ds.Tables["tblchatlieu"].Rows[vt]) // vt là vị trí dòng đang chỉnh sửa
                {
                    MessageBox.Show("Mã chất liệu đã tồn tại trong cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DataRow row = ds.Tables["tblchatlieu"].Rows[vt];
            row.BeginEdit();
           
            row["machatlieu"] = txtmachatlieu.Text.Trim();
            row["tenchatlieu"] = txttenchatlieu.Text.Trim();
            row.EndEdit();
            int kq = sqldata.Update(ds.Tables["tblchatlieu"]);
            if(kq > 0)
            {
                MessageBox.Show("cập nhật thành công");
            }
            else
            {
                MessageBox.Show("cập nhật thất bại");

            }
           
        }
    
        private void dgvchatlieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dgvchatlieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            //DataGridViewRow selectedRow = dgvchatlieu.Rows[e.RowIndex];
            vt =e.RowIndex;
            if (vt < 0 || vt >= ds.Tables["tblchatlieu"].Rows.Count)
            {
                return; // Bỏ qua nếu click vào dòng tiêu đề hoặc dòng trống cuối
            }

            DataRow row = ds.Tables["tblchatlieu"].Rows[vt];
            txtmachatlieu.Text = row["machatlieu"].ToString();
            txttenchatlieu.Text = row["tenchatlieu"].ToString();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (vt < 0 || vt >= ds.Tables["tblchatlieu"].Rows.Count)
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
                foreach (DataGridViewRow row in dgvchatlieu.SelectedRows)
                {
                    ds.Tables["tblchatlieu"].Rows[row.Index].Delete();
                }
            }
            int kq1 = sqldata.Update(ds.Tables["tblchatlieu"]);
            if (kq1 > 0) {
                MessageBox.Show("đã xóa  đôi tượng thành công");

            }
            else
            {
                MessageBox.Show("xóa thất bại");
            }

        }
    }
}
