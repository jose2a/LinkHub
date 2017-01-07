using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BaseCommonController : Controller
    {
        protected CommonBs objBs;

        public BaseCommonController()
        {
            objBs = new CommonBs();
        }
    }
}