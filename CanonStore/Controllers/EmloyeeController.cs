using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CanonStore.Commom;
using CanonStore.Models;

namespace CanonStore.Controllers
{
    public class EmloyeeController : Controller
    {
        trangbaoduy2_OnlineCanonStoreEntities ctx = new trangbaoduy2_OnlineCanonStoreEntities();
        // GET: Emloyee
        public ActionResult Index()
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    List<Emloyee> emloyees = ctx.Emloyees.ToList();
                    return View(emloyees);
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");
        }
        
        public ActionResult Create()
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    Emloyee emloyee = new Emloyee();

                    return View(emloyee);
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public ActionResult Create(Emloyee emloyee)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        if (emloyee.ImageUpload != null)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(emloyee.ImageUpload.FileName);
                            string extension = Path.GetExtension(emloyee.ImageUpload.FileName);
                            emloyee.DateCreated = DateTime.Now.Date;
                            emloyee.Image = "" + emloyee.Name + extension;
                            emloyee.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), emloyee.Name + extension));
                        }
                        else
                        {
                            emloyee.Image = "Avatar.png";
                        }
                        Password EncryptData = new Password();

                        emloyee.Password = EncryptData.Encode(emloyee.Password);

                        ctx.Emloyees.Add(emloyee);
                        ctx.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Create");
                    }
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Detail(int id)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    Emloyee emloyee = ctx.Emloyees.Where(c => c.Id == id).SingleOrDefault();
                    return View(emloyee);
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Edit(int id)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    Emloyee emloyee = ctx.Emloyees.Where(c => c.Id == id).SingleOrDefault();


                    return View(emloyee);
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");

        }
        [HttpPost]
        public ActionResult Edit(Emloyee emloyee)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    Emloyee oldEmloyee = ctx.Emloyees.Where(c => c.Id == emloyee.Id).SingleOrDefault();

                    oldEmloyee.Name = emloyee.Name;
                    oldEmloyee.Phone = emloyee.Phone;
                    //oldCustomer.DayOfBirth = customer.DayOfBirth;

                    if (emloyee.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(emloyee.ImageUpload.FileName);
                        string extension = Path.GetExtension(emloyee.ImageUpload.FileName);
                        fileName += extension;
                        emloyee.Image = "" + oldEmloyee.Name + extension;
                        emloyee.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), oldEmloyee.Name + extension));
                        oldEmloyee.Image = emloyee.Image;
                    }


                    ctx.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");
        }
        public ActionResult Delete(int id)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    Emloyee emloyee = ctx.Emloyees.Where(c => c.Id == id).SingleOrDefault();

                    return View(emloyee);
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult DeleteConfirm(int id)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    Emloyee emloyee1 = ctx.Emloyees.Where(c => c.Id == id).SingleOrDefault();

                    ctx.Emloyees.Remove(emloyee1);
                    ctx.SaveChanges();
                    //redirect view
                    return RedirectToAction("Index");

                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");
        }
    }
}