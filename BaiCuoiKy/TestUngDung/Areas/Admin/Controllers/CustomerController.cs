using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var customer = new CustomerDao();
            var model = customer.ListWhereAll(searchString, page, pagesize);
            ViewBag.searchString = searchString;
            return View(model);
        }
    }
}