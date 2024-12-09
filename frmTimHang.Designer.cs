namespace quanlybanhang
{
    partial class frmTimHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this._quanlybanhangc_DataSet1 = new quanlybanhang._quanlybanhangc_DataSet();
            this.panel2 = new System.Windows.Forms.Panel();
            this._quanlybanhangc_DataSet2 = new quanlybanhang._quanlybanhangc_DataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaChatLieu = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this._quanlybanhangc_DataSet3 = new quanlybanhang._quanlybanhangc_DataSet();
            this.dgvTImKiemHang = new System.Windows.Forms.DataGridView();
            this.label24 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._quanlybanhangc_DataSet1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._quanlybanhangc_DataSet2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._quanlybanhangc_DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTImKiemHang)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnDong);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 963);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1620, 160);
            this.panel1.TabIndex = 1;
            // 
            // _quanlybanhangc_DataSet1
            // 
            this._quanlybanhangc_DataSet1.DataSetName = "_quanlybanhangc_DataSet";
            this._quanlybanhangc_DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMaChatLieu);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtTenHang);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMaHang);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1620, 271);
            this.panel2.TabIndex = 2;
            // 
            // _quanlybanhangc_DataSet2
            // 
            this._quanlybanhangc_DataSet2.DataSetName = "_quanlybanhangc_DataSet";
            this._quanlybanhangc_DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(786, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mã chất liệu";
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(328, 135);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(258, 31);
            this.txtTenHang.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(148, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tên hàng";
            // 
            // txtMaHang
            // 
            this.txtMaHang.Location = new System.Drawing.Point(328, 78);
            this.txtMaHang.Name = "txtMaHang";
            this.txtMaHang.Size = new System.Drawing.Size(258, 31);
            this.txtMaHang.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(148, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã hàng";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(628, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 42);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tìm hàng ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaChatLieu
            // 
            this.txtMaChatLieu.Location = new System.Drawing.Point(967, 81);
            this.txtMaChatLieu.Name = "txtMaChatLieu";
            this.txtMaChatLieu.Size = new System.Drawing.Size(258, 31);
            this.txtMaChatLieu.TabIndex = 14;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label24);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 898);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1620, 65);
            this.panel3.TabIndex = 3;
            // 
            // _quanlybanhangc_DataSet3
            // 
            this._quanlybanhangc_DataSet3.DataSetName = "_quanlybanhangc_DataSet";
            this._quanlybanhangc_DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvTImKiemHang
            // 
            this.dgvTImKiemHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTImKiemHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTImKiemHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTImKiemHang.Location = new System.Drawing.Point(0, 271);
            this.dgvTImKiemHang.Name = "dgvTImKiemHang";
            this.dgvTImKiemHang.RowHeadersWidth = 82;
            this.dgvTImKiemHang.RowTemplate.Height = 33;
            this.dgvTImKiemHang.Size = new System.Drawing.Size(1620, 627);
            this.dgvTImKiemHang.TabIndex = 4;
            this.dgvTImKiemHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvTImKiemHang.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTImKiemHang_CellMouseDoubleClick);
            this.dgvTImKiemHang.DoubleClick += new System.EventHandler(this.dgvTImKiemHang_DoubleClick);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.Red;
            this.label24.Location = new System.Drawing.Point(12, 15);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(434, 25);
            this.label24.TabIndex = 2;
            this.label24.Text = "Nháy đúp một dòng để hiện thông tin chi tiết";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(705, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(211, 53);
            this.button1.TabIndex = 5;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.ForeColor = System.Drawing.Color.Blue;
            this.btnTimKiem.Image = global::quanlybanhang.Properties.Resources.search1;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(342, 56);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(211, 53);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Image = global::quanlybanhang.Properties.Resources.repair;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(705, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(211, 53);
            this.button2.TabIndex = 6;
            this.button2.Text = "Tìm lại";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.ForeColor = System.Drawing.Color.Blue;
            this.btnDong.Image = global::quanlybanhang.Properties.Resources.logout;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(1069, 56);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(211, 53);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmTimHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 1123);
            this.Controls.Add(this.dgvTImKiemHang);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmTimHang";
            this.Text = "frmTimHang";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._quanlybanhangc_DataSet1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._quanlybanhangc_DataSet2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._quanlybanhangc_DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTImKiemHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private _quanlybanhangc_DataSet _quanlybanhangc_DataSet1;
        private System.Windows.Forms.Panel panel2;
        private _quanlybanhangc_DataSet _quanlybanhangc_DataSet2;
        public System.Windows.Forms.TextBox txtMaChatLieu;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtMaHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private _quanlybanhangc_DataSet _quanlybanhangc_DataSet3;
        private System.Windows.Forms.DataGridView dgvTImKiemHang;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}