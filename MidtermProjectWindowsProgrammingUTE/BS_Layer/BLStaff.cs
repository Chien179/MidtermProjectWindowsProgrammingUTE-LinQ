using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;


namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLStaff
    {
        public System.Data.Linq.Table<NhanVien> GetStaff()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.NhanViens;
        }
        public bool AddStaff(string MaNV, string TenNV,string ChucVu,string NamSinh,string GioiTinh, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;
            nv.TenNV = TenNV;
            nv.ChucVu = ChucVu;
            //nv.NamSinh = NamSinh;
            //nv.Nu = GioiTinh;
            qlKS.NhanViens.InsertOnSubmit(nv);
            qlKS.NhanViens.Context.SubmitChanges();
            return true;
        }
        public bool UpdateStaff(string MaNV, string TenNV, string ChucVu, string NamSinh, string GioiTinh, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var nvQuery = (from nv in qlKS.NhanViens
                           where nv.MaNV == MaNV
                           select nv).SingleOrDefault();

            if (nvQuery != null)
            {
                nvQuery.MaNV = MaNV;
                nvQuery.TenNV = TenNV;
                nvQuery.ChucVu = ChucVu;
                //nvQuery.NamSinh = NamSinh;
                //nvQuery.Nu = GioiTinh;
                qlKS.SubmitChanges();
            }
            return true;
        }
    }
}
