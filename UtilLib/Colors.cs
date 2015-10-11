using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UtilLib
{
    public class Colors
    {
        public static Color fromHex(string hex)
        {
            try
            {
                int tmpRed = 0;
                int tmpGreen = 0;
                int tmpBlue = 0;
                if (hex.StartsWith("#"))
                    hex = hex.Substring(1);

                tmpRed = Convert.ToInt32(hex.Substring(0, 2), 16);
                if (hex.Length >= 4)
                {
                    tmpGreen = Convert.ToInt32(hex.Substring(2, 2), 16);
                    if (hex.Length >= 6)
                    {
                        tmpBlue = Convert.ToInt32(hex.Substring(4, 2), 16);
                    }
                }

                //Set the Color Label
                return Color.FromArgb(255, tmpRed, tmpGreen, tmpBlue);
            }
            catch (Exception) { return Color.Transparent; }
        }

        public static string toHex(Color color)
        {
            char[] hexDigits = {
         '0', '1', '2', '3', '4', '5', '6', '7',
         '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            byte[] bytes = new byte[3];
            bytes[0] = color.R;
            bytes[1] = color.G;
            bytes[2] = color.B;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }

        public static Graphics getColorGraphic(Color c)
        {
            Bitmap b = new Bitmap(10, 10);
            Graphics g = Graphics.FromImage(b);
            g.Clear(c);
            return g;
        }

        static public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);

            return bmp;
        }
    }
}
