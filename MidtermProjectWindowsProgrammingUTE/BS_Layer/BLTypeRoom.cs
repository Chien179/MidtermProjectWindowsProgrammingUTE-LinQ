using System.Data;
using System.Data.Linq;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLTypeRoom
    {
        public Table<LoaiPhong> GetTypeRoom()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.LoaiPhongs;
        }
    }
}
