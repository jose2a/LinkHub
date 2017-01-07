using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(tbl_Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.categoryBs.Insert(category);
                    TempData["Msg"] = "Category created successfully.";
                    return RedirectToAction("Index");
                }
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Creating category failed!. " + e.Message;
                return View(category);
            }
        }
    }
}