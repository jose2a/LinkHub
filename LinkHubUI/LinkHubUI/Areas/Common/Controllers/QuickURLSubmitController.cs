using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    public class QuickURLSubmitController : BaseCommonController
    {
        // GET: Common/QuickURLSubmit
        public ActionResult Index()
        {
            InitializeSelects();
            return View();
        }

        private void InitializeSelects()
        {
            ViewBag.CategoryId = new SelectList(objBs.categoryBs.GetAll(), "CategoryId", "CategoryName");
        }

        public ActionResult Create(QuickURLSubmitModel myQuickUrl)
        {
            try
            {
                ModelState.Remove("MyUser.Password");
                ModelState.Remove("MyUser.ConfirmPassword");
                ModelState.Remove("MyUser.UrlDesc");

                if (ModelState.IsValid)
                {
                    objBs.InsertQuickUrl(myQuickUrl);
                    TempData["Msg"] = "Created successfully.";
                }
                InitializeSelects();
                return View("Index");
            }
            catch (Exception e)
            {

                TempData["Msg"] = "Create failed. " + e.Message;
                return View("Index");
            }
        }
    }
}