using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WifiLocalization
{
    class Manager : IManager
    {
        #region Manager Class Constructor
        private static Manager _instance;
        public static Manager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Manager();

                return _instance;
            }
        }
        # endregion

        /// <summary>
        /// Uses PropertyModel.Thershold
        /// Takes List<LocationModel(){original,predicted}>
        /// </summary>
        /// <returns>PropertyModel Statistics : Acc%,Avg,Max,Min</returns>
        public PropertyModel GetStatistics(PropertyModel property, Double[] original, Double[] predicted)
        {
            return WifiLocalization.Implement.Instance.Statistics(property, original, predicted);
        }
        /// <summary>
        /// Uses PropertyModel
        /// Takes 1_OnlineReading and OfflineDB
        /// </summary>
        /// <returns>LocationModel :XValue,YValue</returns>

        public Double[] ReadOfflineDB(string xlPath, int xlSheetNum, string xlRangestring)
        {
            Array Data = WifiLocalization.Implement.Instance.ExcelRead(xlPath, xlSheetNum, xlRangestring);
            return Helper.ObjectToDouble(Data);
        }
        public LocationModel GetLocation(DeviceModel user, LocationModel offline)
        {
            return KNearestNeighbor(user, offline);
            // return WKNearestNeighbor(user, offline);
        }
        private LocationModel KNearestNeighbor(DeviceModel user, LocationModel offline)
        {
            return WifiLocalization.Implement.Instance.KNearestNeighbor(user,offline);
        }
        private LocationModel WKNearestNeighbor(DeviceModel user, LocationModel offline)
        {
            return WifiLocalization.Implement.Instance.WKNearestNeighbor();
        }

    }
}
