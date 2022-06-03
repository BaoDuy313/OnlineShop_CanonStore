using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using CanonStore.Models;
using ClosedXML.Excel;

namespace CanonStore.Controllers
{
    public class DiscountsController : Controller
    {
        trangbaoduy2_OnlineCanonStoreEntities ctx = new trangbaoduy2_OnlineCanonStoreEntities();
        // GET: Discounts
        public ActionResult Index()
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    List<Discount> discounts = ctx.Discounts.OrderByDescending(d=>d.Date_End).ToList();
                    
                    return View(discounts);
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
                    Discount discount = new Discount();

                    

                    return View(discount);
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");

        }
        [HttpPost]
        public ActionResult Create(Discount discount)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        
                        ctx.Discounts.Add(discount);
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
        public ActionResult Edit(string id)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    Discount discount = ctx.Discounts.Where(d => d.Dis_Code == id).SingleOrDefault();
                    
                    return View(discount);
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");


        }
        [HttpPost]
        public ActionResult Edit(Discount discount)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    try
                    {
                        Discount oldDiscount = ctx.Discounts.Where(d => d.Dis_Code == discount.Dis_Code).SingleOrDefault();

                        oldDiscount.Dis_Code = discount.Dis_Code;
                        oldDiscount.Dis_Description = discount.Dis_Description;
                        oldDiscount.Discount_Value = discount.Discount_Value;
                        if (discount.Date_Start != null)
                        {
                            oldDiscount.Date_Start = discount.Date_Start;
                        }

                        if (discount.Date_End != null)
                        {
                            oldDiscount.Date_End = discount.Date_End;
                        }
                        ctx.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("Edit", discount.Dis_Code);
                    }
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");

        }
        public ActionResult Delete(String id)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {
                    Discount discount = ctx.Discounts.Where(c => c.Dis_Code == id).SingleOrDefault();
                   
                    return View(discount);
                }
                catch
                {
                    return Content("Error");
                }
            }
            return RedirectToAction("Index", "Login");

        }
        [HttpPost]
        public ActionResult DeleteConfirm(Discount discount)
        {
            if (Session["EmloyeeId"] != null)
            {
                try
                {

                    Discount discount1 = ctx.Discounts.Where(c => c.Dis_Code == discount.Dis_Code).SingleOrDefault();
                    //xoa
                    ctx.Discounts.Remove(discount1);
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