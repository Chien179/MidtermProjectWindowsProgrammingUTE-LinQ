using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLTypeRoom
    {
        public System.Data.Linq.Table<LoaiPhong> GetTypeRoom()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.LoaiPhongs;
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
    }
}
