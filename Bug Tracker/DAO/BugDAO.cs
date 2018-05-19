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

        /// <summary>
        /// used to delete bugs
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "DELETE FROM tbl_bug WHERE bug_id=@bugId";
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

        public List<BugViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns bugs by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        public BugViewModel GetById(int id)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            BugViewModel bug = null;
            CodeViewModel code = null;
            PictureViewModel image = null;
            VersionControl VersionControl = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "SELECT * FROM tbl_bug b JOIN tbl_code c ON b.bug_id = c.bug_id JOIN tbl_image i ON b.bug_id = i.bug_id JOIN tbl_source_control sc ON sc.bug_id = i.bug_id WHERE bug_status = 0 AND b.bug_id = @id;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bug = new BugViewModel();
                        code = new CodeViewModel();
                        image = new PictureViewModel();
                        VersionControl = new VersionControl();

                        bug.BugId = Convert.ToInt32(reader["bug_id"]);
                        bug.ProjectName = Convert.ToString(reader["project_name"]);
                        bug.ClassName = Convert.ToString(reader["class_name"]);
                        bug.MethodName = Convert.ToString(reader["method_name"]);
                        bug.StartLine = Convert.ToInt32(reader["start_line"]);
                        bug.EndLine = Convert.ToInt32(reader["end_line"]);
                        bug.ProgrammerId = Convert.ToInt32(reader["code_author"]);
                        bug.Status = Convert.ToString(reader["bug_status"]);

                        code.CodeId = Convert.ToInt32(reader["code_id"]);
                        code.CodeFilePath = Convert.ToString(reader["code_file_path"]);
                        code.CodeFileName = Convert.ToString(reader["code_file_name"]);
                        code.ProgrammingLanguage = Convert.ToString(reader["programming_language"]);
                        code.BugId = Convert.ToInt32(reader["bug_id"]);

                        image.ImageId = Convert.ToInt32(reader["image_id"]);
                        image.ImagePath = Convert.ToString(reader["image_path"]);
                        image.ImageName = Convert.ToString(reader["image_name"]);
                        image.BugId = Convert.ToInt32(reader["bug_id"]);

                        VersionControl.VersionControlId = Convert.ToInt32(reader["source_control_id"]);
                        VersionControl.Link = reader["link"].ToString();
                        VersionControl.StartLine = Convert.ToInt32(reader["start_line"]);
                        VersionControl.EndLine = Convert.ToInt32(reader["end_line"]);
                        VersionControl.BugId = Convert.ToInt32(reader["bug_id"]);

                        bug.SourceControl = VersionControl;
                        bug.Images = image;
                        bug.Codes = code;
                    }
                }

            }
            catch (SqlException ex)
            {
                conn.Close();
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                conn.Close();
                throw new NullReferenceException(ex.Message);
            }

            return bug;
        }

        /// <summary>
        /// insert new bugs
        /// </summary>
        /// <param name="t"></param>

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
        /// <summary>
        /// update bugs
        /// </summary>
        /// <param name="t"></param>

        public void Update(BugViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "UPDATE tbl_bug SET project_name = @projectname, class_name = @classname, method_name = @methodname, start_line = @startline, end_line = @endline WHERE bug_id=@bug_id;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@projectname", t.ProjectName);
                sql.Parameters.AddWithValue("@classname", t.ClassName);
                sql.Parameters.AddWithValue("@methodname", t.MethodName);
                sql.Parameters.AddWithValue("@startline", t.StartLine);
                sql.Parameters.AddWithValue("@endline", t.EndLine);
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

        /// <summary>
        /// get all bugs with related code and image
        /// </summary>
        /// <returns>List<string></returns>
        public List<BugViewModel> getAllBugs()
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            List<BugViewModel> bugList = new List<BugViewModel>();
            BugViewModel bug = null;
            CodeViewModel code = null;
            PictureViewModel image = null;
            VersionControl VersionControl = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "SELECT * FROM tbl_bug b JOIN tbl_code c ON b.bug_id = c.bug_id JOIN tbl_image i ON b.bug_id = i.bug_id JOIN tbl_source_control sc ON sc.bug_id = i.bug_id WHERE bug_status = 0 ;";
                sql.Prepare();

                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bug = new BugViewModel();
                        code = new CodeViewModel();
                        image = new PictureViewModel();
                        VersionControl = new VersionControl();

                        bug.BugId = Convert.ToInt32(reader["bug_id"]);
                        bug.ProjectName = Convert.ToString(reader["project_name"]);
                        bug.ClassName = Convert.ToString(reader["class_name"]);
                        bug.MethodName = Convert.ToString(reader["method_name"]);
                        bug.StartLine = Convert.ToInt32(reader["start_line"]);
                        bug.EndLine = Convert.ToInt32(reader["end_line"]);
                        bug.ProgrammerId = Convert.ToInt32(reader["code_author"]);
                        bug.Status = Convert.ToString(reader["bug_status"]);

                        code.CodeId = Convert.ToInt32(reader["code_id"]);
                        code.CodeFilePath = Convert.ToString(reader["code_file_path"]);
                        code.CodeFileName = Convert.ToString(reader["code_file_name"]);
                        code.ProgrammingLanguage = Convert.ToString(reader["programming_language"]);
                        code.BugId = Convert.ToInt32(reader["bug_id"]);

                        image.ImageId = Convert.ToInt32(reader["image_id"]);
                        image.ImagePath = Convert.ToString(reader["image_path"]);
                        image.ImageName = Convert.ToString(reader["image_name"]);
                        image.BugId = Convert.ToInt32(reader["bug_id"]);

                        VersionControl.VersionControlId = Convert.ToInt32(reader["source_control_id"]);
                        VersionControl.Link = reader["link"].ToString();
                        VersionControl.StartLine = Convert.ToInt32(reader["start_line"]);
                        VersionControl.EndLine = Convert.ToInt32(reader["end_line"]);
                        VersionControl.BugId = Convert.ToInt32(reader["bug_id"]);

                        bug.SourceControl = VersionControl;
                        bug.Images = image;
                        bug.Codes = code;
                        bugList.Add(bug);
                    }
                }

            }
            catch (SqlException ex)
            {
                conn.Close();
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                conn.Close();
                throw new NullReferenceException(ex.Message);
            }

            return bugList;
        }
        /// <summary>
        /// returns programmer's related bug
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BugViewModel> GetAllBugsByProgrammerId(int id)
        {
            conn.Close();
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            List<BugViewModel> bugList = new List<BugViewModel>();
            BugViewModel bug = null;
            CodeViewModel code = null;
            PictureViewModel image = null;
            VersionControl sourceControl = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "SELECT* FROM tbl_programmer p JOIN tbl_assign a ON a.assign_to = p.programmer_id JOIN tbl_bug b ON b.bug_id = a.bug_id JOIN tbl_image i ON b.bug_id = i.bug_id JOIN tbl_source_control sc ON sc.bug_id = i.bug_id JOIN tbl_code c ON c.bug_id = b.bug_id WHERE a.assign_to = @id AND b.bug_status = '0';";
                sql.Prepare();
                sql.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bug = new BugViewModel();
                        code = new CodeViewModel();
                        image = new PictureViewModel();
                        sourceControl = new VersionControl();

                        bug.BugId = Convert.ToInt32(reader["bug_id"]);
                        bug.ProjectName = Convert.ToString(reader["project_name"]);
                        bug.ClassName = Convert.ToString(reader["class_name"]);
                        bug.MethodName = Convert.ToString(reader["method_name"]);
                        bug.StartLine = Convert.ToInt32(reader["start_line"]);
                        bug.EndLine = Convert.ToInt32(reader["end_line"]);
                        bug.ProgrammerId = Convert.ToInt32(reader["code_author"]);
                        bug.Status = Convert.ToString(reader["bug_status"]);

                        code.CodeId = Convert.ToInt32(reader["code_id"]);
                        code.CodeFilePath = Convert.ToString(reader["code_file_path"]);
                        code.CodeFileName = Convert.ToString(reader["code_file_name"]);
                        code.ProgrammingLanguage = Convert.ToString(reader["programming_language"]);
                        code.BugId = Convert.ToInt32(reader["bug_id"]);

                        image.ImageId = Convert.ToInt32(reader["image_id"]);
                        image.ImagePath = Convert.ToString(reader["image_path"]);
                        image.ImageName = Convert.ToString(reader["image_name"]);
                        image.BugId = Convert.ToInt32(reader["bug_id"]);

                        sourceControl.VersionControlId = Convert.ToInt32(reader["source_control_id"]);
                        sourceControl.Link = reader["link"].ToString();
                        sourceControl.StartLine = Convert.ToInt32(reader["start_line"]);
                        sourceControl.EndLine = Convert.ToInt32(reader["end_line"]);
                        sourceControl.BugId = Convert.ToInt32(reader["bug_id"]);

                        bug.SourceControl = sourceControl;
                        bug.Images = image;
                        bug.Codes = code;
                        bugList.Add(bug);
                    }
                }

            }
            catch (SqlException ex)
            {
                conn.Close();
                throw ex;
            }
            catch (NullReferenceException ex)
            {
                conn.Close();
                throw new NullReferenceException(ex.Message);
            }

            return bugList;
        }

        /// <summary>
        /// update bug status
        /// </summary>
        /// <param name="bugId"></param>
        public void BugFixed(int bugId)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "UPDATE tbl_bug SET bug_status = @bug_status WHERE bug_id=@bug_id;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@bug_status", "1");
                sql.Parameters.AddWithValue("@bug_id", bugId);

                sql.ExecuteNonQuery();

                trans.Commit();
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
    }
}
