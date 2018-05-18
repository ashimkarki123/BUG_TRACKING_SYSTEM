using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class AssignDAO : GenericDAO<AssignViewModel>
    {
        private SqlConnection conn = new DBConnection().GetConnection();
        public bool Delete(int id)
        {
            conn.Open();
            AssignViewModel p = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "DELETE FROM tbl_assign WHERE bug_id=@bug_id;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@bug_id", id);

                sql.ExecuteNonQuery();

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<AssignViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AssignViewModel GetById(int id)
        {
            conn.Open();
            AssignViewModel p = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "SELECT * FROM tbl_assign WHERE bug_id=@bug_id;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@bug_id", id);
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        p = new AssignViewModel
                        {
                            AssignDate = DateTime.Parse(reader["assign_date"].ToString()),
                            Description = reader["descriptions"].ToString(),
                            AssignBy = Convert.ToInt32(reader["assign_by"]),
                            AssignTo = Convert.ToInt32(reader["assign_to"]),
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

        public void Insert(AssignViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_assign VALUES(@assign_date, @descriptions, @assign_by, @assign_to, @bug_id)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@assign_date", DateTime.Now);
                sql.Parameters.AddWithValue("@descriptions", t.Description);
                sql.Parameters.AddWithValue("@assign_by", t.AssignBy);
                sql.Parameters.AddWithValue("@assign_to", t.AssignTo);
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

        public void Update(AssignViewModel t)
        {
            throw new NotImplementedException();
        }
    }
}
