using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAO;
using CommunityMedicineSystem.DAO.ViewModel;

namespace CommunityMedicineSystem.DAL
{
    public class MedicineStockGateway:Gateway
    {
        public List<MedicineStockReport> ShowStock(int centerId)
        {
            SqlQuery = "SELECT tbl_medicines.name medicinename,tbl_medicines_of_centers.quantity medicinequantity FROM tbl_medicines JOIN tbl_medicines_of_centers ON tbl_medicines.id=tbl_medicines_of_centers.medicine_id WHERE tbl_medicines_of_centers.center_id='" + centerId + "' ";
            DbSqlConnection = new SqlConnection(ConnectionString);
            DbSqlConnection.Open();
            DbSqlCommand = new SqlCommand(SqlQuery, DbSqlConnection);
            DbSqlDataReader = DbSqlCommand.ExecuteReader();
            List<MedicineStockReport> aMedicineStockReports = new List<MedicineStockReport>();
            while (DbSqlDataReader.Read())
            {
                MedicineStockReport aMedicineStockReport = new MedicineStockReport();
                aMedicineStockReport.MedicineName = DbSqlDataReader["medicinename"].ToString();
                aMedicineStockReport.MedicineQuantity = Convert.ToInt32(DbSqlDataReader["medicinequantity"]);
                aMedicineStockReports.Add(aMedicineStockReport);
            }
            DbSqlConnection.Close();
            return aMedicineStockReports;
        }
    }
}
