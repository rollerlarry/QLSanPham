using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsQLSanPham
{
    public class DanhMuc
    {
        //Một DM có nhiều sản phẩm
        private Dictionary<string, SanPham> dsSP = new Dictionary<string, SanPham>();
        public string MaDM { get; set; }
        public string TenDM { get; set; }

        //Tạo hàm đưa SP vào DM
        public void ThemSanPham(SanPham sp)
        {
            //Kiểm tra nó tồn tại hay không
            if (this.dsSP.ContainsKey(sp.MaSP) == false)
            {
                this.dsSP.Add(sp.MaSP, sp);
                //Tham chiếu nhóm sản phẩm
                sp.Nhom = this;
            }
        }
        //Trả về DS SP
        public Dictionary<string,SanPham> Sanphams
        {
            get { return this.dsSP; }
            set { this.dsSP = value; }
        }
        public override string ToString()
        {
            return this.TenDM;
        }

    }
}
