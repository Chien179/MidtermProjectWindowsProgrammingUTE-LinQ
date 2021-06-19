﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLUseService
    {
        public System.Data.Linq.Table<SuDungDichVu> GetUseService()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.SuDungDichVus;
        }
        public bool AddUseService(string MaPhong, string MaDV, string NgaySuDung, int SoLuong,string TrangThai, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            SuDungDichVu sddv = new SuDungDichVu();
            sddv.MaPhong = MaPhong;
            sddv.MaDV = MaDV;
            //sddv.NgaySuDung = NgaySuDung;
            sddv.SoLuong = SoLuong;
            //sddv.TrangThai = TrangThai;
            qlKS.SuDungDichVus.InsertOnSubmit(sddv);
            qlKS.SuDungDichVus.Context.SubmitChanges();
            return true;
        }
        public bool UpdateUseService(string MaPhong, string MaDV, string NgaySuDung, int SoLuong, string TrangThai, ref string err)
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
                //sddvQuery.NgaySuDung = NgaySuDung;
                sddvQuery.SoLuong = SoLuong;
                //sddvQuery.TrangThai = TrangThai;
                qlKS.SubmitChanges();
            }
            return true;
        }
    }
}
