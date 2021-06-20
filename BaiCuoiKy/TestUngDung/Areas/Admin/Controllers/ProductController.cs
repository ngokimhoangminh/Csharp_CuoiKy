using ModelEF.Dao;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product

        HoangMinhContext db = new HoangMinhContext();
        public ActionResult Index(string searchString)
        {
            var product = new ProductDao();
            var model = product.ListWhereAll(searchString);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        public void setViewBag(int? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.category_id = new SelectList(dao.ListAll(), "category_id", "category_name", selectedID);
        }
    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product sp, HttpPostedFileBase product_image)
        {


            if (product_image != null && product_image.ContentLength > 0)
            {
                //int id = int.Parse(db.Product.ToList().Last().product_id.ToString());

                string _FileName = Path.GetFileName(product_image.FileName);
                //int index = Path.GetFileName(product_image.FileName).IndexOf('.');
                //_FileName = "sp" + id.ToString() + "." + Path.GetFileName(product_image.FileName).Substring(index + 1);

                string _path = Path.Combine(Server.MapPath("~/Upload/sanpham/" + _FileName));
                product_image.SaveAs(_path);

                sp.product_image = _FileName;

            }

            if (ModelState.IsValid)
            {
                db.Product.Add(sp);
                db.SaveChanges();
                SetAlert("Thêm Sản Phẩm Thành Công", "success");
                return RedirectToAction("Index");
            }
            //setViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(System.Int32 id)
        {
            var product = new ProductDao();
            var result = product.FindId(id);
            setViewBag(result.category_id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product sp, HttpPostedFileBase product_image)
        {
            Product unv = db.Product.FirstOrDefault(x => x.product_id == sp.product_id);

            if (unv != null)
            {
                unv.category_id = sp.category_id;
                unv.product_name = sp.product_name;
                unv.product_unicost = sp.product_unicost;
                unv.product_quantity = sp.product_quantity;
                unv.product_size = sp.product_size;
                unv.product_des = sp.product_des;
                unv.product_status = sp.product_status;
                if (product_image != null && product_image.ContentLength > 0)
                {
                    int id = sp.product_id;

                    string _FileName = "";
                    int index = Path.GetFileName(product_image.FileName).IndexOf('.');
                    _FileName = "udsp" + id.ToString() + "." + Path.GetFileName(product_image.FileName).Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Upload/sanpham/" + _FileName));
                    product_image.SaveAs(_path);
                    unv.product_image = _FileName;
                }
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                SetAlert("Cập Nhật Sản Phẩm Thành Công", "success");
                return RedirectToAction("Index");
            }
            //setViewBag(sp.category_id);
            return View();
        }
        public JsonResult Delete(System.Int32 id)
        {

            var product = new ProductDao();
            bool re = product.Delete(id);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detail(System.Int32 id)
        {
            var product_detail = new ProductDetailDao();
            var model = product_detail.ListWhereAll(id);
            return View(model);
        }
    }
}