using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.DAL
{
    public class DoctorGateway:Gateway
    {
       public void Save(Doctor aDoctor)
        {
            SqlQuery = "INSERT INTO tbl_doctors VALUES('" + aDoctor.Name + "','" +
                       aDoctor.Degree + "','" + aDoctor.Specialization + "'," + aDoctor.CenterId + ")";
            DbSqlConnection = new SqlConnection(ConnectionString);
            DbSqlConnection.Open();
            DbSqlCommand = new SqlCommand(SqlQuery, DbSqlConnection);
            DbSqlCommand.ExecuteNonQuery();
            DbSqlConnection.Close();
        } 
    }
}
