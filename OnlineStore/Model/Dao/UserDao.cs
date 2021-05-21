using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao
{
    public class UserDao
    {
        OnlineStoreDbContext db = null;
        public static long iduser;
        public UserDao()
        { 
            db = new OnlineStoreDbContext();
        }
        public long Insert(User entity) // ham dung de them moi user vao ban ghi, 
        {
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.IdUser;
            }
        }
        public long getIdUser()
        {
            return iduser;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.IdUser);
                if (!string.IsNullOrEmpty(entity.PassWord))
                {
                    user.PassWord = entity.PassWord;
                }
                user.HoTen = entity.HoTen;
                user.DiaChi = entity.DiaChi;
                user.DienThoai = entity.DienThoai;
                user.GioiTinh = entity.GioiTinh;
                user.Email = entity.Email;
                user.TrangThai = entity.TrangThai;
                db.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        public IEnumerable<User> ListAllPaging(int page,int pageSize)
        {
            return db.Users.OrderByDescending(x=>x.NgayTao).ToPagedList(page,pageSize);
        }
        public User GetByName(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName); // tra ve 1 phan tu duy nhat
        }
        public User ViewDetail(long iduser)
        {
            return db.Users.Find(iduser); // tra ve 1 phan tu duy nhat theo primary key
        }
        public int Login(string userName, String passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName); // kiem tra co ton tai username ko
            if (result == null)
            {
                return 0; // ko ton tai TK
            }
            else
            {
                if (result.TrangThai == false)
                {
                    iduser = result.IdUser;
                    return -1; // Tai khoan user
                }
                else
                {
                    if (result.PassWord == passWord)
                    {
                        iduser= result.IdUser;
                        return 1; //tai khoan admin
                    }
                    else
                        return -2; // sai MK
                }
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public delegate bool MyCompare(User u1, User u2);
        public List<User> Sort(MyCompare cmp)
        {
            var list = db.Users.ToList();
            for(int i = 0; i < list.Count-1; ++i)
            {
                for(int j = i + 1; j < list.Count; ++j)
                {
                    if (cmp(list[i],list[j]))
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
    }
}
