using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Bug_Tracker
{
    /**
     * used to connect to database
     * 
     * */
    class DBConnection
    {
        /**The Connection String includes parameters such as the name of the driver, 
         * Server name and Database name , as well as security information such as user name and password. 
         * 
         * 'connectionstr' is defined in App.config
         * */
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionstr"].ConnectionString;

        /// <summary>
        /// connects sql query with connection string
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
