using System.Data;
using System.Data.Linq;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLRoom
    {
        public Table<Phong> GetRoom()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.Phongs;
        }
    }
}
