using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WifiLocalization
{
    public class PropertyModel
    {
        public PropertyModel() { }
        public PropertyModel(PropertyModel p) {
            
            KNN = p.KNN;
            Exponent = p.Exponent;
            Threshold = p.Threshold;
            Accuracy = p.Accuracy;
            Average = p.Average;
            Maximum = p.Maximum;
            Minimum = p.Minimum;
        }
        public int KNN { get; set; }
        public int Exponent { get; set; }
        public Double Threshold { get; set; }
        public Double Accuracy { get; set; }
        public Double Average { get; set; }
        public Double Minimum { get; set; }
        public Double Maximum { get; set; }
        public void DisplayInfo()
        {
            Console.WriteLine(String.Format("KNN={0}, Exp={1}, Thres={2}\nAcc={3}, Avg={4}, Max={5}, Min={6}",
                this.KNN, this.Exponent, this.Threshold, this.Accuracy,this.Average,this.Maximum,this.Minimum));
        }
        
    }
}
