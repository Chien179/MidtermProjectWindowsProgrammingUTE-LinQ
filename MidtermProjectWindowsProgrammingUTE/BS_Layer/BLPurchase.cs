using System.Data;
using System.Data.Linq;

namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLPurchase
    {
        public Table<ThanhToan> GetPurchase()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.ThanhToans;
        }
    }
}
