using Data.DBService.Implementions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.GUI;
using VehicleStat.Data.DBModel;
using Xceed.Wpf.Toolkit;

namespace VehicleStat.Data.DBService.Implementions
{
    class VehicleStatService : GenericService<tbl_search_key>
    {
        internal static KeyValuePair<string, Nullable<int>>[] GetSearchKeyDetails(string k, int y)
        {
            try
            {
                List<tbl_search_key> searchList = db.tbl_search_key.Where(v => v.key.Trim() == k.Trim() && v.year==y).ToList(); 
                KeyValuePair<string, Nullable<int>>[] searchDetails = searchList.AsEnumerable().Select(o => new KeyValuePair<string, Nullable<int>>(o.category, o.no_vehicles)).ToArray();
                return searchDetails;                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return null;
            }
        }

        internal static List<tbl_search_key> GetSearchKeyDetailsAsList(string k, int y)
        {
            try
            {
                List<tbl_search_key> searchList = db.tbl_search_key.Where(v => v.key.Trim() == k.Trim() && v.year == y).ToList();
                return searchList;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return null;
            }
        }

        internal static List<tbl_search_key> GetSearchKeyDetailsAsListAll(string k)
        {
            try
            {
                List<tbl_search_key> searchList = db.tbl_search_key.Where(v => v.key.Trim() == k.Trim()).ToList();
                return searchList;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return null;
            }
        }

        internal static List<tbl_search_key> GetSearchKeyDetailsByCategory(string k)
        {
            try
            {
                List<tbl_search_key> searchList = db.tbl_search_key.Where(v => v.category.Trim() == k.Trim()).ToList();
                return searchList;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return null;
            }
        }

        internal static Util.GUI.PagingCollection<tbl_search_key> GetKeyIndexListByPage(int page)
        {
            PagingCollection<tbl_search_key> pager = new PagingCollection<tbl_search_key>();
            int pagesize = pager.PageSize;
            int offset = pager.PageSize * (page - 1);

            List<tbl_search_key> _tbl_search_key_List= null;

            // _tbl_emission_test = db.tbl_emission_test.Where(v => v.registration_no.Trim() == _searchText.Trim()).ToList();
            _tbl_search_key_List = db.tbl_search_key.ToList();

            pager.Collection = _tbl_search_key_List.Skip(offset).Take(pagesize).ToList();
            pager.TotalCount = _tbl_search_key_List.Count();
            pager.CurrentPage = page;

            return pager;
        }
    }
}
