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

        //public DataSet GetUseRoomCheckIn(string idroom)

        //public DataSet GetUseRoomUnpaid()

        public List<string> GetUseRoomProperties()
        {
            var propertiesTP = (from tp in typeof(ThuePhong).GetProperties()
                                select tp.Name);

            List<string> ProTP = propertiesTP.ToList();

            return ProTP;
        }

        public bool AddUseRoom(string MaPhong, string CMND, DateTime NgayVao, float DatCoc, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            ThuePhong tp = new ThuePhong();
            tp.MaPhong = MaPhong;
            tp.CMND = CMND;
            tp.NgayVao = NgayVao;
            tp.DatCoc = DatCoc;

            qlKS.ThuePhongs.InsertOnSubmit(tp);
            qlKS.ThuePhongs.Context.SubmitChanges();
            return true;

        }

        public bool UpdateUseRoom(string MaPhong, string CMND, DateTime NgayVao, float DatCoc, ref string err)
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
                qlKS.SubmitChanges();
            }

            return true;
        }
        public bool UpdateCheckInDay(string MaPhong, DateTime NgayVao, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var tpQuery = (from tp in qlKS.ThuePhongs
                           where tp.MaPhong == MaPhong
                           select tp).SingleOrDefault();

            if (tpQuery != null)
            {
                tpQuery.NgayVao = NgayVao;
                qlKS.SubmitChanges();
            }

            return true;
        }

        public bool UpdateUseRoomStatus(string MaPhong,bool TrangThai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var tpQuery = (from tp in qlKS.ThuePhongs
                           where tp.MaPhong == MaPhong
                           select tp).SingleOrDefault();

            if (tpQuery != null)
            {
                tpQuery.TrangThai = true;
                qlKS.SubmitChanges();
            }

            return true;
        }
        public bool DeleteUseRoom(string MaPhong, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();

            var tpQuery = from tp in qlKS.ThuePhongs
                          where tp.MaPhong == MaPhong
                          select tp;

            qlKS.ThuePhongs.DeleteAllOnSubmit(tpQuery);
            qlKS.SubmitChanges();
            return true;
        }
        // public DataSet SearchUseRoom(string key)
    }
}
