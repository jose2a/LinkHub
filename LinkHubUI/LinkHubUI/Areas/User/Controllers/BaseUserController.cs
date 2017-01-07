using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    [Authorize(Roles = ("A, U"))]
    public class BaseUserController : Controller
    {
        protected UserAreaBs objBs;

        public BaseUserController()
        {
            objBs = new UserAreaBs();
        }
    }
}