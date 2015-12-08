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
        /// <summary>
        /// Checks color as transparent
        /// </summary>
        /// <param name="c">Color to check</param>
        /// <returns>If color is transparent returns true, else - false</returns>
        public static bool IsTransparent(Color c)
        {
            if (c == Color.Transparent)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets <see cref="System.Drawing.Color"/> from HEX.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns>Returns <see cref="System.Drawing.Color"/> that is equivalent to HEX color.</returns>
        public static Color FromHex(string hex)
        {
            try
            {
                int tmpRed = 0;
                int tmpGreen = 0;
                int tmpBlue = 0;
                int tmpAlpha = 255;
                if (hex.StartsWith("#"))
                    hex = hex.Substring(1);
                if (hex.Length < 8)
                {
                    tmpRed = Convert.ToInt32(hex.Substring(0, 2), 16);
                    if (hex.Length >= 4)
                    {
                        tmpGreen = Convert.ToInt32(hex.Substring(2, 2), 16);
                        if (hex.Length >= 6)
                        {
                            tmpBlue = Convert.ToInt32(hex.Substring(4, 2), 16);
                        }
                    }
                }
                else if (hex.Length == 8)
                {
                    tmpAlpha = Convert.ToInt32(hex.Substring(0, 2), 16);
                    tmpRed = Convert.ToInt32(hex.Substring(2, 2), 16);
                    if (hex.Length >= 4)
                    {
                        tmpGreen = Convert.ToInt32(hex.Substring(4, 2), 16);
                        if (hex.Length >= 6)
                        {
                            tmpBlue = Convert.ToInt32(hex.Substring(6, 2), 16);
                        }
                    }
                }

                //Set the Color Label
                return Color.FromArgb(tmpAlpha, tmpRed, tmpGreen, tmpBlue);
            }
            catch (Exception) { return Color.Transparent; }
        }

        /// <summary>
        /// Gets HEX equivalent of color
        /// </summary>
        /// <param name="color">Color to get HEX</param>
        /// <returns>Returns HEX equivalent of given color</returns>
        public static string ToHex(Color color)
        {
            char[] hexDigits = {
         '0', '1', '2', '3', '4', '5', '6', '7',
         '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            byte[] bytes = new byte[4];
            bytes[0] = color.A;
            bytes[1] = color.R;
            bytes[2] = color.B;
            bytes[3] = color.G;
            char[] chars = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int b = bytes[i];
                chars[i * 2] = hexDigits[b >> 4];
                chars[i * 2 + 1] = hexDigits[b & 0xF];
            }
            return new string(chars);
        }

        /// <summary>
        /// Gets <see cref="System.Drawing.Graphics"/> with given background.
        /// </summary>
        /// <param name="c">Returned <see cref="System.Drawing.Graphics"/>'s background.</param>
        /// <returns>Returns <see cref="System.Drawing.Graphics"/> with given background.</returns>
        public static Graphics GetColorGraphic(Color c)
        {
            Bitmap b = new Bitmap(10, 10);
            Graphics g = Graphics.FromImage(b);
            g.Clear(c);
            return g;
        }

        /// <summary>
        /// Scales image.
        /// </summary>
        /// <param name="image">Image to scale</param>
        /// <param name="maxWidth">New width</param>
        /// <param name="maxHeight">New height</param>
        /// <returns>Returns image (<see cref="System.Drawing.Bitmap"/>) with given size.</returns>
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
