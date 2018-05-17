using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Tracker.Model;

namespace Bug_Tracker.DAO
{
    class ProgrammerDAO : GenericDAO<ProgrammerViewModel>
    {
        private SqlConnection conn = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProgrammerViewModel> GetAll()
        {
            conn.Open();
            List<ProgrammerViewModel> list = new List<ProgrammerViewModel>();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "SELECT * FROM tbl_programmer;";
                sql.Prepare();
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ProgrammerViewModel p = new ProgrammerViewModel
                        {
                            ProgrammerId = Convert.ToInt32(reader["programmer_id"]),
                            FullName = reader["full_name"].ToString(),
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString()
                        };

                        list.Add(p);
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

        public ProgrammerViewModel GetById(int id)
        {
            conn.Open();
            ProgrammerViewModel p = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "SELECT * FROM tbl_programmer WHERE programmer_id=@programmerId;";
                sql.Prepare();
                sql.Parameters.AddWithValue("@programmerId", id);
                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        p = new ProgrammerViewModel
                        {
                            ProgrammerId = Convert.ToInt32(reader["programmer_id"]),
                            FullName = reader["full_name"].ToString(),
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } finally
            {
                conn.Close();
            }

            return p;
        }

        public void Insert(ProgrammerViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            
            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_programmer VALUES(@fullName, @username, @password)";
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

        public void Update(ProgrammerViewModel t)
        {
            throw new NotImplementedException();
        }

        public int IsLogin(string username, string password)
        {
            conn.Open();
            SqlTransaction trans = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "SELECT * FROM tbl_programmer WHERE username=@username AND password=@password;SELECT SCOPE_IDENTITY()"; 
                sql.Prepare();
                sql.Parameters.AddWithValue("@username", username);
                sql.Parameters.AddWithValue("@password", password);

                int id = Convert.ToInt32(sql.ExecuteScalar());

                return id;
                //trans.Commit();
            } catch(SqlException ex)
            {
                trans.Rollback();
                throw ex;
            } finally
            {
                conn.Close();
            }
        }
    }
}
