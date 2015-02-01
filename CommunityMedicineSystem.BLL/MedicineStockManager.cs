using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAL;
using CommunityMedicineSystem.DAO;
using CommunityMedicineSystem.DAO.ViewModel;

namespace CommunityMedicineSystem.BLL
{
    public class MedicineStockManager
    {
        MedicineStockGateway aMedicineStockGateway=new MedicineStockGateway();
         public List<MedicineStockReport> ShowStock(int centerId)
        {
            return aMedicineStockGateway.ShowStock(centerId);
        }
    }
}
