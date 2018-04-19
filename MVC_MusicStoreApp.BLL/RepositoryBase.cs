using MVC_MusicStoreApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Reflection;

namespace MVC_MusicStoreApp.BLL
{
    //Reflaction
    public class RepositoryBase<A> : IRepositoryBase<A> where A : class
    {
        DbContext _db = DBTool.DbInstance;
        public void Add(A item)
        {
            _db.Set(typeof(A)).Add(item);
            _db.SaveChanges();

        }

        public void Delete(int id)
        {
            _db.Set(typeof(A)).Remove(_db.Set(typeof(A)).Find(id));
            _db.SaveChanges();
        }

        public List<A> SelectAll()
        {
            return _db.Set(typeof(A)).Cast<A>().ToList();
        }

        public A SelectByID(int id)
        {
            //return  _db.Set(typeof(A)).Find(id) as A;
            return (A)_db.Set(typeof(A)).Find(id);
        }

        public void Update(A item)
        {
            //var updated = _db.Set(typeof(A)).Find(item.ID);
            //_db.Entry(updated).CurrentValues.SetValues(item);
            #region Tipi bilinmeyen nesne içerisinde Property arama ve bulma çalışmaları
            PropertyInfo pInfo = null;
            foreach (PropertyInfo property in item.GetType().GetProperties())
            {
                if (property.Name == "ID")
                {
                    pInfo = property;//metoda verilen parametre içerisinde ID diye bir property varmı onu bulur.
                    break;
                }
            } 
            #endregion
            //pInfo.GetValue(item) item nesnesi içerisinde eğer ID property'si var ise değerini döndürmeye yarayan kod satırı
            var updated = _db.Set(typeof(A)).Find(pInfo.GetValue(item));
            _db.Entry(updated).CurrentValues.SetValues(item); 
            //_db.Entry(item).State = EntityState.Modified; EF 6.2.0 ile güncelleme işlemi 
            _db.SaveChanges();
           


        }
    }
}
