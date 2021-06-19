using System.Data;
using System.Data.Linq;

namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLLogin
    {
        public Table<TaiKhoan> GetLogin()
        {
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.TaiKhoans;
        }
    }
}
