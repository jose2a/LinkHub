using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoryBs
    {
        private CategoryDb objDb;

        public CategoryBs()
        {
            objDb = new CategoryDb();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return objDb.GetAll();
        }

        public tbl_Category GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(tbl_Category obj)
        {
            objDb.Insert(obj);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(tbl_Category obj)
        {
            objDb.Update(obj);
        }

    }
}

