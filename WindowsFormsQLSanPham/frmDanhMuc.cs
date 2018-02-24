using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsQLSanPham
{
    public partial class frmDanhMuc : Form
    {
        //Biến kiểm tra có thay đổi trong màn hình DM hay không
        public static bool CoThayDoi = false;
        public frmDanhMuc()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(CoThayDoi == true)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDM.Text == "" || txtTenDM.Text == "")
            {
                MessageBox.Show("Mã DM và Tên DM không được để trống","",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                DanhMuc dm = new DanhMuc();
                dm.MaDM = txtMaDM.Text;
                dm.TenDM = txtTenDM.Text;
                frmSanPham.danhSachDM.Add(dm);
                HienThiDanhMucLenListBox();
                txtMaDM.Text = "";
                txtTenDM.Text = "";
                txtMaDM.Focus();
                CoThayDoi = true;
            }
        }
        void HienThiDanhMucLenListBox()
        {
            lstDanhMục.Items.Clear();
            foreach(DanhMuc dm in frmSanPham.danhSachDM)
            {
                lstDanhMục.Items.Add(dm);
            }
        }

        private void lstDanhMục_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstDanhMục.SelectedIndex != -1)
            {
                DanhMuc dm = lstDanhMục.SelectedItem as DanhMuc;
                txtMaDM.Text = dm.MaDM;
                txtTenDM.Text = dm.TenDM;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstDanhMục.SelectedIndex != -1)
            {
                DanhMuc dm = lstDanhMục.SelectedItem as DanhMuc;
                lstDanhMục.Items.Remove(dm);
                txtMaDM.Text = "";
                txtTenDM.Text = "";
                CoThayDoi = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmDanhMuc_Load(object sender, EventArgs e)
        {
            HienThiDanhMucLenListBox();
        }
    }
}
