
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using quanlybanhang.Class;
using System.Data.SqlClient;
namespace quanlybanhang
{
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {

            this.rpvBaoCaoDoanhThu.RefreshReport();
            this.rpvBaoCaoDoanhThu.RefreshReport();
        }

        private void btnTaoBaoCao_Click(object sender, EventArgs e)
        {
            Functions.Connect();
            string sql = "select MaHDBan,NgayBan,TongTien from tblhdban where " +
                "NgayBan ='" +dtpNgayBaoCao.Value.Date+ "'";
            MessageBox.Show(sql);
            DataTable dt = new DataTable();
            dt = Functions.GetDataToTable(sql);
            rpvBaoCaoDoanhThu.ProcessingMode = ProcessingMode.Local; ;
            rpvBaoCaoDoanhThu.LocalReport.ReportPath = "C:\\Users\\admin\\source\\repos\\quanlybanhang\\RPTBaoCaoDoanhThu.rdlc";
            if (dt.Rows.Count > 0)
            {
                ReportDataSource ds = new ReportDataSource();
                ds.Name = "baocaodoanhthu";
                ds.Value = dt;
                rpvBaoCaoDoanhThu.LocalReport.DataSources.Clear();
                rpvBaoCaoDoanhThu.LocalReport.DataSources.Add(ds);
                rpvBaoCaoDoanhThu.RefreshReport();

            }
            else
            {
                MessageBox.Show("Không có doanh thu");
            }
        }
    }
}
