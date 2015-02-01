using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityMedicineSystem.DAO;

namespace CommunityMedicineSystem.DAL
{
    public class DiseaseGateway:Gateway
    {
         public void Save(Disease aDisease)
        {
            SqlQuery = "INSERT INTO tbl_diseases VALUES('" + aDisease.Name + "','" + aDisease.Description + "','" +
                           aDisease.TreatementProcedure + "','" + aDisease.PreferedMedicine + "')";
            DbSqlConnection = new SqlConnection(ConnectionString);
            DbSqlConnection.Open();
            DbSqlCommand = new SqlCommand(SqlQuery, DbSqlConnection);
            DbSqlCommand.ExecuteNonQuery();
            DbSqlConnection.Close();
        }
        public Disease Find(string name)
        {
            string query = "SELECT * FROM tbl_diseases WHERE name='" + name + "'";
            DbSqlConnection = new SqlConnection(ConnectionString);
            DbSqlConnection.Open();
            DbSqlCommand = new SqlCommand(query, DbSqlConnection);
            DbSqlDataReader = DbSqlCommand.ExecuteReader();
            if (DbSqlDataReader.HasRows)
            {
                Disease aDisease = new Disease();
                while (DbSqlDataReader.Read())
                {
                    aDisease.Id = Convert.ToInt32(DbSqlDataReader["id"]);
                    aDisease.Name = DbSqlDataReader["name"].ToString();
                    aDisease.Description = DbSqlDataReader["description"].ToString();
                    aDisease.TreatementProcedure = DbSqlDataReader["treatement_procedure"].ToString();
                    aDisease.PreferedMedicine = DbSqlDataReader["prefered_medicine"].ToString();
                }
                DbSqlConnection.Close();
                return aDisease;
            }
            DbSqlConnection.Close();
            return null;
        }
    }
}
