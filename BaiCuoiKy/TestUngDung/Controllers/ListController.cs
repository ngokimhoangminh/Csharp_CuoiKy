using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Controllers
{
    public class ListController : Controller
    {
        public ActionResult Index()
        {
            var product = new ProductDao();
            var model = product.ListAll();
            return View(model);
        }
        public ActionResult Detail(System.Int32 id)
        {
            var product_detail = new ProductDetailDao();
            var model = product_detail.ListWhereAll(id);
            return View(model);
        }
    }
}