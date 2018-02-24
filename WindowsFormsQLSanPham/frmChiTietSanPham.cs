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
    public partial class frmChiTietSanPham : Form
    {
        public frmChiTietSanPham()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmChiTietSanPham_Load(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            lblCTDanhMucSP.Text = sp.Nhom.TenDM;
            lblCTMaSP.Text = sp.MaSP;
            lblCTTenSP.Text = sp.TenSP;
            lblCTDonGiaSP.Text = sp.DonGia + "";
            lblCTXuatXuSP.Text = sp.XuatXu;
        }
    }
}
