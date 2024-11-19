using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using BLL;
using PUBLIC;
namespace Interface
{
    public partial class QLSV : Form
    {
        public QLSV()
        {
            InitializeComponent();
        }
        LOAD_DL load = new LOAD_DL();
        private void TreeView_Load(object sender, EventArgs e)
        {           
            hienthitreeview();          
            dg_luoi.ReadOnly = true;         
        }
        public void reload_treeview()
        {
            TW.Nodes.Clear();
            hienthitreeview();           
        }      
        private bool KHOA_MNS = false, SINHVIEN_MNS = false, LOP_MNS = false;       
        private void hienthitreeview()
        {
           
            DataTable nut_cha = new System.Data.DataTable();
            DataTable nut_con = new System.Data.DataTable();
            nut_cha = load.laydulieu_treeview("SELECT MAKHOA,TENKHOA FROM KHOA");
            TreeNode khoa = new TreeNode("Thông Tin Các Khoa");          
            TreeNode THONGTINKHAC = new TreeNode("Thông Tin Khác");
            THONGTINKHAC.Nodes.Add("Phan Trần Thảo Duy");
            THONGTINKHAC.Nodes[0].Nodes.Add("Môn: Lập Trình Cơ Sở Dữ Liệu.");
            for (int i = 0; i < nut_cha.Rows.Count; i++)
            {
                khoa.Nodes.Add(nut_cha.Rows[i][0].ToString(),"Khoa: "+ nut_cha.Rows[i][1].ToString());               
                khoa.Nodes[i].Tag = "1";
                
                nut_con = load.laydulieu_treeview("SELECT MALOP,TENLOP FROM LOP WHERE MAKHOA='" + nut_cha.Rows[i][0].ToString() + "'");
                for (int j = 0; j < nut_con.Rows.Count; j++)
                {
                    khoa.Nodes[i].Nodes.Add(nut_con.Rows[j][0].ToString(),"Lớp: "+ nut_con.Rows[j][1].ToString());
                    khoa.Nodes[i].Nodes[j].Tag = "2";
                }
            }
            TW.Nodes.Add(khoa);
            TW.Nodes.Add(THONGTINKHAC);          
        }
        private bool tag1 = false, tag2 = false;
        string matag1, matag2;
        private void TW_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.TW.SelectedNode;
            if (e.Node.Text == "Thông Tin Các Khoa")
            {
                string sql = ("SELECT SINHVIEN.MASV AS MãSinhViên,SINHVIEN.TENSV AS TênSinhViên,SINHVIEN.GIOITINH AS GiớiTính,SINHVIEN.NGAYSINH AS NgàySinh,SINHVIEN.DIACHI AS ĐịaChỉ,SINHVIEN.MALOP AS MãLớp,KHOA.MAKHOA AS MãKhoa FROM SINHVIEN INNER JOIN LOP ON SINHVIEN.MALOP=LOP.MALOP INNER JOIN KHOA ON KHOA.MAKHOA=LOP.MAKHOA");
                dg_luoi.DataSource = load.laydulieu_treeview(sql);
            }                     
            if (node.Tag == "1")
            {
                
                if (KHOA_MNS == true)
                {
                    sv.Owner = this;
                    KHOA_MNS = false;
                    khoa.Hide();
                    sv.TopLevel = false;
                    groupBox_cn.Controls.Add(sv);
                    sv.FormBorderStyle = FormBorderStyle.None;
                    sv.WindowState = FormWindowState.Maximized;
                    dg_luoi.DataSource = sv_bll.load_sv();
                    sv.masv = masv;
                    sv.tensv = tensv;
                    sv.gioitinh = gioitinh;
                    sv.malop = malop_sv;
                    sv.diachi = diachi;
                    sv.ngaysinh = ngaysinh;
                   // sv.Show();
                }
                else if (LOP_MNS == true)
                {
                    sv.Owner = this;
                    LOP_MNS = false;
                    lop.Hide();
                    sv.TopLevel = false;
                    groupBox_cn.Controls.Add(sv);
                    sv.FormBorderStyle = FormBorderStyle.None;
                    sv.WindowState = FormWindowState.Maximized;
                    dg_luoi.DataSource = sv_bll.load_sv();
                    sv.masv = masv;
                    sv.tensv = tensv;
                    sv.gioitinh = gioitinh;
                    sv.malop = malop_sv;
                    sv.diachi = diachi;
                    sv.ngaysinh = ngaysinh;
                   // sv.Show();
                }
                else
                {
                    sv.Owner = this;
                    sv.TopLevel = false;
                    groupBox_cn.Controls.Add(sv);
                    sv.FormBorderStyle = FormBorderStyle.None;
                    sv.WindowState = FormWindowState.Maximized;                
                    dg_luoi.DataSource = sv_bll.load_sv();
                    sv.masv = masv;
                    sv.tensv = tensv;
                    sv.gioitinh = gioitinh;
                    sv.malop = malop_sv;
                    sv.diachi = diachi;
                    sv.ngaysinh = ngaysinh;
                  //  sv.Show();

                }
                string sql = ("SELECT SINHVIEN.MASV AS MãSinhViên,SINHVIEN.TENSV AS TênSinhViên,SINHVIEN.GIOITINH AS GiớiTính,SINHVIEN.NGAYSINH AS NgàySinh,SINHVIEN.DIACHI AS ĐịaChỉ,SINHVIEN.MALOP AS MãLớp ,KHOA.MAKHOA AS MãKhoa FROM SINHVIEN INNER JOIN LOP ON SINHVIEN.MALOP=LOP.MALOP INNER JOIN KHOA ON KHOA.MAKHOA=LOP.MAKHOA WHERE KHOA.MAKHOA='"+node.Name+"'");
                tag1 = true;
                tag2 = false;
                matag1 = node.Name;
                dg_luoi.DataSource = load.laydulieu_treeview(sql);              
            }
            else if (node.Tag == "2")
            {
                if (KHOA_MNS == true)
                {
                    sv.Owner = this;
                    KHOA_MNS = false;
                    khoa.Hide();
                    sv.TopLevel = false;
                    groupBox_cn.Controls.Add(sv);
                    sv.FormBorderStyle = FormBorderStyle.None;
                    sv.WindowState = FormWindowState.Maximized;                    
                    dg_luoi.DataSource = sv_bll.load_sv();
                    sv.masv = masv;
                    sv.tensv = tensv;
                    sv.gioitinh = gioitinh;
                    sv.malop = malop_sv;
                    sv.diachi = diachi;
                    sv.ngaysinh = ngaysinh;
                   // sv.Show();
                }
                else if (LOP_MNS == true)
                {
                    sv.Owner = this;
                    LOP_MNS = false;
                    lop.Hide();
                    sv.TopLevel = false;
                    groupBox_cn.Controls.Add(sv);
                    sv.FormBorderStyle = FormBorderStyle.None;
                    sv.WindowState = FormWindowState.Maximized;                
                    dg_luoi.DataSource = sv_bll.load_sv();
                    sv.masv = masv;
                    sv.tensv = tensv;
                    sv.gioitinh = gioitinh;
                    sv.malop = malop_sv;
                    sv.diachi = diachi;
                    sv.ngaysinh = ngaysinh;
                   // sv.Show();
                }
                else
                {
                    sv.Owner = this;
                    sv.TopLevel = false;
                    groupBox_cn.Controls.Add(sv);
                    sv.FormBorderStyle = FormBorderStyle.None;
                    sv.WindowState = FormWindowState.Maximized;                 
                    dg_luoi.DataSource = sv_bll.load_sv();
                    sv.masv = masv;
                    sv.tensv = tensv;
                    sv.gioitinh = gioitinh;
                    sv.malop = malop_sv;
                    sv.diachi = diachi;
                    sv.ngaysinh = ngaysinh;
                   // sv.Show();

                }
                string sql = ("SELECT SINHVIEN.MASV AS MãSinhViên,SINHVIEN.TENSV AS TênSinhViên,SINHVIEN.GIOITINH AS GiớiTính,SINHVIEN.NGAYSINH AS NgàySinh,SINHVIEN.DIACHI AS ĐịaChỉ,SINHVIEN.MALOP AS MãLớp FROM SINHVIEN INNER JOIN LOP ON SINHVIEN.MALOP=LOP.MALOP INNER JOIN KHOA ON KHOA.MAKHOA=LOP.MAKHOA WHERE LOP.MALOP='" + node.Name + "'");
                tag2 = true;
                tag1 = false;
                matag2 = node.Name;
                dg_luoi.DataSource = load.laydulieu_treeview(sql);                        
            }          
        }
        public void reload_luoi()
        {
            if (SINHVIEN_MNS == true)
            {               
                this.dg_luoi.DataSource = sv_bll.load_sv();
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                sv.masvcu = masvcu;
            }
            else if (LOP_MNS == true)
            {              
                this.dg_luoi.DataSource = lop_bll.load_lop();
                lop.malop = malop_lop;
                lop.tenlop = tenlop;
                lop.makhoa = makhoa_lop;
                lop.malopcu = malopcu;
            }
            else if (KHOA_MNS == true)
            {              
                this.dg_luoi.DataSource = khoa_bll.load_khoa();
                khoa.makhoa = makhoa_khoa;
                khoa.tenkhoa = tenkhoa;
                khoa.makhoacu = makhoacu;
            }
            else if (tag1 == true)
            {               
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                this.dg_luoi.DataSource = sv_bll.load_sv();
               // this.dg_luoi.DataSource = load.laydulieu_treeview("SELECT SINHVIEN.MASV AS MãSinhViên,SINHVIEN.TENSV AS TênSinhViên,SINHVIEN.GIOITINH AS GiớiTính,SINHVIEN.NGAYSINH AS NgàySinh,SINHVIEN.DIACHI AS ĐịaChỉ,SINHVIEN.MALOP AS MãLớp ,KHOA.MAKHOA AS MãKhoa FROM SINHVIEN INNER JOIN LOP ON SINHVIEN.MALOP=LOP.MALOP INNER JOIN KHOA ON KHOA.MAKHOA=LOP.MAKHOA WHERE KHOA.MAKHOA='" + matag1 + "'");
                sv.Hide();
            }
            else if (tag2 == true)
            {               
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                this.dg_luoi.DataSource = sv_bll.load_sv();
               // this.dg_luoi.DataSource = load.laydulieu_treeview("SELECT SINHVIEN.MASV AS MãSinhViên,SINHVIEN.TENSV AS TênSinhViên,SINHVIEN.GIOITINH AS GiớiTính,SINHVIEN.NGAYSINH AS NgàySinh,SINHVIEN.DIACHI AS ĐịaChỉ,SINHVIEN.MALOP AS MãLớp FROM SINHVIEN INNER JOIN LOP ON SINHVIEN.MALOP=LOP.MALOP INNER JOIN KHOA ON KHOA.MAKHOA=LOP.MAKHOA WHERE LOP.MALOP='" + matag2 + "'");
                sv.Hide();
            }
        }
        KHOA khoa = new KHOA();
        LOP lop = new LOP();
        SINHVIEN sv = new SINHVIEN ();      
        KHOA_BLL khoa_bll = new KHOA_BLL();
        LOP_BLL lop_bll = new LOP_BLL();
        SINHVIEN_BLL sv_bll = new SINHVIEN_BLL();
        private void MNS_SINHVIEN_Click(object sender, EventArgs e)
        {           
            if (KHOA_MNS == true)
            {
                sv.Owner = this;
                KHOA_MNS = false;
                khoa.Hide();               
                sv.TopLevel = false;
                groupBox_cn.Controls.Add(sv);
                sv.FormBorderStyle = FormBorderStyle.None;
                sv.WindowState = FormWindowState.Maximized;
                SINHVIEN_MNS = true;
                dg_luoi.DataSource = sv_bll.load_sv();
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                sv.Show();              
            }
            else if (LOP_MNS == true)
            {
                sv.Owner = this;
                LOP_MNS = false;
                lop.Hide();
                sv.TopLevel = false;
                groupBox_cn.Controls.Add(sv);
                sv.FormBorderStyle = FormBorderStyle.None;
                sv.WindowState = FormWindowState.Maximized;
                SINHVIEN_MNS = true;
                dg_luoi.DataSource = sv_bll.load_sv();
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                sv.Show();               
            }
            else if (tag1 == true)
            {
                sv.Hide();
                tag1 = false;
                sv.Owner = this;
                sv.TopLevel = false;
                groupBox_cn.Controls.Add(sv);
                sv.FormBorderStyle = FormBorderStyle.None;
                sv.WindowState = FormWindowState.Maximized;
                SINHVIEN_MNS = true;
                dg_luoi.DataSource = sv_bll.load_sv();
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                sv.Show();
            }
            else if (tag2 == true)
            {
                sv.Hide();
                tag2 = false;
                sv.Owner = this;
                sv.TopLevel = false;
                groupBox_cn.Controls.Add(sv);
                sv.FormBorderStyle = FormBorderStyle.None;
                sv.WindowState = FormWindowState.Maximized;
                SINHVIEN_MNS = true;
                dg_luoi.DataSource = sv_bll.load_sv();
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                sv.Show();
            }
            else
            {
                sv.Owner = this;
                sv.TopLevel = false;
                groupBox_cn.Controls.Add(sv);
                sv.FormBorderStyle = FormBorderStyle.None;
                sv.WindowState = FormWindowState.Maximized;
                SINHVIEN_MNS = true;
                dg_luoi.DataSource = sv_bll.load_sv();
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;               
                sv.Show();
                              
            }
           
        }    
        private void MNS_KHOA_Click(object sender, EventArgs e)
        {           
            if (SINHVIEN_MNS == true)
            {
                khoa.Owner = this;
                SINHVIEN_MNS = false;
                sv.Hide();
                khoa.TopLevel = false;
                groupBox_cn.Controls.Add(khoa);
                khoa.FormBorderStyle = FormBorderStyle.None;
                khoa.WindowState = FormWindowState.Maximized;
                KHOA_MNS = true;
                dg_luoi.DataSource = khoa_bll.load_khoa();
                khoa.makhoa = makhoa_khoa;
                khoa.tenkhoa = tenkhoa;
                khoa.makhoacu = makhoacu;
                khoa.Show();
            }
            else if (LOP_MNS == true)
            {
                khoa.Owner = this;
                LOP_MNS = false;
                lop.Hide();
                khoa.TopLevel = false;
                groupBox_cn.Controls.Add(khoa);
                khoa.FormBorderStyle = FormBorderStyle.None;
                khoa.WindowState = FormWindowState.Maximized;
                KHOA_MNS = true;
                dg_luoi.DataSource = khoa_bll.load_khoa();
                khoa.makhoa = makhoa_khoa;
                khoa.tenkhoa = tenkhoa;
                khoa.makhoacu = makhoacu;
                khoa.Show();
            }
            else if (tag1 == true)
            {
                sv.Hide();
                tag1 = false;
                khoa.Owner = this;
                LOP_MNS = false;
                lop.Hide();
                khoa.TopLevel = false;
                groupBox_cn.Controls.Add(khoa);
                khoa.FormBorderStyle = FormBorderStyle.None;
                khoa.WindowState = FormWindowState.Maximized;
                KHOA_MNS = true;
                dg_luoi.DataSource = khoa_bll.load_khoa();
                khoa.makhoa = makhoa_khoa;
                khoa.tenkhoa = tenkhoa;
                khoa.makhoacu = makhoacu;
                khoa.Show();
            }
            else if (tag2 == true)
            {
                sv.Hide();
                tag2 = false;
                khoa.Owner = this;
                LOP_MNS = false;
                lop.Hide();
                khoa.TopLevel = false;
                groupBox_cn.Controls.Add(khoa);
                khoa.FormBorderStyle = FormBorderStyle.None;
                khoa.WindowState = FormWindowState.Maximized;
                KHOA_MNS = true;
                dg_luoi.DataSource = khoa_bll.load_khoa();
                khoa.makhoa = makhoa_khoa;
                khoa.tenkhoa = tenkhoa;
                khoa.makhoacu = makhoacu;
                khoa.Show();
            }
            else
            {
                khoa.Owner = this;
                khoa.TopLevel = false;
                groupBox_cn.Controls.Add(khoa);
                khoa.FormBorderStyle = FormBorderStyle.None;
                khoa.WindowState = FormWindowState.Maximized;
                KHOA_MNS = true;
                dg_luoi.DataSource = khoa_bll.load_khoa();
                khoa.makhoa = makhoa_khoa;
                khoa.tenkhoa = tenkhoa;
                khoa.makhoacu = makhoacu;
                khoa.Show();
            }
        }

