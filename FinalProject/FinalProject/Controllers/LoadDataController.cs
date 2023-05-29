using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
namespace FinalProject.Controllers
{
    public static class LoadDataController 
    {
        static OnlineShopEntities db = new OnlineShopEntities();
        // GET: LoadData
        public static List<OrderDetail> GetDefaultData(this ControllerBase controller)
        {
            if (TempShopData.items == null)
            {
                TempShopData.items = new List<OrderDetail>();
            }
            var data = TempShopData.items.ToList();

            controller.ViewBag.cartBox = data.Count == 0 ? null : data;
            controller.ViewBag.NoOfItem = data.Count();
            int? SubTotal = Convert.ToInt32(data.Sum(x => x.TotalAmount));
            controller.ViewBag.Total = SubTotal;

            int Discount = 0;
            controller.ViewBag.SubTotal = SubTotal;
            controller.ViewBag.Discount = Discount;
            controller.ViewBag.TotalAmount = SubTotal - Discount;

            controller.ViewBag.WlItemsNo = db.Wishlists.Where(x => x.CustomerID == TempShopData.UserID).ToList().Count();
            return data;
        }
    }
}