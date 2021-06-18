using System.Data;
using System.Data.Linq;
namespace MidtermProjectWindowsProgrammingUTE.BS_Layer
{
    class BLUseService
    {
        public Table<SuDungDichVu> GetUseService()
        {
            DataSet ds = new DataSet();
            QuanLyKhachSanDataContext qlKS = new QuanLyKhachSanDataContext();
            return qlKS.SuDungDichVus;
        }
    }
}
