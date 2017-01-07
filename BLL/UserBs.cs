using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    {
        private UserDb objDb;

        public UserBs()
        {
            objDb = new UserDb();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return objDb.GetAll();
        }

        public tbl_User GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(tbl_User obj)
        {
            objDb.Insert(obj);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(tbl_User obj)
        {
            objDb.Update(obj);
        }

    }
}

