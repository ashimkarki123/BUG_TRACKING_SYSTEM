using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class TesterDAO : GenericDAO<TesterViewModel>
    {
        private SqlConnection conn = new DBConnection().GetConnection();
        /// <summary>
        /// used for deleting tester
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// used for getting all the tester information
        /// </summary>
        /// <returns></returns>

        public List<TesterViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// used to get a specific user information based on their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TesterViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// used to insert new tester
        /// </summary>
        /// <param name="t"></param>
        public void Insert(TesterViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_tester VALUES(@fullName, @username, @password)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@fullName", t.FullName);
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

        /// <summary>
        /// used to update tester information
        /// </summary>
        /// <param name="t"></param>
        public void Update(TesterViewModel t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// used to allow tester to logged in a system
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int IsLogin(string username, string password)
        {
            conn.Open();
            SqlTransaction trans = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "SELECT * FROM tbl_tester WHERE username=@username AND password=@password;SELECT SCOPE_IDENTITY()";
                sql.Prepare();
                sql.Parameters.AddWithValue("@username", username);
                sql.Parameters.AddWithValue("@password", password);

                int id = Convert.ToInt32(sql.ExecuteScalar());

                return id;
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
    }
}
