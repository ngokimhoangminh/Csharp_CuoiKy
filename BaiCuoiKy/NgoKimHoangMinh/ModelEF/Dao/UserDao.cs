using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.Dao
{
    public class UserDao
    {
        private HoangMinhContext db;
        public UserDao()
        {
            db = new HoangMinhContext();
        }
        public int login(string username, string password)
        {
            var result = db.UserAccount.SingleOrDefault(x => x.UserName.Contains(username) && x.PassWord.Contains(password) && x.Status.Contains("Active"));
            if (result == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public IEnumerable<UserAccount> ListWhereAll(string keySearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccount;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.UserName.Contains(keySearch));
            }

            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
        public bool Find(string UserName)
        {
            return db.UserAccount.Any(x => x.UserName == UserName);
        }
        public UserAccount FindId(System.Int32 admin_id)
        {
            return db.UserAccount.Find(admin_id);
        }
        public string Insert(UserAccount entityUser)
        {
            //var user = FindId(entityUser.admin_id);
            db.UserAccount.Add(entityUser);
            db.SaveChanges();
            return entityUser.UserName;
        }
        public string Update(UserAccount entityUser)
        {
            var user = FindId(entityUser.ID);
            if (user != null)
            {
                user.UserName = entityUser.UserName;
                if (!string.IsNullOrEmpty(entityUser.PassWord))
                {
                    user.PassWord = entityUser.PassWord;
                }
                user.Status = entityUser.Status;
            }
            db.SaveChanges();
            return entityUser.UserName;
        }
        public bool Delete(System.Int32 admin_id)
        {
            try
            {
                var user = db.UserAccount.Find(admin_id);
                db.UserAccount.Remove(user);
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
