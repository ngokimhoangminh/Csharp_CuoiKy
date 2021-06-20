using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
   public class CustomerDao
    {
        private HoangMinhContext db;
        public CustomerDao()
        {
            db = new HoangMinhContext();
        }
        public IEnumerable<Customer> ListWhereAll(string keySearch, int page, int pagesize)
        {
            IQueryable<Customer> model = db.Customer;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.customer_name.Contains(keySearch));
            }

            return model.OrderBy(x => x.customer_name).ToPagedList(page, pagesize);
        }
    }
}
