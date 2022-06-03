using CanonStore.Commom;
using CanonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CanonStore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmloyeeCheck emloyeeCheck)
        {
            try
            {
                using (trangbaoduy2_OnlineCanonStoreEntities db = new trangbaoduy2_OnlineCanonStoreEntities())
                {
                    Password EncryptData = new Password();

                    emloyeeCheck.Password = EncryptData.Encode(emloyeeCheck.Password);
                    var obj = db.Emloyees.Where(a => a.UserName == emloyeeCheck.UserName && a.Password == emloyeeCheck.Password).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["EmloyeeId"] = obj.Id.ToString();
                        Session["EmloyeeUserName"] = obj.UserName.ToString();
                        Session["EmloyeeName"] = obj.Name.ToString();
                        //ViewBag.EmloyeeName = (Emloyees.Name)HttpContext.Session["EmloyeeId"];
                        //ViewBag.EmloyeeName = HttpContext.Session.SessionID;

                        return RedirectToAction("Index","Products");
                    }
                    else 
                    {
                        return View();
                    }
                }
               
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }
    }
}