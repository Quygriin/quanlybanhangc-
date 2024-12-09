using quanlybanhang._quanlybanhangc_DataSetTableAdapters;
using quanlybanhang.Class;
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
    public partial class frmTimHang : Form
    {
        DataTable tblTimHang;
        public frmTimHang()
        {
            InitializeComponent();
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            string sql;
            if ((txtMaHang.Text == "") && (txtMaChatLieu.Text == "") && (txtTenHang.Text == "") )
               
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHang WHERE 1=1";
            if (txtMaHang.Text != "")
                sql = sql + " AND MaHang Like N'%" + txtMaHang.Text.Trim() + "%'";
           
            if (txtTenHang.Text != "")
                sql = sql + " AND TenHang Like N'%" + txtTenHang.Text + "%'";
            if (txtMaChatLieu.Text != "")
                sql = sql + " AND MaChatLieu Like N'%" + txtMaChatLieu.Text + "%'";
            
            tblTimHang = Functions.GetDataToTable(sql);
            if (tblTimHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblTimHang.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvTImKiemHang.DataSource = tblTimHang;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            dgvTImKiemHang.Columns[0].HeaderText = "Mã Hàng";
            dgvTImKiemHang.Columns[1].HeaderText = "Tên Hàng";
            dgvTImKiemHang.Columns[2].HeaderText = "Chất Liệu";
            dgvTImKiemHang.Columns[3].HeaderText = "Số Lượng";
            dgvTImKiemHang.Columns[4].HeaderText = "Đơn giá nhập";
            dgvTImKiemHang.Columns[5].HeaderText = "Đơn giá bán";
            dgvTImKiemHang.Columns[6].HeaderText = "Ảnh";
            dgvTImKiemHang.Columns[7].HeaderText = "Ghi Chú";
            dgvTImKiemHang.AllowUserToAddRows = false;
            dgvTImKiemHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTImKiemHang_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvTImKiemHang_DoubleClick(object sender, EventArgs e)
        {
            string mah;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mah = dgvTImKiemHang.CurrentRow.Cells["MaHang"].Value.ToString();
                frmDMHang frm = new frmDMHang();
                frm.txtMaHang.Text = mah;
                frm.WindowState = FormWindowState.Normal;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
