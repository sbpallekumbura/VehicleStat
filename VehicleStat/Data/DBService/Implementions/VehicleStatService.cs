using Data.DBService.Implementions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
