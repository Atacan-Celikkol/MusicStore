using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MusicStoreApp.BLL
{
    //Class lar ve Interfaceler sadece Public ve Internal olabilir.
    //Classların property ve metodları tüm EB(Erişim Belirleyici) alabilirken Interface öğeleri hiçbirini almaz.Fakat bu interface öğeleri private dır anlamını taşı maz.Interface öğeleri interface ne ise o EB yi üzerine alır.
  public  interface IRepositoryBase<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        List<T> SelectAll();
        T SelectByID(int id);
    }
}
