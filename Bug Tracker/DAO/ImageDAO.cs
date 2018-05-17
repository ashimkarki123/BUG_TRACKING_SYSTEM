using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Tracker.Model;

namespace Bug_Tracker.DAO
{
    class ImageDAO : GenericDAO<PictureViewModel>
    {

        private SqlConnection conn = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PictureViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PictureViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PictureViewModel t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_image VALUES(@filepath, @filename, @bugid)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@filepath", t.ImagePath);
                sql.Parameters.AddWithValue("@filename", t.ImageName);
                sql.Parameters.AddWithValue("@bugid", t.BugId);

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

        public void Update(PictureViewModel t)
        {
            throw new NotImplementedException();
        }
    }
}
