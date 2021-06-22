using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System;



namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLStaff
    {
        public Table<NhanVien> GetStaff()
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.NhanViens;
        }
        //public DataSet GetPosAndNameStaff(string IDStaff)
        public List<string> GetStaffProperties()
        {
            var propertiesNV = (from nv in typeof(NhanVien).GetProperties()
                                select nv.Name);

            List<string> ProNV = propertiesNV.ToList();

            return ProNV;
        }

        public bool AddStaff(string MaNV, string TenNV, string ChucVu, DateTime NamSinh, bool GioiTinh, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;
            nv.TenNV = TenNV;
            nv.ChucVu = ChucVu;
  
            nv.NamSinh = NamSinh;
            nv.Nu = GioiTinh;

            qlKS.NhanViens.InsertOnSubmit(nv);
            qlKS.NhanViens.Context.SubmitChanges();
            return true;

        }
        public bool DeleteStaff(ref string err, string MaNV)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();

            var nvQuery = from nv in qlKS.NhanViens
                          where nv.MaNV == MaNV
                          select nv;

            qlKS.NhanViens.DeleteAllOnSubmit(nvQuery);
            qlKS.SubmitChanges();
            return true;
        }

        public bool UpdateStaff(string MaNV, string TenNV, string ChucVu, DateTime NamSinh, bool GioiTinh, ref string err)
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
                nvQuery.NamSinh = NamSinh;
                nvQuery.Nu = GioiTinh;
                qlKS.SubmitChanges();
            }

            return true;
        }
        // public DataSet SearchStaff(string key, int Sex)
    }
}
