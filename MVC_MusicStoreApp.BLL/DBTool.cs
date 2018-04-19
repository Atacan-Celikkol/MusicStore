using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MVC_MusicStoreApp.DAL;

namespace MVC_MusicStoreApp.BLL
{
    class DBTool
    {

        //Singleton Pattern
        static DbContext _dbInstance;
        public static DbContext DbInstance
        {
            get
            {
                if (_dbInstance==null)
                {
                    _dbInstance = new MusicStoreEntities();
                }

                return _dbInstance;
            }
         
        }
    }
}
