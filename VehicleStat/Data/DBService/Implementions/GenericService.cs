using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VehicleStat.Data.DBModel;

namespace Data.DBService.Implementions
{
    class GenericService<T>
    {
        protected static vehicle_dbEntities db = new vehicle_dbEntities();

        public static void Insert(T entity)
        {
            // entity.
        }

        public static void Update(T entity)
        {
            // entity.
        }

        public static void Delete(T entity)
        {
            // entity.
        }
    }
}
