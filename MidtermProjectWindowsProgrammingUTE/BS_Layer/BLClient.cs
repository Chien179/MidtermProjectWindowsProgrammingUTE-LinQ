using System.Data;
using System.Data.Linq;

namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLClient
    {
        public Table<KhachHang> GetClient()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.KhachHangs;
        }
        public bool AddClient(string CMND, string TenKhachHang, string DiaChi, string SoDienThoai, string GioiTinh,string NgaySinh, ref string err)
        {
            return true;
        }

        public bool UpdateClient(string CMND, string TenKhachHang, string DiaChi, string SoDienThoai, string GioiTinh, string NgaySinh, ref string err)
        {
            return true;
        }

        public bool DeleteClient(ref string err, string CMND)
        {
            return true;
        }

       
    }
}
