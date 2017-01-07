using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    public class UrlController : BaseUserController
    {
        // GET: User/Url
        public ActionResult Index()
        {            
            InitializeSelects();
            return View();
        }

        [NonAction]
        private void InitializeSelects()
        {
            var categories = objBs.categoryBs.GetAll();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "CategoryName");
            //ViewBag.UserId = new SelectList(objBs.userBs.GetAll(), "UserEmail", "UserId");
        }

        [HttpPost]
        public ActionResult Create(tbl_Url obj)
        {
            try
            {
                obj.IsApproved = "P";
                obj.UserId = objBs.userBs.GetAll().Where(x => x.UserEmail.Equals(User.Identity.Name)).FirstOrDefault().UserId;

                if (ModelState.IsValid)
                {
                    objBs.urlBs.Insert(obj);
                    TempData["Msg"] = "Created successfully.";       
                }
                InitializeSelects();
                return View("Index");
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Submission failed. " + e.Message;
                return View(obj);
            }
        }
    }
}