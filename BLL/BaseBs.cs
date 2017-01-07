using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace BLL
{
    public class BaseBs
    {
        public CategoryBs categoryBs { get; set; }
        public UrlBs urlBs { get; set; }
        public UserBs userBs { get; set; }

        public BaseBs()
        {
            categoryBs = new CategoryBs();
            urlBs = new UrlBs();
            userBs = new UserBs();
        }
    }

}
