using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDb
    {
        private LinkHubDbEntities db;

        public UserDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetById(int id)
        {
            return db.tbl_User.Find(id);
        }

        public void Insert(tbl_User obj)
        {
            db.tbl_User.Add(obj);
            Save();
        }

        public void Delete(int id)
        {
            db.tbl_User.Remove(GetById(id));
            Save();
        }

        public void Update(tbl_User obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        private void Save()
        {
            db.SaveChanges();
        }

    }
}