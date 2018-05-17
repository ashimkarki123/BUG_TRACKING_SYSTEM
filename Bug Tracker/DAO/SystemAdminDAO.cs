using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class SystemAdminDAO : GenericDAO<SystemAdmin>
    {
        private SqlConnection conn = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SystemAdmin> GetAll()
        {
            throw new NotImplementedException();
        }

        public SystemAdmin GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(SystemAdmin t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_admin VALUES(@company_name, @username, @password)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@company_name", t.CompanyName);
                sql.Parameters.AddWithValue("@username", t.Username);
                sql.Parameters.AddWithValue("@password", t.Password);

                sql.ExecuteNonQuery();

                trans.Commit();
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(SystemAdmin t)
        {
            throw new NotImplementedException();
        }

        public int IsLogin(string username, string password)
        {
            conn.Open();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "SELECT * FROM tbl_admin WHERE username=@username AND password=@password;SELECT SCOPE_IDENTITY()";
                sql.Prepare();
                sql.Parameters.AddWithValue("@username", username);
                sql.Parameters.AddWithValue("@password", password);

                int id = Convert.ToInt32(sql.ExecuteScalar());

                return id;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
