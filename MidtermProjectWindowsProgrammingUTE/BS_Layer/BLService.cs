﻿using System.Data;
using System.Data.Linq;
using System;
using System.Linq;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLService
    {
        public Table<DichVu> GetService()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.DichVus;
        }

        public bool AddService(string MaDV, string TenDV, float GiaTien, string DonViTinh, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            DichVu dv = new DichVu();
            dv.MaDV = MaDV;
            dv.TenDV = TenDV;
            dv.GiaTien = GiaTien;
            dv.DonViTinh = DonViTinh;

            qlKS.DichVus.InsertOnSubmit(dv);
            qlKS.DichVus.Context.SubmitChanges();
            return true;
        }

        public bool UpdateService(string MaDV, string TenDV, float GiaTien, string DonViTinh, ref string err)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            var dvQuery = (from dv in qlKS.DichVus
                          where dv.MaDV == MaDV
                          select dv).SingleOrDefault();

            if (dvQuery != null)
            {
                dvQuery.MaDV = MaDV;
                dvQuery.TenDV = TenDV;
                dvQuery.GiaTien = GiaTien;
                dvQuery.DonViTinh = DonViTinh;

                qlKS.SubmitChanges();
            }

            return true;
        }

        public bool DeleteService(ref string err, string MaDV)
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();

            var dvQuery = from dv in qlKS.DichVus
                         where dv.MaDV == MaDV
                         select dv;

            qlKS.DichVus.DeleteAllOnSubmit(dvQuery);
            qlKS.SubmitChanges();
            return true;
        }
    }
}
