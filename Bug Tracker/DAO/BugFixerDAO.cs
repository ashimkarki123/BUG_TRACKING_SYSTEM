using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class BugFixerDAO : GenericDAO<BugFixerViewModel>
    {
        private SqlConnection conn = new DBConnection().GetConnection();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<BugFixerViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public BugFixerViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(BugFixerViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_fixer VALUES(@fixed_by, @bug_id, @fixed_date)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@fixed_by", t.FixBy);
                sql.Parameters.AddWithValue("@bug_id", t.BugId);
                sql.Parameters.AddWithValue("@fixed_date", DateTime.Now);

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

        public void Update(BugFixerViewModel t)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// returns a name of bug fixer
        /// </summary>
        /// <returns></returns>
        public List<BugFixerViewModel> GetBugFixers()
        {
            conn.Open();
            List<BugFixerViewModel> list = new List<BugFixerViewModel>();
            BugFixerViewModel fixer = null;
            ProgrammerViewModel programmer = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "SELECT f.bug_id, f.fixed_date, p.full_name FROM tbl_programmer p JOIN tbl_fixer f ON p.programmer_id = f.fixed_by;";
                sql.Prepare();

                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fixer = new BugFixerViewModel();
                        programmer = new ProgrammerViewModel();

                        fixer.BugId = Convert.ToInt32(reader["bug_id"]);
                        fixer.FixDate = Convert.ToDateTime(reader["fixed_date"]);
                        programmer.FullName = reader["full_name"].ToString();

                        fixer.Programmer = programmer;

                        list.Add(fixer);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

    }
}
