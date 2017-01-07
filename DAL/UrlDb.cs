using BOL;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class UrlDb
    {
        private LinkHubDbEntities db;

        public UrlDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return db.tbl_Url.ToList();
        }

        public tbl_Url GetById(int id)
        {
            return db.tbl_Url.Find(id);
        }

        public void Insert(tbl_Url obj)
        {
            db.tbl_Url.Add(obj);
            Save();
        }

        public void Delete(int id)
        {
            db.tbl_Url.Remove(GetById(id));
            Save();
        }

        public void Update(tbl_Url obj)
        {
            db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }

        private void Save()
        {
            db.SaveChanges();
        }

    }
}
