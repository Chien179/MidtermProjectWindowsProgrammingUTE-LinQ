using System.Data;
using System.Data.Linq;
using System;
using System.Linq;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLPurchase
    {
        public Table<ThanhToan> GetPurchase()
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.ThanhToans;
        }

        public bool AddPurchase(string MaTT, decimal ThanhTien,DateTime NgayThanhToan, string MaPhong, string MaNV, bool TrangThai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            ThanhToan tt = new ThanhToan();
            tt.MaThanhToan = MaTT;
            tt.ThanhTien = ThanhTien;
            tt.NgayThanhToan = NgayThanhToan;
            tt.MaPhong = MaPhong;
            tt.MaNV = MaNV;
            tt.TrangThai = TrangThai;

            qlKS.ThanhToans.InsertOnSubmit(tt);
            qlKS.ThanhToans.Context.SubmitChanges();
            return true;
        }

        public bool UpdatePurchase(string MaTT, decimal ThanhTien, DateTime NgayThanhToan, string MaPhong, string MaNV, bool TrangThai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var ttQuery = (from tt in qlKS.ThanhToans
                           where tt.MaThanhToan == MaTT
                           select tt).SingleOrDefault();

            if (ttQuery != null)
            {
                ttQuery.MaThanhToan = MaTT;
                ttQuery.ThanhTien = ThanhTien;
                ttQuery.NgayThanhToan = NgayThanhToan;
                ttQuery.MaPhong = MaPhong;
                ttQuery.MaNV = MaNV;
                ttQuery.TrangThai = TrangThai;
                
                qlKS.SubmitChanges();
            }

            return true;
        }

        public bool DeletePurchase(ref string err, string MaTT)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();

            var ttQuery = from tt in qlKS.ThanhToans
                          where tt.MaThanhToan == MaTT
                          select tt;

            qlKS.ThanhToans.DeleteAllOnSubmit(ttQuery);
            qlKS.SubmitChanges();
            return true;

        }
    }
}
