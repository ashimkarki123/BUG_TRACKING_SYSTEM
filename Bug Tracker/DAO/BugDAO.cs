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
    class BugDAO : GenericDAO<BugViewModel>
    {

        private SqlConnection conn = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BugViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BugViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(BugViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_bug VALUES(@projectname, @classname, @methodname, @startline, @endline, @codeauthor, @status); SELECT SCOPE_IDENTITY()";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectname", t.ProjectName);
                sql.Parameters.AddWithValue("@classname", t.ClassName);
                sql.Parameters.AddWithValue("@methodname", t.MethodName);
                sql.Parameters.AddWithValue("@startline", t.StartLine);
                sql.Parameters.AddWithValue("@endline", t.EndLine);
                sql.Parameters.AddWithValue("@codeauthor", t.ProgrammerId);
                sql.Parameters.AddWithValue("@status", t.Status);

                sql.ExecuteNonQuery();

                t.BugId = Convert.ToInt32(sql.ExecuteScalar());

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

        public void Update(BugViewModel t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// get all bugs with related code and image
        /// </summary>
        /// <returns>List<string></returns>
        public ArrayList getAllBugs()
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            ArrayList list = new ArrayList();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "SELECT * FROM tbl_bug b JOIN tbl_code c ON b.bug_id = c.bug_id JOIN tbl_image i ON b.bug_id = i.bug_id WHERE bug_status = 0;";
                sql.Prepare();

                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while(reader.Read())
                    {

                        object[] tempRow = new object[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            tempRow[i] = reader[i];
                        }
                        list.Add(tempRow);

                        //list.Add(reader["bug_id"].ToString());
                        //list.Add(reader["project_name"].ToString());
                        //list.Add(reader["class_name"].ToString());
                        //list.Add(reader["method_name"].ToString());
                        //list.Add(reader["start_line"].ToString());
                        //list.Add(reader["end_line"].ToString());
                        //list.Add(reader["code_author"].ToString());
                        //list.Add(reader["bug_status"].ToString());
                        //list.Add(reader["code_id"].ToString());
                        //list.Add(reader["code_file_path"].ToString());
                        //list.Add(reader["code_file_name"].ToString());
                        //list.Add(reader["programming_language"].ToString());
                        //list.Add(reader["bug_id"].ToString());
                        //list.Add(reader["image_id"].ToString());
                        //list.Add(reader["image_path"].ToString());
                        //list.Add(reader["image_name"].ToString());
                        //list.Add(reader["bug_id"].ToString());
                    }
                }

                trans.Commit();
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                throw ex;
            } catch(NullReferenceException ex)
            {
                trans.Rollback();
                throw ex;
            }

            return list;
        }
    }
}
