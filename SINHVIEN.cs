using BLL;
using PUBLIC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Interface
{
    public partial class SINHVIEN : Form
    {
        public SINHVIEN()
        {
            InitializeComponent();
        }       
        SINHVIEN_BLL sv_bll = new SINHVIEN_BLL();
        private void xuly(bool b)
        {
            btluu.Enabled = bthuy.Enabled = txtmasv.Enabled = txttensv.Enabled = cbgioitinh.Enabled=dateNS.Enabled=txtdiachi.Enabled=cbmalop.Enabled = !b;
            btthem.Enabled = btsua.Enabled = btxoa.Enabled = bthoat.Enabled   = b;
        }
        public string masv {get;set;}
        public string tensv { get; set; }
        public string gioitinh { get; set; }
        public string diachi { get; set; }
        public string malop { get; set; }
        
        public DateTime ngaysinh { get; set; }
        public bool checkXoa { get; set; }
        public bool checkSua { get; set; }
        public bool checkThem { get; set; }
        LOP_BLL lop_bll = new LOP_BLL();
        internal void SINHVIEN_Load(object sender, EventArgs e)
        {
            xuly(true);           
            //cbgioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
           // cbmalop.DropDownStyle = ComboBoxStyle.DropDownList;               
            txtmasv.Text = masv;
            txttensv.Text = tensv;
            cbgioitinh.Text = gioitinh;
            txtdiachi.Text = diachi;
            cbmalop.Text = malop;
            //dateNS.Text = ngaysinh.ToString();           
        }
        private bool Them = false, Sua = false;
        private void btthem_Click(object sender, EventArgs e)
        {
            txtdiachi.Clear();
            txtmasv.Clear();
            txttensv.Clear();
            cbgioitinh.ResetText();
            cbmalop.ResetText();
            dateNS.ResetText();
            Them = true;
            xuly(false);
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            Sua = true;
            xuly(false);
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            if (Them == true)
            {
                if (txtmasv.TextLength == 0)
                {
                    MessageBox.Show("Mã sinh viên chưa điền.", "Thông báo", MessageBoxButtons.OK);
                }
                else if (txtdiachi.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền địa chỉ.", "Thông báo", MessageBoxButtons.OK);
                }
                else if (txttensv.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền tên sinh viên.", "Thông báo", MessageBoxButtons.OK);
                }
                else if (cbgioitinh.Text == "")
                {
                    MessageBox.Show("Chưa chọn giới tính.", "Thông báo", MessageBoxButtons.OK);
                }
                else if (cbmalop.Text == "")
                {
                    MessageBox.Show("Chưa chọn mã lớp,Nếu không có mã lớp thì lớp đó không tồn tại,cần tạo lớp.", "Thông báo", MessageBoxButtons.OK);
                }
                else if ((DateTime.Today.Year - dateNS.Value.Year) < 18)
                {
                    MessageBox.Show("Sinh viên không được nhỏ hơn 18 tuổi.", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        SINHVIEN_PUBLIC sv_public = new SINHVIEN_PUBLIC();
                        sv_public.MASV = txtmasv.Text;
                        sv_public.TENSV = txttensv.Text;
                        sv_public.GIOITINH = cbgioitinh.Text;
                        sv_public.NGAYSINH = DateTime.Parse(dateNS.Value.ToString());
                        sv_public.DIACHI = txtdiachi.Text;
                        sv_public.MALOP = cbmalop.Text;
                        sv_bll.insert_sv(sv_public);
                        SINHVIEN_Load(sender, e);
                        QLSV qlsv = (QLSV)this.Owner;
                        qlsv.reload_luoi();
                        qlsv.reload_treeview();
                        MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                        Them = false;
                        xuly(true);
                    }
                    catch
                    {
                        MessageBox.Show("Mã sinh viên bị trùng.", "Thông báo", MessageBoxButtons.OK);
                    }
                }              
            }
            else if (Sua == true)
            {
                if (txtmasv.TextLength == 0)
                {
                    MessageBox.Show("Mã sinh viên chưa điền.", "Thông báo", MessageBoxButtons.OK);
                }
                else if (txtdiachi.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền địa chỉ.", "Thông báo", MessageBoxButtons.OK);
                }
                else if (txttensv.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền tên sinh viên.", "Thông báo", MessageBoxButtons.OK);
                }
                else if (cbgioitinh.Text == "")
                {
                    MessageBox.Show("Chưa chọn giới tính.", "Thông báo", MessageBoxButtons.OK);
                }
                else if (cbmalop.Text == "")
                {
                    MessageBox.Show("Chưa chọn mã lớp,Nếu không có mã lớp thì lớp đó không tồn tại,cần tạo lớp.", "Thông báo", MessageBoxButtons.OK);
                }
                else if ((DateTime.Today.Year - dateNS.Value.Year) < 18)
                {
                    MessageBox.Show("Sinh viên không được nhỏ hơn 18 tuổi.", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        SINHVIEN_PUBLIC sv_public = new SINHVIEN_PUBLIC();
                        sv_public.MASV = txtmasv.Text;
                        sv_public.TENSV = txttensv.Text;
                        sv_public.GIOITINH = cbgioitinh.Text;
                        sv_public.NGAYSINH = DateTime.Parse(dateNS.Value.ToString());
                        sv_public.DIACHI = txtdiachi.Text;
                        sv_public.MALOP = cbmalop.Text;
                        sv_public.MASVCU = masvcu;
                        sv_bll.update_sv(sv_public);
                        SINHVIEN_Load(sender, e);
                        QLSV qlsv = (QLSV)this.Owner;
                        qlsv.reload_luoi();
                        qlsv.reload_treeview();
                        MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK);
                        Sua = false;
                        xuly(true);
                    }
                    catch
                    {
                        MessageBox.Show("Mã sinh viên đã tồn tại.", "Thông báo", MessageBoxButtons.OK);
                    }
                }              
            }
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            if (Them == true)
            {
                SINHVIEN_Load(sender, e);
                Them = false;
                xuly(true);
            }
            else if (Sua == true)
            {
                Sua = false;
                xuly(true);
            }
        }
        public string masvcu{get; set;}       

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo))
            {
                if (txtmasv.TextLength == 0)
                {
                    MessageBox.Show("Thông tin trống. mời chọn trong danh sách rồi mới xóa?", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    SINHVIEN_PUBLIC sv_public = new SINHVIEN_PUBLIC();
                    sv_public.MASV = txtmasv.Text;
                    sv_bll.delete_sv(sv_public);
                    SINHVIEN_Load(sender, e);
                    QLSV qlsv = (QLSV)this.Owner;
                    qlsv.reload_luoi();
                    qlsv.reload_treeview();
                    MessageBox.Show("Xóa thánh công", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void cbmalop_Click(object sender, EventArgs e)
        {
            cbmalop.DataSource = lop_bll.load_lop();
            cbmalop.DisplayMember = "MãLớp";
        }

        private void bthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btreset_Click(object sender, EventArgs e)
        {
            SINHVIEN_Load(sender, e);
            MessageBox.Show(tensv);
        }              
    }
}
