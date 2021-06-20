using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class ProductDetailDao
    {
        private HoangMinhContext db;
        public ProductDetailDao()
        {
            db = new HoangMinhContext();
        }
        public List<Product> ListWhereAll(System.Int32 product_id)
        {
            return db.Product.Where(x => x.product_id == product_id).ToList();
        }
       
    }
}
