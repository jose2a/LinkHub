using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDb
    {
        private LinkHubDbEntities db;

        public CategoryDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return db.tbl_Category.ToList();
        }

        public tbl_Category GetById(int id)
        {
            return db.tbl_Category.Find(id);
        }

        public void Insert(tbl_Category obj)
        {
            db.tbl_Category.Add(obj);
            Save();
        }

        public void Delete(int id)
        {
            db.tbl_Category.Remove(GetById(id));
            Save();
        }

        public void Update(tbl_Category obj)
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
