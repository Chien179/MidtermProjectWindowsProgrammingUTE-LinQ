    using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLUseService
    {
        public Table<SuDungDichVu> GetUseService()
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.SuDungDichVus;
        }

        public List<string> GetUseServiceProperties()
        {
            var propertiessddv = (from sddv in typeof(SuDungDichVu).GetProperties()
                                select sddv.Name);

            List<string> ProTP = propertiessddv.ToList();

            return ProTP;
        }

        public bool AddUseService(string MaPhong, string MaDV, DateTime NgaySuDung, int SoLuong, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            SuDungDichVu sddv = new SuDungDichVu();
            sddv.MaPhong = MaPhong;
            sddv.MaDV = MaDV;
            sddv.NgaySuDung = NgaySuDung;
            sddv.SoLuong = SoLuong;

            qlKS.SuDungDichVus.InsertOnSubmit(sddv);
            qlKS.SuDungDichVus.Context.SubmitChanges();
            return true;

        }

        public bool UpdateUseService(string MaPhong, string MaDV, DateTime NgaySuDung, int SoLuong, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var sddvQuery = (from sddv in qlKS.SuDungDichVus
                           where sddv.MaPhong == MaPhong
                           where sddv.MaDV == MaDV
                           select sddv).SingleOrDefault();

            if (sddvQuery != null)
            {
                sddvQuery.MaPhong = MaPhong;
                sddvQuery.MaDV = MaDV;
                sddvQuery.NgaySuDung = NgaySuDung;
                sddvQuery.SoLuong = SoLuong;
                qlKS.SubmitChanges();
            }

            return true;
        }
        public bool UpdateStatusUseService(string MaPhong,bool TrangThai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var sddvQuery = (from sddv in qlKS.SuDungDichVus
                             where sddv.MaPhong == MaPhong
                             select sddv).SingleOrDefault();

            if (sddvQuery != null)
            {
                sddvQuery.TrangThai = true;
                qlKS.SubmitChanges();
            }

            return true;
        }
        public bool DeleteUseService(string MaPhong, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();

            var sddvQuery = from sddv in qlKS.SuDungDichVus
                          where sddv.MaPhong == MaPhong
                          select sddv;

            qlKS.SuDungDichVus.DeleteAllOnSubmit(sddvQuery);
            qlKS.SubmitChanges();
            return true;
        }
        // public DataSet SearchUseService(string key)
    }
}
