namespace Interface
{
    partial class QLSV
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TW = new System.Windows.Forms.TreeView();
            this.dg_luoi = new System.Windows.Forms.DataGridView();
            this.groupBox_cn = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MNS_KHOA = new System.Windows.Forms.ToolStripMenuItem();
            this.MNS_LOP = new System.Windows.Forms.ToolStripMenuItem();
            this.MNS_SINHVIEN = new System.Windows.Forms.ToolStripMenuItem();
            this.lbtrangthai = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_luoi)).BeginInit();
            this.groupBox_cn.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.84401F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.156F));
            this.tableLayoutPanel1.Controls.Add(this.TW, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dg_luoi, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 304F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 304);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TW
            // 
            this.TW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TW.Location = new System.Drawing.Point(3, 3);
            this.TW.Name = "TW";
            this.TW.Size = new System.Drawing.Size(252, 298);
            this.TW.TabIndex = 0;
            this.TW.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TW_AfterSelect);
            // 
            // dg_luoi
            // 
            this.dg_luoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg_luoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_luoi.Location = new System.Drawing.Point(261, 3);
            this.dg_luoi.Name = "dg_luoi";
            this.dg_luoi.Size = new System.Drawing.Size(736, 298);
            this.dg_luoi.TabIndex = 1;
            this.dg_luoi.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_luoi_RowEnter);
            this.dg_luoi.Click += new System.EventHandler(this.dg_luoi_Click);
            // 
            // groupBox_cn
            // 
            this.groupBox_cn.Controls.Add(this.lbtrangthai);
            this.groupBox_cn.Location = new System.Drawing.Point(3, 337);
            this.groupBox_cn.Name = "groupBox_cn";
            this.groupBox_cn.Size = new System.Drawing.Size(997, 141);
            this.groupBox_cn.TabIndex = 1;
            this.groupBox_cn.TabStop = false;
            this.groupBox_cn.Text = ".";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNS_KHOA,
            this.MNS_LOP,
            this.MNS_SINHVIEN});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1005, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MNS_KHOA
            // 
            this.MNS_KHOA.Image = global::Interface.Properties.Resources._1478293810_Add;
            this.MNS_KHOA.Name = "MNS_KHOA";
            this.MNS_KHOA.Size = new System.Drawing.Size(62, 20);
            this.MNS_KHOA.Text = "Khoa";
            this.MNS_KHOA.Click += new System.EventHandler(this.MNS_KHOA_Click);
            // 
            // MNS_LOP
            // 
            this.MNS_LOP.Image = global::Interface.Properties.Resources._1478293810_Add;
            this.MNS_LOP.Name = "MNS_LOP";
            this.MNS_LOP.Size = new System.Drawing.Size(55, 20);
            this.MNS_LOP.Text = "Lớp";
            this.MNS_LOP.Click += new System.EventHandler(this.MNS_LOP_Click);
            // 
            // MNS_SINHVIEN
            // 
            this.MNS_SINHVIEN.Image = global::Interface.Properties.Resources._1478293810_Add;
            this.MNS_SINHVIEN.Name = "MNS_SINHVIEN";
            this.MNS_SINHVIEN.Size = new System.Drawing.Size(84, 20);
            this.MNS_SINHVIEN.Text = "Sinh Viên";
            this.MNS_SINHVIEN.Click += new System.EventHandler(this.MNS_SINHVIEN_Click);
            // 
            // lbtrangthai
            // 
            this.lbtrangthai.AutoSize = true;
            this.lbtrangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbtrangthai.Location = new System.Drawing.Point(9, 16);
            this.lbtrangthai.Name = "lbtrangthai";
            this.lbtrangthai.Size = new System.Drawing.Size(12, 16);
            this.lbtrangthai.TabIndex = 0;
            this.lbtrangthai.Text = ".";
            // 
            // QLSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 483);
            this.Controls.Add(this.groupBox_cn);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "QLSV";
            this.Text = "Quản Lý Sinh Viên";
            this.Load += new System.EventHandler(this.TreeView_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_luoi)).EndInit();
            this.groupBox_cn.ResumeLayout(false);
            this.groupBox_cn.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView TW;
        private System.Windows.Forms.DataGridView dg_luoi;
        private System.Windows.Forms.GroupBox groupBox_cn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MNS_KHOA;
        private System.Windows.Forms.ToolStripMenuItem MNS_LOP;
        private System.Windows.Forms.ToolStripMenuItem MNS_SINHVIEN;
        private System.Windows.Forms.Label lbtrangthai;
    }
}