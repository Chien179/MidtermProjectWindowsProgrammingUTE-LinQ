using System.Data;
using System.Data.Linq;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLUseRoom
    {
        public Table<ThuePhong> GetUseRoom()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.ThuePhongs;
        }
    }
}
