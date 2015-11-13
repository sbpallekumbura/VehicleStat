using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DBService.Implementions;
using VehicleStat.Data.DBModel;
using System.Windows;
using Util.GUI;

namespace DBService.Implementions
{
    class VehicleService:GenericService<vehicle>
    {
        internal static vehicle GetVehicleByRegistrationNumber(string p)
        {
            try
            {
                vehicle _vehicle= db.vehicles.Where(v => v.registration_no.Trim() == p.Trim()).SingleOrDefault();
                return _vehicle;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return null;
            }
        }

        internal static Util.GUI.PagingCollection<vehicle> GetSearchedVehicleListByPage(int page, string _searchText)
        {
            PagingCollection<vehicle> pager = new PagingCollection<vehicle>();
            int pagesize = pager.PageSize;
            int offset = pager.PageSize * (page - 1);

            List<vehicle> _vehicle;

            _vehicle = db.vehicles.Where(v => v.registration_no.Trim() == _searchText.Trim()).ToList();

            pager.Collection = _vehicle.Skip(offset).Take(pagesize).ToList();
            pager.TotalCount = _vehicle.Count();
            pager.CurrentPage = page;

            return pager;
        }
    }
}
