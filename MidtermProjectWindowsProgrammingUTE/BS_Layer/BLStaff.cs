using System.Data;
using System.Data.Linq;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLStaff
    {
        public Table<NhanVien> GetStaff()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.NhanViens;
        }
    }
}
