using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace WifiLocalization
{
    public class Implement
    {
        #region Class Constructor
        private static Implement _instance;
        public static Implement Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Implement();

                return _instance;
            }
        }
        #endregion
        public PropertyModel Statistics(PropertyModel property, Double[] original, Double[] predicted)
        {


            int length = (predicted.Length <= original.Length) ? predicted.Length : original.Length;

            double[] dist = new double[length];

            if (length == 0)
                return null;
            else
            {
                int count = 0;
                for (int i = 0; i < length; i++)
                {
                    dist[i] = Math.Abs(original[i] - predicted[i]);
                    if (dist[i] <= property.Threshold)
                        count++;
                    i++;
                }
                property.Minimum = dist.Min();
                property.Maximum = dist.Max();
                property.Average = dist.Sum() / length;
                property.Accuracy = (double)count * 100 / length;

                return property;

            }

        }
        public DeviceModel KNearestNeighbor(DeviceModel user, LocationModel Offline)
        {
            Dictionary<int, Double> dist = new Dictionary<int, double>();
            List<Double[]> ap = Offline.RSSValueList;
            Double[] us = user.RSSValue;
            int knn = user.Property.KNN;
            int exp = user.Property.Exponent;
            int uNum = us.Length;
            int apNum = ap.Count();
            int locNum = ap[0].Length;
            double sum;
            double invExp = 1 / (double)exp;
             


            for (int j = 0; j < locNum; j++)
            {
                sum = 0;

                for (int i = 0; i < apNum; i++)
                {
                    sum += Math.Pow(us[i] - ap[i][j], exp);

                }

                dist.Add(j, Math.Pow(sum, invExp));
            }

            var results = dist.OrderBy(i => i.Value).Take(knn);

            double x = 0, y = 0;
            foreach (KeyValuePair<int, double> result in results)
            {
                x += Offline.XValue[result.Key];
                y += Offline.YValue[result.Key];

            }
            
            DeviceModel KNNResult = new DeviceModel(user);

            KNNResult.XLocation = x / knn;
            KNNResult.YLocation = y / knn;

            return KNNResult;
        }
        public DeviceModel WKNearestNeighbor() { return null; }
        public Array ExcelRead(string xlPath, int xlSheetNum, string xlRangestring)
        {

            char[] delims = { ':' };
            String[] xlRange = xlRangestring.Split(delims);

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(xlPath);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Sheets[xlSheetNum];

            System.Array readData = (System.Array)xlWorkSheet.get_Range(xlRange[0], xlRange[1]).Value2;

            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            return readData;
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}

