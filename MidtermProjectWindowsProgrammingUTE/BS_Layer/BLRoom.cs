using System.Data;
using System.Data.Linq;
using System;
using System.Linq;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLRoom
    {
        public Table<Phong> GetRoom()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.Phongs;
        }

        public bool AddRoom(string MaPhong, string MaLoai, bool TrangThai, string GhiChu, string DienTich, float GiaThue, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            Phong p = new Phong();
            p.MaPhong = MaPhong;
            p.MaLoai = MaLoai;
            p.TrangThai = TrangThai;
            p.GhiChu = GhiChu;
            p.DienTich = DienTich;
            p.GiaThue = GiaThue;

            qlKS.Phongs.InsertOnSubmit(p);
            qlKS.Phongs.Context.SubmitChanges();
            return true;
        }

        public bool UpdateRoom(string MaPhong, string MaLoai, bool TrangThai, string GhiChu, string DienTich, float GiaThue, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var pQuery = (from p in qlKS.Phongs
                           where p.MaPhong == MaPhong
                           select p).SingleOrDefault();

            if (pQuery != null)
            {
                pQuery.MaPhong = MaPhong;
                pQuery.MaLoai = MaLoai;
                pQuery.TrangThai = TrangThai;
                pQuery.GhiChu = GhiChu;
                pQuery.DienTich = DienTich;
                pQuery.GiaThue = GiaThue;

                qlKS.SubmitChanges();
            }

            return true;
        }
        public bool DeleteRoom(ref string err, string MaPhong)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();

            var pQuery =  from p in qlKS.Phongs
                          where p.MaPhong == MaPhong
                          select p;

            qlKS.Phongs.DeleteAllOnSubmit(pQuery);
            qlKS.SubmitChanges();
            return true;
        }
    }
}
