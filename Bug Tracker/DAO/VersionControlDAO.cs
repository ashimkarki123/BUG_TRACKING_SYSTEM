using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class VersionControlDAO : GenericDAO<VersionControl>
    {
        private SqlConnection conn = new DBConnection().GetConnection();
        public bool Delete(int id)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "DELETE FROM tbl_source_control WHERE bug_id=@bugId";
                sql.Prepare();
                sql.Parameters.AddWithValue("@bugId", id);

                sql.ExecuteNonQuery();
                trans.Commit();

                return true;
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<VersionControl> GetAll()
        {
            throw new NotImplementedException();
        }

        public VersionControl GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(VersionControl t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_source_control VALUES(@link, @start_line, @end_line, @bug_id)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@link", t.Link);
                sql.Parameters.AddWithValue("@start_line", t.StartLine);
                sql.Parameters.AddWithValue("@end_line", t.EndLine);
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

        public void Update(VersionControl t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "UPDATE tbl_source_control SET link = @link, start_line = @start_line, end_line = @end_line WHERE bug_id = @bug_id;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@link", t.Link);
                sql.Parameters.AddWithValue("@start_line", t.StartLine);
                sql.Parameters.AddWithValue("@end_line", t.EndLine);
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
