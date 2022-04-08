using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        OnlineShopEntities db = new OnlineShopEntities();
        // Get : Home
        public ActionResult Index()
        {
            ViewBag.LaptopProduct = db.Products.Where(x => x.Category.Name.Equals("Laptop")).ToList();
            ViewBag.CameraProduct = db.Products.Where(x => x.Category.Name.Equals("Camera")).ToList();
            ViewBag.GamePadProduct = db.Products.Where(x => x.Category.Name.Equals("GamePad")).ToList();
            ViewBag.ElectronicsProduct = db.Products.Where(x => x.Category.Name.Equals("Phones")).ToList();
            ViewBag.Slider = db.genMainSliders.ToList();
            ViewBag.PromoRight = db.genPromoRights.ToList();
            this.GetDefaultData();
            return View();
        }
    }
}