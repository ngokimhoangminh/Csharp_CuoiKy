using ModelEF.Model;
using ModelEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class ProductDao
    {
        private HoangMinhContext db;
        public ProductDao()
        {
            db = new HoangMinhContext();
        }
        public List<Product> ListAll()
        {
            return db.Product.Where(x=>x.product_status==1).ToList();
        }
        public List<ProductModel> ListWhereAll(string keysearch)
        {
            var list_product = from s in db.Product
                               join c in db.CategoryProduct
                               on s.category_id equals c.category_id
                               orderby s.product_quantity, s.product_unicost descending
                               select new ProductModel //tra ve 1 custom class
                               {
                                   product_id = s.product_id,
                                   category_name = c.category_name,
                                   product_name = s.product_name,
                                   product_unicost=s.product_unicost,
                                   product_quantity=s.product_quantity,
                                   product_size=s.product_size,
                                   product_image = s.product_image,
                                   product_des = s.product_des,
                                   product_status = s.product_status
                               };
            var list_product_1 = from s in db.Product
                                 join c in db.CategoryProduct
                                 on s.category_id equals c.category_id
                                 where s.product_name.Contains(keysearch)
                                 orderby s.product_quantity, s.product_unicost descending
                                 select new ProductModel //tra ve 1 custom class
                                 {
                                     product_id = s.product_id,
                                     category_name = c.category_name,
                                     product_name = s.product_name,
                                     product_unicost = s.product_unicost,
                                     product_quantity = s.product_quantity,
                                     product_size = s.product_size,
                                     product_image = s.product_image,
                                     product_des = s.product_des,
                                     product_status = s.product_status
                                 };
            if (!string.IsNullOrEmpty(keysearch))
                return list_product_1.ToList();
            return list_product.ToList();
        }
        public Product FindId(System.Int32 product_id)
        {
            return db.Product.Find(product_id);
        }
        public bool Delete(System.Int32 id)
        {
            try
            {
                var product = db.Product.Find(id);
                db.Product.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
