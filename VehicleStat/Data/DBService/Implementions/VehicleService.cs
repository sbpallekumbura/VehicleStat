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
    class VehicleService:GenericService<tbl_emission_test>
    {
        internal static tbl_emission_test GetVehicleByRegistrationNumber(string p)
        {
            try
            {
                tbl_emission_test _tbl_emission_test= db.tbl_emission_test.Where(v => v.registration_no.Trim() == p.Trim()).SingleOrDefault();
                return _tbl_emission_test;
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return null;
            }
        }

        internal static Util.GUI.PagingCollection<tbl_emission_test> GetSearchedVehicleListByPage(int page, string _searchText)
        {
            PagingCollection<tbl_emission_test> pager = new PagingCollection<tbl_emission_test>();
            int pagesize = pager.PageSize;
            int offset = pager.PageSize * (page - 1);

            List<tbl_emission_test> _tbl_emission_test=null;

            _tbl_emission_test = db.tbl_emission_test.Where(v => v.registration_no.Trim() == _searchText.Trim()).ToList();

            pager.Collection = _tbl_emission_test.Skip(offset).Take(pagesize).ToList();
            pager.TotalCount = _tbl_emission_test.Count();
            pager.CurrentPage = page;

            return pager;
        }
    }
}
