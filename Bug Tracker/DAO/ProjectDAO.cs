using Bug_Tracker.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class ProjectDAO : GenericDAO<ProjectViewModel>
    {
        private SqlConnection conn = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            conn.Open();
            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "DELETE FROM tbl_project WHERE project_id=@projectId;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectId", id);

                int res = sql.ExecuteNonQuery();

                if (res > 0)
                {
                    return true;
                } else
                {
                    return false;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProjectViewModel> GetAll()
        {
            conn.Open();
            List<ProjectViewModel> list = new List<ProjectViewModel>();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "SELECT * FROM tbl_project WHERE admin_id=@adminId;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@adminId", Program.adminId);

                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ProjectViewModel p = new ProjectViewModel
                        {
                            ProjectId = Convert.ToInt32(reader["project_id"]),
                            ProjectName = reader["project_name"].ToString(),
                            AdminId = Convert.ToInt32(reader["admin_id"])
                        };

                        list.Add(p);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

        public ProjectViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProjectViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_project VALUES(@projectName, @adminId)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectName", t.ProjectName);
                sql.Parameters.AddWithValue("@adminId", Program.adminId);

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

        public void Update(ProjectViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "UPDATE tbl_project SET project_name = @projectName WHERE project_id = @projectId";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectName", t.ProjectName);
                sql.Parameters.AddWithValue("@projectId", t.ProjectId);

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
