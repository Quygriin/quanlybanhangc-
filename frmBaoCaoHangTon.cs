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
using Microsoft.Reporting.WinForms;
namespace quanlybanhang
{
    public partial class frmBaoCaoHangTon : Form
    {
        public frmBaoCaoHangTon()
        {
            InitializeComponent();
        }

        private void frmBaoCaoHangTon_Load(object sender, EventArgs e)
        {

            this.rpvBaoCaoHangTon.RefreshReport();
            this.rpvBaoCaoHangTon.RefreshReport();
        }

        private void btnTaoBaoCao_Click_1(object sender, EventArgs e)
        {
            Functions.Connect();
            string sql = "select mahang,TenHang,soluong,DonGiaNhap,DonGiaBan from tblhang";
              DataTable dt = new DataTable();
            dt = Functions.GetDataToTable(sql);
            rpvBaoCaoHangTon.ProcessingMode = ProcessingMode.Local; ;
            rpvBaoCaoHangTon.LocalReport.ReportPath = "C:\\Users\\admin\\source\\repos\\quanlybanhang\\RPTBaoCaoHangTon.rdlc";
            if (dt.Rows.Count > 0)
            {
                ReportDataSource ds = new ReportDataSource();
                ds.Name = "baocaohangton";
                ds.Value = dt;
                rpvBaoCaoHangTon.LocalReport.DataSources.Clear();
                rpvBaoCaoHangTon.LocalReport.DataSources.Add(ds);
                rpvBaoCaoHangTon.RefreshReport();

            }
            else
            {
                MessageBox.Show("không tìm thấy");
            }


        }
    }
}
