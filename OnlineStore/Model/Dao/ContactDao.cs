using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ContactDao
    {
        OnlineStoreDbContext db = null;
        public ContactDao()
        {
            // sua code contacdao truong
            db = new OnlineStoreDbContext();
        }
        public long Insert(GopY_KH contact)
        {
            db.GopY_KH.Add(contact);
            db.SaveChanges();
            return contact.IdGopY;
        }
    }
}
