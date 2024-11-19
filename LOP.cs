using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using PUBLIC;
namespace Interface
{
    public partial class LOP : Form
    {
        public LOP()
        {
            InitializeComponent();
        }
        LOP_BLL lop_bll = new LOP_BLL();
        private void xuly(bool b)
        {
            btluu.Enabled = bthuy.Enabled = txtmalop.Enabled = txttenlop.Enabled=cbmakhoa.Enabled = !b;
            btthem.Enabled = btsua.Enabled = btxoa.Enabled = bthoat.Enabled   = b;
        }
        private bool Them=false, Sua=false;
       
        internal void LOP_Load(object sender, EventArgs e)
        {
            xuly(true);
            txtmalop.Text = malop;
            txttenlop.Text = tenlop;
            cbmakhoa.Text = makhoa;
        }
        public string malop { get; set; }
        public string tenlop { get; set; }
        public string makhoa { get; set; }
        public string malopcu { get; set; }
        private void btthem_Click(object sender, EventArgs e)
        {
            txtmalop.Clear();
            txttenlop.Clear();
            cbmakhoa.ResetText();
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
                if (txtmalop.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền mã lớp.", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (txttenlop.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền tên lớp.", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (cbmakhoa.Text == "")
                {
                    MessageBox.Show("Chưa chọn mã khoa,nếu không có mã khoa , cần tạo mã khoa trước.", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        LOP_PUBLIC lop_public = new LOP_PUBLIC();
                        lop_public.MALOP = txtmalop.Text;
                        lop_public.TENLOP = txttenlop.Text;
                        lop_public.MAKHOA = cbmakhoa.Text;
                        lop_bll.insert_lop(lop_public);
                        QLSV qlsv = (QLSV)this.Owner;
                        qlsv.reload_luoi();
                        qlsv.reload_treeview();
                        LOP_Load(sender, e);
                        MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                        Them = false;
                        xuly(true);
                    }
                    catch
                    {
                        MessageBox.Show("Mã lớp bị trùng.", "Thông Báo", MessageBoxButtons.OK);
                    }
                }               
            }
            else if (Sua == true)
            {
                if (txtmalop.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền mã lớp.", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (txttenlop.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền tên lớp.", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (cbmakhoa.Text == "")
                {
                    MessageBox.Show("Chưa chọn mã khoa,nếu không có mã khoa , cần tạo mã khoa trước.", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        LOP_PUBLIC lop_public = new LOP_PUBLIC();
                        lop_public.MALOP = txtmalop.Text;
                        lop_public.TENLOP = txttenlop.Text;
                        lop_public.MAKHOA = cbmakhoa.Text;
                        lop_public.MALOPCU = malopcu;
                        lop_bll.update_lop(lop_public);
                        QLSV qlsv = (QLSV)this.Owner;
                        qlsv.reload_luoi();
                        qlsv.reload_treeview();
                        LOP_Load(sender, e);
                        MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK);
                        Sua = false;
                        xuly(true);
                    }
                    catch
                    {
                        MessageBox.Show("Mã khoa đã tồn tại.", "Thông Báo", MessageBoxButtons.OK);
                    }
                }               
            }
        }

        private void bthuy_Click(object sender, EventArgs e)
        {
            if (Them == true)
            {
                LOP_Load(sender, e);
                Them = false;
                xuly(true);
            }
            else if (Sua == true)
            {              
                xuly(true);
                Sua = false;
            }
        }

        private void cbmakhoa_Click(object sender, EventArgs e)
        {
            KHOA_BLL khoa_bll = new KHOA_BLL();
            cbmakhoa.DataSource = khoa_bll.load_khoa();
            cbmakhoa.DisplayMember = "MãKhoa";
        }       
        private void bthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa?","Thông báo", MessageBoxButtons.YesNo))
            {
                LOP_PUBLIC lop_public = new LOP_PUBLIC();
                lop_public.MALOP = txtmalop.Text;
                lop_bll.delete_lop(lop_public);
                QLSV qlsv = (QLSV)this.Owner;
                qlsv.reload_luoi();
                qlsv.reload_treeview();
                LOP_Load(sender, e);
                MessageBox.Show("Xóa thành công","Thông Báo",MessageBoxButtons.OK);
            }
        }
    }
}
