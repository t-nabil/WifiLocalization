using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WifiLocalization
{
    public class LocationModel
    {
        public LocationModel()
        {
            XValue = new Double[] { };
            YValue = new Double[] { };
            RSSValueList = new List<Double[]>();
        }
        public LocationModel(LocationModel l)
        {
            XValue = l.XValue;
            YValue = l.YValue;
            RSSValueList = Copy(l.RSSValueList);
        }
        public Double[] XValue { get; set; }
        public Double[] YValue { get; set; }
        public List<Double[]> RSSValueList { get; set; }
        //public Double SValue { get { return Math.Sqrt(Math.Pow(XValue, 2) + Math.Pow(YValue, 2)); } }
        public void DisplayInfo()
        {
            Console.WriteLine(String.Format("x={0}, y={1}", this.XValue, this.YValue));
        }
        private List<Double[]> Copy(List<Double[]> l)
        {
            List<Double[]> list = new List<double[]>();

            foreach (Double[] item in l)
            {
                list.Add(item);
            }
            return list;

        }

    }
}
