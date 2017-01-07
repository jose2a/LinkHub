using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ApproveUrlsController : BaseAdminController
    {
        // GET: Admin/ApproveUrls
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null) ? "P" : Status;

            var urls = (Status == null)
                ? objBs.urlBs.GetAll().Where(x => x.IsApproved.Equals("P"))
                //? (from u in objBs.urlBs.GetAll() where u.IsApproved.Equals("P") select u)
                : objBs.urlBs.GetAll().Where(x => x.IsApproved.Equals(Status));
            return View(urls);
        }
        public ActionResult Approve(int id)
        {
            try
            {
                var myUrl = objBs.urlBs.GetById(id);
                myUrl.IsApproved = "A";
                objBs.urlBs.Update(myUrl);

                TempData["Msg"] = "Approved succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Approval failed. " + e.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Reject(int id)
        {
            try
            {
                var myUrl = objBs.urlBs.GetById(id);
                myUrl.IsApproved = "R";
                objBs.urlBs.Update(myUrl);

                TempData["Msg"] = "Rejected succesfully.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Rejection failed. " + e.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult ApproveOrRejectAll(List<int> ids, string Status, string CurrentStatus)
        {
            try
            {
                objBs.ApproveOrReject(ids, Status);
                TempData["Msg"] = "Operation successfully.";
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved.Equals(CurrentStatus)).ToList();
                return PartialView("pv_ApproveURLs", urls);
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Operation failed." + e.Message;
                var urls = objBs.urlBs.GetAll().Where(x => x.IsApproved.Equals(CurrentStatus)).ToList();
                return PartialView("pv_ApproveURLs", urls);
            }

        }

    }
}