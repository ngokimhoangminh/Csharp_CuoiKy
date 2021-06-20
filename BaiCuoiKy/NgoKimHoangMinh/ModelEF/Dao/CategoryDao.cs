using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class CategoryDao
    {
        private HoangMinhContext db;
        public CategoryDao()
        {
            db = new HoangMinhContext();
        }
        public List<CategoryProduct> ListAll()
        {
            return db.CategoryProduct.ToList();
        }
        public IEnumerable<CategoryProduct> ListWhereAll(string keySearch, int page, int pagesize)
        {
            IQueryable<CategoryProduct> model = db.CategoryProduct;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.category_name.Contains(keySearch));
            }

            return model.OrderBy(x => x.category_name).ToPagedList(page, pagesize);
        }
        public bool FindName(string categoryname)
        {
            return db.CategoryProduct.Any(x => x.category_name == categoryname);
        }
        public string Insert(CategoryProduct entityCategory)
        {
            db.CategoryProduct.Add(entityCategory);
            db.SaveChanges();
            return entityCategory.category_name;
        }
        public CategoryProduct FindId(System.Int32 category_id)
        {
            return db.CategoryProduct.Find(category_id);
        }
        public string Update(CategoryProduct entityCategory)
        {
            var category = FindId(entityCategory.category_id);
            if (category != null)
            {
                category.category_name = entityCategory.category_name;
                category.category_des = entityCategory.category_des;
                category.category_status = entityCategory.category_status;

            }
            db.SaveChanges();
            return entityCategory.category_name;
        }
        public bool Delete(System.Int32 id)
        {
            try
            {
                var category = db.CategoryProduct.Find(id);
                db.CategoryProduct.Remove(category);
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
