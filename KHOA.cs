using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PUBLIC;
using BLL;
namespace Interface
{
    public partial class KHOA : Form
    {
        public KHOA()
        {
            InitializeComponent();
        }
        KHOA_BLL khoa_bll = new KHOA_BLL();
        private bool Them, Sua;
        private void xuly(bool b)
        {
            btluu.Enabled = bthuy.Enabled = txtmakhoa.Enabled = txttenkhoa.Enabled = !b;
            btthem.Enabled = btsua.Enabled = btxoa.Enabled = bthoat.Enabled =  b;
        }
        public string makhoa { get; set; }
        public string tenkhoa { get; set; }
        public string makhoacu { get; set; }
        internal void KHOA_Load(object sender, EventArgs e)
        {
            xuly(true);
            txtmakhoa.Text = makhoa;
            txttenkhoa.Text = tenkhoa;
        }                                
        private void btthem_Click_1(object sender, EventArgs e)
        {
            txtmakhoa.Clear();
            txttenkhoa.Clear();
            Them = true;
            xuly(false);
        }

        private void btsua_Click_1(object sender, EventArgs e)
        {
            Sua = true;
            xuly(false);
        }

        private void btxoa_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo))
            {
                KHOA_PUBLIC khoa_public = new KHOA_PUBLIC();
                khoa_public.MAKHOAMOI = txtmakhoa.Text;
                khoa_bll.delete_khoa(khoa_public);
                QLSV qlsv = (QLSV)this.Owner;
                qlsv.reload_luoi();
                qlsv.reload_treeview();
                KHOA_Load(sender, e);
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btluu_Click_1(object sender, EventArgs e)
        {
            if (Them == true)
            {
                if (txtmakhoa.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền mã khoa.","Thông Báo",MessageBoxButtons.OK);
                }
                else if (txttenkhoa.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền tên khoa.", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        KHOA_PUBLIC khoa_public = new KHOA_PUBLIC();
                        khoa_public.MAKHOAMOI = txtmakhoa.Text;
                        khoa_public.TENKHOA = txttenkhoa.Text;
                        khoa_bll.insert_khoa(khoa_public);
                        QLSV qlsv = (QLSV)this.Owner;
                        qlsv.reload_luoi();
                        qlsv.reload_treeview();
                        KHOA_Load(sender, e);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                        xuly(true);
                        Them = false;
                    }
                    catch
                    {
                        MessageBox.Show("Mã khoa đã tồn tại.", "Thông Báo", MessageBoxButtons.OK);
                    }
                }              
            }
            else if (Sua == true)
            {
                if (txtmakhoa.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền mã khoa.", "Thông Báo", MessageBoxButtons.OK);
                }
                else if (txttenkhoa.TextLength == 0)
                {
                    MessageBox.Show("Chưa điền tên khoa.", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    try
                    {
                        KHOA_PUBLIC khoa_public = new KHOA_PUBLIC();
                        khoa_public.MAKHOAMOI = txtmakhoa.Text;
                        khoa_public.MAKHOACU = makhoacu;
                        khoa_public.TENKHOA = txttenkhoa.Text;
                        khoa_bll.update_khoa(khoa_public);
                        QLSV qlsv = (QLSV)this.Owner;
                        qlsv.reload_luoi();
                        qlsv.reload_treeview();
                        KHOA_Load(sender, e);
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                        xuly(true);
                        Sua = false;
                    }
                    catch
                    {
                        MessageBox.Show("Mã khoa đã tồn tại.", "Thông Báo", MessageBoxButtons.OK);
                    }
                }               
            }
        }

        private void bthuy_Click_1(object sender, EventArgs e)
        {
            if (Them == true)
            {
                KHOA_Load(sender, e);
                xuly(true);
                Them = false;
            }
            else if (Sua == true)
            {
                xuly(true);
                Sua = false;
            }
        }

        private void bthoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }       
    }
}
