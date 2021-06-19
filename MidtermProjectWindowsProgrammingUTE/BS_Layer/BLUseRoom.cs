using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLUseRoom
    {
        public System.Data.Linq.Table<ThuePhong> GetUseRoom()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.ThuePhongs;
        }
        public bool AddUseRoom(string MaPhong, string CMND, string NgayVao, float DatCoc, string MaNV,string TrangThai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            ThuePhong tp = new ThuePhong();
            tp.MaPhong = MaPhong;
            tp.CMND = CMND;
            //tp.NgayVao = NgayVao;
            tp.DatCoc = DatCoc;
            tp.MaNV = MaNV;
            //tp.TrangThai = TrangThai;
            qlKS.ThuePhongs.InsertOnSubmit(tp);
            qlKS.ThuePhongs.Context.SubmitChanges();
            return true;
        }
        public bool UpDateUseRoom(string MaPhong, string CMND, string NgayVao, float DatCoc, string MaNV, string TrangThai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var tpQuery = (from tp in qlKS.ThuePhongs
                           where tp.MaPhong == MaPhong 
                           where tp.CMND==CMND
                           select tp).SingleOrDefault();

            if (tpQuery != null)
            {
                tpQuery.MaPhong = MaPhong;
                tpQuery.CMND = CMND;
                //tpQuery.NgayVao = NgayVao;
                tpQuery.DatCoc = DatCoc;
                tpQuery.MaNV = MaNV;
                //tpQuery.TrangThai = TrangThai;
                qlKS.SubmitChanges();
            }
            return true;
        }
    }
}
