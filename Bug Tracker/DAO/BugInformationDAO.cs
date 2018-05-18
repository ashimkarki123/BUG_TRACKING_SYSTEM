using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class BugInformationDAO : GenericDAO<BugInformationViewModel>
    {
        private SqlConnection conn = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BugInformationViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BugInformationViewModel GetById(int id)
        {
            conn.Open();
            BugInformationViewModel p = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "SELECT * FROM tbl_bug_information WHERE bug_id=@bug_id;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@bug_id", id);
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        p = new BugInformationViewModel
                        {
                            InformationId = Convert.ToInt32(reader["bug_information_id"]),
                            Cause = reader["cause"].ToString(),
                            Symptons = reader["symptons"].ToString(),
                            BugId = Convert.ToInt32(reader["bug_id"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return p;
        }

        public void Insert(BugInformationViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_bug_information VALUES(@symptons, @cause, @bug_id)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@symptons", t.Symptons);
                sql.Parameters.AddWithValue("@cause", t.Cause);
                sql.Parameters.AddWithValue("@bug_id", t.BugId);

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

        public void Update(BugInformationViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "UPDATE tbl_bug_information SET symptons = @symptons, cause = @cause WHERE bug_id = @bug_id";
                sql.Prepare();
                sql.Parameters.AddWithValue("@symptons", t.Symptons);
                sql.Parameters.AddWithValue("@cause", t.Cause);
                sql.Parameters.AddWithValue("@bug_id", t.BugId);

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
    }
}

