using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    /// <summary>
    /// A generic class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface GenericDAO<T>
    {
        /// <summary>
        /// method for inserting data into database
        /// </summary>
        /// <param name="t"></param>
        void Insert(T t);
        /// <summary>
        /// method for updating data in database
        /// </summary>
        /// <param name="t"></param>
        void Update(T t);
        /// <summary>
        /// method for deleting data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
        /// <summary>
        /// returns all related data
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// returns specific data based on user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);
    }
}
