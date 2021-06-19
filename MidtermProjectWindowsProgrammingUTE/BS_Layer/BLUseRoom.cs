using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLUseRoom
    {
        public Table<ThuePhong> GetUseRoom()
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.ThuePhongs;
        }


        public bool AddUseRoom(string MaPhong, string CMND, DateTime NgayVao, float DatCoc, String MaNV, bool TrangThai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            ThuePhong tp = new ThuePhong();
            tp.MaPhong = MaPhong;
            tp.CMND = CMND;
            tp.NgayVao = NgayVao;
            tp.DatCoc = DatCoc;
            tp.MaNV = MaNV;
            tp.TrangThai = TrangThai;

            qlKS.ThuePhongs.InsertOnSubmit(tp);
            qlKS.ThuePhongs.Context.SubmitChanges();
            return true;

        }

        public bool UpdateUseRoom(string MaPhong, string CMND, DateTime NgayVao, float DatCoc, String MaNV, bool TrangThai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var tpQuery = (from tp in qlKS.ThuePhongs
                           where tp.MaPhong == MaPhong
                           where tp.CMND == CMND
                           select tp).SingleOrDefault();

            if (tpQuery != null)
            {
                tpQuery.MaPhong = MaPhong;
                tpQuery.CMND = CMND;
                tpQuery.NgayVao = NgayVao;
                tpQuery.DatCoc = DatCoc;
                tpQuery.MaNV = MaNV;
                tpQuery.TrangThai = TrangThai;
                qlKS.SubmitChanges();
            }

            return true;
        }
    }
}
