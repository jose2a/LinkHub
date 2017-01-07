using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UrlBs
    {
        private UrlDb objDb;

        public UrlBs()
        {
            objDb = new UrlDb();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return objDb.GetAll();
        }

        public tbl_Url GetById(int id)
        {
            return objDb.GetById(id);
        }

        public void Insert(tbl_Url obj)
        {
            objDb.Insert(obj);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(tbl_Url obj)
        {
            objDb.Update(obj);
        }

    }
}

