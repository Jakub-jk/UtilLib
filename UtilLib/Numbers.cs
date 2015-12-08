using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilLib
{
    public class Numbers
    {
        #region Converters
        #region Data
        public enum DataUnit
        {
            B,
            KiB,
            //kB,
            MiB,
            //MB,
            GiB,
            //GB,
            TiB,
            //TB,
            PiB,
            //PB,
            EiB,
            //EB,
            ZiB,
            //ZB,
            YiB,
            //YB
        }
        private static CustomArray<double> DataUnits = new CustomArray<double>()
        {
            new CustomArrayObject<double>("B", 1),
            new CustomArrayObject<double>("KiB", 1024),
            new CustomArrayObject<double>("MiB", Math.Pow(2, 20)),
            new CustomArrayObject<double>("GiB", Math.Pow(2, 30)),
            new CustomArrayObject<double>("TiB", Math.Pow(2, 40)),
            new CustomArrayObject<double>("PiB", Math.Pow(2, 50)),
            new CustomArrayObject<double>("EiB", Math.Pow(2, 60)),
            new CustomArrayObject<double>("ZiB", Math.Pow(2, 70)),
            new CustomArrayObject<double>("YiB", Math.Pow(2, 80))
        };
        public static double ToDataUnit(double number, DataUnit fromunit, DataUnit tounit)
        {
            double from = number * Convert.ToDouble(DataUnits[fromunit.ToString()]);
            double to = Convert.ToDouble(DataUnits[tounit.ToString()]);
            //System.Windows.Forms.MessageBox.Show(fromunit.ToString());
            return (from / to);
        }
        public static string ToDataUnitWithUnit(double number, DataUnit fromunit, DataUnit tounit)
        {
            double from = 0;
            from = number * ((double)DataUnits[fromunit.ToString()]);
            return string.Format("{0} {1}", (from / (double)DataUnits[tounit.ToString()]), tounit.ToString());
        }

        public static string ToBiggestDataUnit(double number, DataUnit fromunit)
        {
            try {
                double from = ToDataUnit(number, fromunit, DataUnit.B);
                for (int i = 0; i < DataUnits.Count; i++)
                {
                    double Value = Convert.ToDouble((DataUnits.ReverseAndClone())[i].Value);
                    string Key = (DataUnits.ReverseAndClone())[i].Key.ToString();
                    if (from >= Value)
                        return string.Format("{0} {1}", Math.Round((from / Value), 2), Key);
                    else
                        continue;
                }
                return "Error!"; }
            catch (Exception e) { System.Windows.Forms.MessageBox.Show(e.ToString()); return "Error!"; }
        }

        public async static Task<string> ToBiggestDataUnitAsync(double number, DataUnit fromunit)
        {
            try
            {
                double from = ToDataUnit(number, fromunit, DataUnit.B);
                for (int i = 0; i < DataUnits.Count; i++)
                {
                    double Value = Convert.ToDouble((DataUnits.ReverseAndClone())[i].Value);
                    string Key = (DataUnits.ReverseAndClone())[i].Key.ToString();
                    if (from >= Value)
                        return string.Format("{0} {1}", Math.Round((from / Value), 2), Key);
                    else
                        continue;
                }
                return "Error!";
            }
            catch (Exception e) { System.Windows.Forms.MessageBox.Show(e.ToString()); return "Error!"; }
        }
        #endregion

        #region Distance
        public enum DistanceUnit
        {
            m,
            km,
            dm,
            cm,
            mm,
            µm,
            nm,
            inch,
            ft,
            yd,
            mi,
            nmi
        }
        private static CustomArray<double> DistanceUnits = new CustomArray<double>()
        {
            new CustomArrayObject<double>("m", 1),
            new CustomArrayObject<double>("km", 0.001),
            new CustomArrayObject<double>("dm", 10),
            new CustomArrayObject<double>("cm", 100),
            new CustomArrayObject<double>("mm", 1000),
            new CustomArrayObject<double>("µm", 1000000),
            new CustomArrayObject<double>("nm", 1000000000),
            new CustomArrayObject<double>("inch", 39.37008),
            new CustomArrayObject<double>("ft", 3.28084),
            new CustomArrayObject<double>("yd", 1.093),
            new CustomArrayObject<double>("mi", 0.000621),
            new CustomArrayObject<double>("nmi", 0.00054)
        };
        public static double ToDistanceUnit(double number, DistanceUnit fromunit, DistanceUnit tounit)
        {
            double from = number * Convert.ToDouble(DistanceUnits[fromunit.ToString()]);
            double to = Convert.ToDouble(DistanceUnits[tounit.ToString()]);
            //System.Windows.Forms.MessageBox.Show(fromunit.ToString());
            return (from / to);
        }
        public static string ToDistanceUnitWithUnit(double number, DistanceUnit fromunit, DistanceUnit tounit)
        {
            double from = 0;
            from = number * ((double)DistanceUnits[fromunit.ToString()]);
            return string.Format("{0} {1}", (from / (double)DistanceUnits[tounit.ToString()]), tounit.ToString());
        }

        public static string ToBiggestDistanceUnit(double number, DistanceUnit fromunit)
        {
            try
            {
                double from = ToDistanceUnit(number, fromunit, DistanceUnit.m);
                for (int i = 0; i < DistanceUnits.Count; i++)
                {
                    double Value = Convert.ToDouble((DistanceUnits.ReverseAndClone())[i].Value);
                    string Key = (DistanceUnits.ReverseAndClone())[i].Key.ToString();
                    if (from >= Value)
                        return string.Format("{0} {1}", Math.Round((from / Value), 2), Key);
                    else
                        continue;
                }
                return "Error!";
            }
            catch (Exception e) { System.Windows.Forms.MessageBox.Show(e.ToString()); return "Error!"; }
        }

        public async static Task<string> ToBiggestDistanceUnitAsync(double number, DistanceUnit fromunit)
        {
            try
            {
                double from = ToDistanceUnit(number, fromunit, DistanceUnit.m);
                for (int i = 0; i < DistanceUnits.Count; i++)
                {
                    double Value = Convert.ToDouble((DistanceUnits.ReverseAndClone())[i].Value);
                    string Key = (DistanceUnits.ReverseAndClone())[i].Key.ToString();
                    if (from >= Value)
                        return string.Format("{0} {1}", Math.Round((from / Value), 2), Key);
                    else
                        continue;
                }
                return "Error!";
            }
            catch (Exception e) { System.Windows.Forms.MessageBox.Show(e.ToString()); return "Error!"; }
        }
        #endregion

        #region Weight
        public enum WeightUnit
        {

        }

        
        public static double NWD(double a, double b)
        {
            double w;
            while (b != 0)
            {
                w = a % b;
                a = b;
                b = w;
            }
            return a;
        }

        public static int NWD(int a, int b)
        {
            int w;
            while (b != 0)
            {
                w = a % b;
                a = b;
                b = w;
            }
            return a;
        }

        public static double ND(double a)
        {
            double nd = 0;
            for (double d = 1; d < a; d++)
            {
                if (a % d == 0)
                    nd = d;
            }
            return nd;
        }

        public static int ND(int a)
        {
            int nd = 0;
            for (int d = 1; d < a; d++)
            {
                if (a % d == 0)
                    nd = d;
            }
            return nd;
        }
        #endregion
        #endregion

        /// <summary>
        /// Returns <see cref="System.TimeSpan"/> as formatted text
        /// </summary>
        /// <param name="ts">TimeSpan to format as <see cref="string"/>.</param>
        /// <returns></returns>
        public static string GetTimeString(TimeSpan ts)
        {
            string time = null;
            string[] tsa = new string[3];

            if (ts.Seconds < 10)
                tsa[2] = string.Format("0{0}", ts.Seconds);
            else
                tsa[2] = ts.Seconds.ToString();

            if (ts.Minutes < 10)
                tsa[1] = string.Format("0{0}", ts.Minutes);
            else
                tsa[1] = ts.Minutes.ToString();

            if (ts.Hours < 10)
                tsa[0] = string.Format("0{0}", ts.Hours);
            else
                tsa[0] = ts.Hours.ToString();

            time = string.Format("{0}:{1}:{2}", tsa[0], tsa[1], tsa[2]);

            return time;
        }

        public static string GetTimeString(TimeSpan ts_actual, TimeSpan ts_length)
        {
            return string.Format("{0}/{1}", GetTimeString(ts_actual), GetTimeString(ts_length));
        }

        public static List<T> GetValuesBetween<T>(T start, T end, double step, bool includeStartEnd=false)
        {
            List<T> numbers = new List<T>();
            if (includeStartEnd)
            {
                for (double d = Convert.ToDouble(start); d <= Convert.ToDouble(end); d += step)
                {
                    numbers.Add((T)Convert.ChangeType(d, typeof(T)));
                }
            }
            else
            {
                for (double d = Convert.ToDouble(start) + step; d < Convert.ToDouble(end); d += step)
                {
                    numbers.Add((T)Convert.ChangeType(d, typeof(T)));
                }
            }
            return numbers;
        }

        public static List<T> AddManyTimes<T>(List<T> list, T toAdd, int times)
        {
            List<T> tmp = list;
            for (int i = 0; i < times; i++)
                tmp.Add(toAdd);
            return tmp;
        }
    }
}