        private void MNS_LOP_Click(object sender, EventArgs e)
        {           
            if (SINHVIEN_MNS == true)
            {              
                lop.Owner = this;
                SINHVIEN_MNS = false;
                sv.Hide();
                lop.TopLevel = false;
                groupBox_cn.Controls.Add(lop);
                lop.FormBorderStyle = FormBorderStyle.None;
                lop.WindowState = FormWindowState.Maximized;
                LOP_MNS = true;
                dg_luoi.DataSource = lop_bll.load_lop();
                lop.malop = malop_lop;
                lop.tenlop = tenlop;
                lop.makhoa = makhoa_lop;
                lop.malopcu = malopcu;
                lop.Show();
            }
            else if (KHOA_MNS == true)
            {              
                lop.Owner = this;
                KHOA_MNS = false;
                khoa.Hide();
                lop.TopLevel = false;
                groupBox_cn.Controls.Add(lop);
                lop.FormBorderStyle = FormBorderStyle.None;
                lop.WindowState = FormWindowState.Maximized;
                LOP_MNS = true;
                dg_luoi.DataSource = lop_bll.load_lop();
                lop.malop = malop_lop;
                lop.tenlop = tenlop;
                lop.makhoa = makhoa_lop;
                lop.malopcu = malopcu;
                lop.Show();
            }
            else if (tag1 == true)
            {
                sv.Hide();
                tag1 = false;
                lop.Owner = this;
                KHOA_MNS = false;
                khoa.Hide();
                lop.TopLevel = false;
                groupBox_cn.Controls.Add(lop);
                lop.FormBorderStyle = FormBorderStyle.None;
                lop.WindowState = FormWindowState.Maximized;
                LOP_MNS = true;
                dg_luoi.DataSource = lop_bll.load_lop();
                lop.malop = malop_lop;
                lop.tenlop = tenlop;
                lop.makhoa = makhoa_lop;
                lop.malopcu = malopcu;
                lop.Show();
            }
            else if (tag2 == true)
            {
                sv.Hide();
                tag2 = false;
                lop.Owner = this;
                KHOA_MNS = false;
                khoa.Hide();
                lop.TopLevel = false;
                groupBox_cn.Controls.Add(lop);
                lop.FormBorderStyle = FormBorderStyle.None;
                lop.WindowState = FormWindowState.Maximized;
                LOP_MNS = true;
                dg_luoi.DataSource = lop_bll.load_lop();
                lop.malop = malop_lop;
                lop.tenlop = tenlop;
                lop.makhoa = makhoa_lop;
                lop.malopcu = malopcu;
                lop.Show();
            }
            else
            {
                lop.Owner = this;
                lop.TopLevel = false;
                groupBox_cn.Controls.Add(lop);
                lop.FormBorderStyle = FormBorderStyle.None;
                lop.WindowState = FormWindowState.Maximized;
                LOP_MNS = true;
                dg_luoi.DataSource = lop_bll.load_lop();
                lop.malop = malop_lop;
                lop.tenlop = tenlop;
                lop.makhoa = makhoa_lop;
                lop.malopcu = malopcu;
                lop.Show();
            }
        }
        string masv, tensv, gioitinh, diachi, malop_sv, masvcu;
        string malop_lop, tenlop, makhoa_lop, malopcu;
        string makhoa_khoa, tenkhoa, makhoacu;            
        public DateTime ngaysinh;
        private void dg_luoi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (SINHVIEN_MNS == true)
                {
                    int dong =e.RowIndex;                   
                    masv=dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    masvcu = dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    tensv = dg_luoi.Rows[dong].Cells[1].Value.ToString();
                    gioitinh = dg_luoi.Rows[dong].Cells[2].Value.ToString();
                    ngaysinh = DateTime.Parse(dg_luoi.Rows[dong].Cells[3].Value.ToString());
                    diachi = dg_luoi.Rows[dong].Cells[4].Value.ToString();
                    malop_sv = dg_luoi.Rows[dong].Cells[5].Value.ToString();                    
                }
                else if (LOP_MNS == true)
                {
                    int dong = e.RowIndex;                   
                    malop_lop = dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    malopcu = dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    tenlop = dg_luoi.Rows[dong].Cells[1].Value.ToString();
                    makhoa_lop = dg_luoi.Rows[dong].Cells[2].Value.ToString();
                }
                else if (KHOA_MNS == true)
                {
                    int dong = e.RowIndex;
                    makhoa_khoa = dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    makhoacu = dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    tenkhoa = dg_luoi.Rows[dong].Cells[1].Value.ToString();
                }
                else if (tag1 == true)
                {
                    int dong = e.RowIndex;
                    masv = dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    masvcu = dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    tensv = dg_luoi.Rows[dong].Cells[1].Value.ToString();
                    gioitinh = dg_luoi.Rows[dong].Cells[2].Value.ToString();
                    ngaysinh = DateTime.Parse(dg_luoi.Rows[dong].Cells[3].Value.ToString());
                    diachi = dg_luoi.Rows[dong].Cells[4].Value.ToString();
                    malop_sv = dg_luoi.Rows[dong].Cells[5].Value.ToString();                    
                }
                else if (tag2 == true)
                {
                    int dong = e.RowIndex;
                    masv = dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    masvcu = dg_luoi.Rows[dong].Cells[0].Value.ToString();
                    tensv = dg_luoi.Rows[dong].Cells[1].Value.ToString();
                    gioitinh = dg_luoi.Rows[dong].Cells[2].Value.ToString();
                    ngaysinh = DateTime.Parse(dg_luoi.Rows[dong].Cells[3].Value.ToString());
                    diachi = dg_luoi.Rows[dong].Cells[4].Value.ToString();
                    malop_sv = dg_luoi.Rows[dong].Cells[5].Value.ToString();                    
                }
            }
            catch
            { }
        }

        private void dg_luoi_Click(object sender, EventArgs e)
        {
            if (SINHVIEN_MNS == true)
            {
                
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                sv.masvcu = masvcu;
                sv.SINHVIEN_Load(sender, e);            
            }
            else if (LOP_MNS == true)
            {
                lop.malop = malop_lop;
                lop.tenlop = tenlop;
                lop.makhoa = makhoa_lop;
                lop.malopcu = malopcu;
                lop.LOP_Load(sender, e);
            }
            else if (KHOA_MNS == true)
            {
                khoa.makhoa = makhoa_khoa;
                khoa.tenkhoa = tenkhoa;
                khoa.makhoacu = makhoacu;
                khoa.KHOA_Load(sender, e);
            }
            else if (tag1 == true)
            {
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                sv.masvcu = masvcu;
                sv.SINHVIEN_Load(sender, e);    
            }
            else if (tag2 == true)
            {
                sv.masv = masv;
                sv.tensv = tensv;
                sv.gioitinh = gioitinh;
                sv.malop = malop_sv;
                sv.diachi = diachi;
                sv.ngaysinh = ngaysinh;
                sv.masvcu = masvcu;
                sv.SINHVIEN_Load(sender, e);    
            }       
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeView_Load(sender, e);
        }

        private void rESETToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            reload_luoi();
        }

        private void resetToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            TW.Nodes.Clear();
            TreeView_Load(sender, e);
        }      
    }
}
