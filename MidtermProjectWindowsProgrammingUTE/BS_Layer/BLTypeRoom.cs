using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System;

namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLTypeRoom
    {
        public Table<LoaiPhong> GetTypeRoom()
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.LoaiPhongs;
        }

        public List<string> GetTypeRoomProperties()
        {
            var propertiesLP = (from lp in typeof(LoaiPhong).GetProperties()
                                select lp.Name);

            List<string> ProLP = propertiesLP.ToList();

            return ProLP;
        }

        public bool AddTypeRoom(string MaLoai, string TenLoai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            LoaiPhong lp = new LoaiPhong();
            lp.MaLoai = MaLoai;
            lp.TenLoai = TenLoai;

            qlKS.LoaiPhongs.InsertOnSubmit(lp);
            qlKS.LoaiPhongs.Context.SubmitChanges();
            return true;

        }
        public bool DeleteTypeRoom(ref string err, string MaLoai)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();

            var lpQuery = from lp in qlKS.LoaiPhongs
                          where lp.MaLoai == MaLoai
                          select lp;

            qlKS.LoaiPhongs.DeleteAllOnSubmit(lpQuery);
            qlKS.SubmitChanges();
            return true;
        }

        public bool UpdateTypeRoom(string MaLoai, string TenLoai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var lpQuery = (from lp in qlKS.LoaiPhongs
                           where lp.MaLoai == MaLoai
                           select lp).SingleOrDefault();

            if (lpQuery != null)
            {
                lpQuery.MaLoai = MaLoai;
                lpQuery.TenLoai = TenLoai;
              
                qlKS.SubmitChanges();
            }

            return true;
        }
       // public DataSet SearchTypeRoom(string key)
    }
}
