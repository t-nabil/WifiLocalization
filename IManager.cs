using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiLocalization
{
    interface IManager
    {
        PropertyModel GetStatistics(PropertyModel property, Double[] original, Double[] predicted);
        LocationModel GetLocation(DeviceModel user, LocationModel offline);
        Double[] ReadOfflineDB(string xlPath, int xlSheetNum, string xlRangestring);
        
    }
}
