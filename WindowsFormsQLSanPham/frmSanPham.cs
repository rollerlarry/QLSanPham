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
    public partial class frmSanPham : Form
    {
        //Khai báo DS DM sử dụng chung 2 giao diện từ giao diện chính đẩy sang giao diện thêm DM
        public static List<DanhMuc> danhSachDM = new List<DanhMuc>();
        List<SanPham> danhSachSP = new List<SanPham>();
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            frmDanhMuc frmDM = new frmDanhMuc();
            frmDanhMuc.CoThayDoi = false;
            if (frmDM.ShowDialog() == DialogResult.OK)
            {
                HienThiDanhMucLenComboBox();
            }
        }
        private void ThemDanhMuc(DanhMuc dm)
        {
            
        }
        private void HienThiDanhMucLenComboBox()
        {
            cboDanhMuc.Items.Clear();
            foreach (DanhMuc dm in danhSachDM)
                cboDanhMuc.Items.Add(dm);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(cboDanhMuc.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn phải chọn Danh Mục cho sản phẩm", "Nhắc nhở", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DanhMuc dm = cboDanhMuc.SelectedItem as DanhMuc;
            SanPham sp = new SanPham();
            sp.MaSP = txtTenSP.Text;
            sp.TenSP = txtTenSP.Text;
            sp.DonGia = double.Parse(txtDonGia.Text);
            sp.XuatXu = txtXuatXu.Text;
            sp.HanDung = dtpHanDung.Value;
            //Đẩy sản phẩm vào DM
            dm.ThemSanPham(sp);
            danhSachSP.Add(sp);
            HienThiSanPhamLenListbox();
            XoaTrangLucThem();

        }
        void XoaTrangLucThem()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            txtXuatXu.Text = "";
            txtMaSP.Focus();
        }
        void HienThiSanPhamLenListbox()
        {
            lstSanPham.Items.Clear();
            foreach(SanPham sp in danhSachSP)
            {
                lstSanPham.Items.Add(sp);
            }
        }

        private void lstSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstSanPham.SelectedIndex == -1)
                return;
                SanPham sp = lstSanPham.SelectedItem as SanPham;
                cboDanhMuc.Text = sp.Nhom.TenDM;
                txtMaSP.Text = sp.MaSP;
                txtTenSP.Text = sp.TenSP;
                txtDonGia.Text = sp.DonGia+"";
                txtXuatXu.Text = sp.XuatXu;
                dtpHanDung.Value = sp.HanDung;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(lstSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Hãy chọn sản phẩm muốn xóa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SanPham sp = lstSanPham.SelectedItem as SanPham;
            DialogResult ret = MessageBox.Show("Muốn xóa [" + sp.TenSP + "] phải không ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(ret == DialogResult.Yes)
            {
                danhSachSP.Remove(sp);
                HienThiSanPhamLenListbox();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            frmChiTietSanPham frmCTSP = new frmChiTietSanPham();
            frmCTSP.ShowDialog();
            
        }
    }
}
