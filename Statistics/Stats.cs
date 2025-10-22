using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Statistics
{
    public class Stats
    {
        public List<double> Numbers { get; set; }


        public Stats()
        {
            Numbers = new List<double>();
        }

        public bool GetNumbers(string text)
        {
            Numbers.Clear();
            if (string.IsNullOrWhiteSpace(text)) return false;

            string[] textNumbers = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            CultureInfo cs = CultureInfo.GetCultureInfo("cs-CZ");  
            CultureInfo inv = CultureInfo.InvariantCulture;         

            for (int i = 0; i < textNumbers.Length; i++)
            {
                double value;
                if (double.TryParse(textNumbers[i], NumberStyles.Float, cs, out value) ||
                    double.TryParse(textNumbers[i], NumberStyles.Float, inv, out value))
                {
                    Numbers.Add(value);
                }
                else
                {
                    return false; 
                }
            }

            return true;
        }

        public double Sum() { return Numbers.Sum(); }
        public double SmallestNumber() { return Numbers.Min(); }
        public double BiggestNumber() { return Numbers.Max(); }
        public double Avg() { return Numbers.Average(); }
        public string SortedAsc()
        {
            Numbers.Sort();
            CultureInfo culture = CultureInfo.GetCultureInfo("cs-CZ");
            string result = "";

            for (int i = 0; i < Numbers.Count; i++)
            {
                if (i > 0) result += " ";
                result += Numbers[i].ToString(culture);
            }

            return result;
        }
        public string SortedDesc()
        {
            Numbers.Sort();
            Numbers.Reverse();

            CultureInfo culture = CultureInfo.GetCultureInfo("cs-CZ");
            string result = "";

            for (int i = 0; i < Numbers.Count; i++)
            {
                if (i > 0) result += " ";
                result += Numbers[i].ToString(culture);
            }

            return result;
        }




    }

}


