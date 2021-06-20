using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLClient
    {
        public Table<KhachHang> GetClient()
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.KhachHangs;
        }
        public List<string> GetClientProperties()
        {
            var propertiesKH = (from kh in typeof(KhachHang).GetProperties()
                                select kh.Name);

            List<string> ProKH = propertiesKH.ToList();

            return ProKH;
        }
        public bool AddClient(string CMND, string TenKhachHang, string DiaChi, string SoDienThoai, bool GioiTinh, DateTime NgaySinh, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            KhachHang kh = new KhachHang();
            kh.CMND = CMND;
            kh.TenKH = TenKhachHang;
            kh.DiaChi = DiaChi;
            kh.SoDienThoai = SoDienThoai;
            kh.Nu = GioiTinh;
            kh.NgaySinh = NgaySinh;

            qlKS.KhachHangs.InsertOnSubmit(kh);
            qlKS.KhachHangs.Context.SubmitChanges();
            return true;
           
        }
        public bool DeleteClient(ref string err, string CMND)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();

            var khQuery = from kh in qlKS.KhachHangs
                          where kh.CMND == CMND
                          select kh;

            qlKS.KhachHangs.DeleteAllOnSubmit(khQuery);
            qlKS.SubmitChanges();
            return true;
        }

        public bool UpdateClient(string CMND, string TenKhachHang, string DiaChi, string SoDienThoai, bool GioiTinh, DateTime NgaySinh, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var khQuery = (from kh in qlKS.KhachHangs
                           where kh.CMND == CMND
                           select kh).SingleOrDefault();

            if (khQuery != null)
            {
                khQuery.CMND = CMND;
                khQuery.TenKH = TenKhachHang;
                khQuery.DiaChi = DiaChi;
                khQuery.SoDienThoai = SoDienThoai;
                khQuery.Nu = GioiTinh;
                khQuery.NgaySinh = NgaySinh;
                qlKS.SubmitChanges();
            }

            return true;
        }

        //public DataSet SearchClient(string key, int Sex)
    }
}
