using System;
using System.Drawing;
using System.Collections.Generic;
using System.Reflection;
using System.Globalization;


namespace Dragonfly.Common.Utils
{
    public static class ColorUtils
    {
        private static Dictionary<string, Color> _staticColorMap = null;

        public static IDictionary<string, Color> GetStaticColors()
        {
            if (_staticColorMap == null)
            {
                Dictionary<string, Color> mapColors = new Dictionary<string, Color>();
                foreach (PropertyInfo pi in typeof(Color).GetProperties())
                {
                    if (pi.PropertyType == typeof(Color))
                    {
                        mapColors[pi.Name] = (Color)pi.GetValue(null, null);
                    }
                }
                _staticColorMap = mapColors;
            }
            return _staticColorMap;
        }

        public static Color GetStaticColorFromName(string colorName)
        {
            return GetStaticColors()[colorName];
        }

        public static string ToHexadecimalRgb(Color color)
        {
            return color.ToArgb().ToString("X").Substring(2);
        }

        public static Color FromHexadecimalRgb(string rbgString)
        {
            int rgbValue = int.Parse(rbgString, NumberStyles.HexNumber);
            return Color.FromArgb(rgbValue);
        }

        public static string ToString(Color color)
        {
            return string.Format("[{0}, {1}, {2}, {3}]", color.R, color.G, color.B, color.A);
        }

        public static Color GetRandomColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }

        public static Color GetRandomColor(int seed)
        {
            Random rand = new Random(seed);
            return Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));
        }

        public static uint ToRgb(Color c)
        {
            // Format the value of color - 0x00bbggrr
            return (uint)(((uint)(c.B) << 16) | ((uint)(c.G) << 8) | ((uint)(c.R)));
        }

        public static Color ReduceBrightness(Color c, double amount)
        {
            Hsb hsl = RgbToHsb(c);
            hsl.Brightness -= amount;
            return HsbToRgb(hsl);
        }

        public static Color Darken(Color c)
        {
            Hsb hsl = RgbToHsb(c);
            hsl.Brightness = Math.Max(0, hsl.Brightness - 0.05);
            return HsbToRgb(hsl);
        }

        public static Color Lighten(Color c)
        {
            Hsb hsl = RgbToHsb(c);
            hsl.Brightness = Math.Min(1, hsl.Brightness + 0.05);
            return HsbToRgb(hsl);
        }

        /// <summary> 
        /// Sets the absolute brightness of a colour 
        /// </summary> 
        /// <param name="c">Original colour</param> 
        /// <param name="brightness">The luminance level to impose</param> 
        /// <returns>an adjusted colour</returns> 
        public static Color SetBrightness(Color c, double brightness)
        {
            Hsb hsl = RgbToHsb(c);
            hsl.Brightness = brightness;
            return HsbToRgb(hsl);
        }


        /// <summary> 
        /// Sets the absolute saturation level 
        /// </summary> 
        /// <remarks>Accepted values 0-1</remarks> 
        /// <param name="c">An original colour</param> 
        /// <param name="Saturation">The saturation value to impose</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color SetSaturation(Color c, double Saturation)
        {
            Hsb hsl = RgbToHsb(c);
            hsl.Saturation = Saturation;
            return HsbToRgb(hsl);
        }

        /// <summary> 
        /// Sets the absolute Hue level 
        /// </summary> 
        /// <remarks>Accepted values 0-1</remarks> 
        /// <param name="c">An original colour</param> 
        /// <param name="Hue">The Hue value to impose</param> 
        /// <returns>An adjusted colour</returns> 
        public static Color SetHue(Color c, double Hue)
        {
            Hsb hsl = RgbToHsb(c);
            hsl.Hue = Hue;
            return HsbToRgb(hsl);
        }

        public static Color HsbToRgb(double h, double s, double b)
        {
            return HsbToRgb(new Hsb(h, s, b));
        }

        /// <summary> 
        /// Converts a colour from HSL to RGB 
        /// </summary> 
        /// <remarks>Adapted from the algorithm in Foley and Van-Dam</remarks> 
        /// <param name="hsl">The HSL value</param> 
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <author>Jon Froehlich</author>
        /// <returns>A Color structure containing the equivalent RGB values</returns> 
        public static Color HsbToRgb(Hsb hsb)
        {
            int Max, Mid, Min;
            double q;

            Max = Round(hsb.Brightness * 255);
            Min = Round((1.0 - hsb.Saturation) * (hsb.Brightness / 1.0) * 255);
            q = (double)(Max - Min) / 255;

            if (hsb.Hue >= 0 && hsb.Hue <= (double)1 / 6)
            {
                Mid = Round(((hsb.Hue - 0) * q) * 1530 + Min);
                return Color.FromArgb(Max, Mid, Min);
            }
            else if (hsb.Hue <= (double)1 / 3)
            {
                Mid = Round(-((hsb.Hue - (double)1 / 6) * q) * 1530 + Max);
                return Color.FromArgb(Mid, Max, Min);
            }
            else if (hsb.Hue <= 0.5)
            {
                Mid = Round(((hsb.Hue - (double)1 / 3) * q) * 1530 + Min);
                return Color.FromArgb(Min, Max, Mid);
            }
            else if (hsb.Hue <= (double)2 / 3)
            {
                Mid = Round(-((hsb.Hue - 0.5) * q) * 1530 + Max);
                return Color.FromArgb(Min, Mid, Max);
            }
            else if (hsb.Hue <= (double)5 / 6)
            {
                Mid = Round(((hsb.Hue - (double)2 / 3) * q) * 1530 + Min);
                return Color.FromArgb(Mid, Min, Max);
            }
            else if (hsb.Hue <= 1.0)
            {
                Mid = Round(-((hsb.Hue - (double)5 / 6) * q) * 1530 + Max);
                return Color.FromArgb(Max, Min, Mid);
            }
            else return Color.FromArgb(0, 0, 0);
        }


        /// <summary> 
        /// Converts RGB to HSL 
        /// </summary> 
        /// <remarks>Takes advantage of whats already built in to .NET by using the Color.GetHue, 
        /// Color.GetSaturation and Color.GetBrightness methods</remarks> 
        /// <param name="c">A Color to convert</param> 
        /// <returns>An HSL value</returns> 
        public static Hsb RgbToHsb(Color c)
        {
            Hsb hsb = new Hsb();

            int Max, Min, Diff, Sum;

            //	Of our RGB values, assign the highest value to Max, and the Smallest to Min
            if (c.R > c.G) { Max = c.R; Min = c.G; }
            else { Max = c.G; Min = c.R; }
            if (c.B > Max) Max = c.B;
            else if (c.B < Min) Min = c.B;

            Diff = Max - Min;
            Sum = Max + Min;

            //	Luminance - a.k.a. Brightness - Adobe photoshop uses the logic that the
            //	site VBspeed regards (regarded) as too primitive = superior decides the 
            //	level of brightness.
            hsb.Brightness = (double)Max / 255;

            //	Saturation
            if (Max == 0) hsb.Saturation = 0;	//	Protecting from the impossible operation of division by zero.
            else hsb.Saturation = (double)Diff / Max;	//	The logic of Adobe Photoshops is this simple.

            //	Hue		R is situated at the angel of 360 eller noll degrees; 
            //			G vid 120 degrees
            //			B vid 240 degrees
            double q;
            if (Diff == 0) q = 0; // Protecting from the impossible operation of division by zero.
            else q = (double)60 / Diff;

            if (Max == c.R)
            {
                if (c.G < c.B) hsb.Hue = (double)(360 + q * (c.G - c.B)) / 360;
                else hsb.Hue = (double)(q * (c.G - c.B)) / 360;
            }
            else if (Max == c.G) hsb.Hue = (double)(120 + q * (c.B - c.R)) / 360;
            else if (Max == c.B) hsb.Hue = (double)(240 + q * (c.R - c.G)) / 360;
            else hsb.Hue = 0.0;

            return hsb;
        }


        /// <summary>
        /// Converts RGB to CMYK
        /// </summary>
        /// <param name="c">A color to convert.</param>
        /// <returns>A CMYK object</returns>
        public static Cmyk RgbToCmyk(Color c)
        {
            Cmyk cmyk = new Cmyk();
            double low = 1.0;

            cmyk.Cyan = (double)(255 - c.R) / 255;
            if (low > cmyk.Cyan)
                low = cmyk.Cyan;

            cmyk.Magenta = (double)(255 - c.G) / 255;
            if (low > cmyk.Magenta)
                low = cmyk.Magenta;

            cmyk.Yellow = (double)(255 - c.B) / 255;
            if (low > cmyk.Yellow)
                low = cmyk.Yellow;

            if (low > 0.0)
            {
                cmyk.K = low;
            }

            return cmyk;
        }

        /// <summary>
        /// Converts CMYK to RGB
        /// </summary>
        /// <param name="_cmyk">A color to convert</param>
        /// <returns>A Color object</returns>
        public static Color CmykToRgb(Cmyk cmyk)
        {
            int red, green, blue;

            red = Round(255 - (255 * cmyk.Cyan));
            green = Round(255 - (255 * cmyk.Magenta));
            blue = Round(255 - (255 * cmyk.Yellow));

            return Color.FromArgb(red, green, blue);
        }


        /// <summary>
        /// Custom rounding function.
        /// </summary>
        /// <param name="val">Value to round</param>
        /// <returns>Rounded value</returns>
        private static int Round(double val)
        {
            int ret_val = (int)val;

            int temp = (int)(val * 100);

            if ((temp % 100) >= 50)
                ret_val += 1;

            return ret_val;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <author>Jon Froehlich</author>
        public struct Hsb
        {
            private double _h;
            private double _s;
            private double _b;

            public Hsb(double hue, double sat, double brightness)
            {
                _h = hue;
                _s = sat;
                _b = brightness;
            }

            public double Hue
            {
                get
                {
                    return _h;
                }
                set
                {
                    _h = value;
                    _h = _h > 1 ? 1 : _h < 0 ? 0 : _h;
                }
            }


            public double Saturation
            {
                get
                {
                    return _s;
                }
                set
                {
                    _s = value;
                    _s = _s > 1 ? 1 : _s < 0 ? 0 : _s;
                }
            }


            public double Brightness
            {
                get { return _b; }
                set
                {
                    _b = value;
                    _b = _b > 1 ? 1 : _b < 0 ? 0 : _b;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <author>Jon Froehlich</author>
        public struct Cmyk
        {
            private double _c;
            private double _m;
            private double _y;
            private double _k;

            public double Cyan
            {
                get
                {
                    return _c;
                }
                set
                {
                    _c = value;
                    _c = _c > 1 ? 1 : _c < 0 ? 0 : _c;
                }
            }


            public double Magenta
            {
                get
                {
                    return _m;
                }
                set
                {
                    _m = value;
                    _m = _m > 1 ? 1 : _m < 0 ? 0 : _m;
                }
            }


            public double Yellow
            {
                get
                {
                    return _y;
                }
                set
                {
                    _y = value;
                    _y = _y > 1 ? 1 : _y < 0 ? 0 : _y;
                }
            }


            public double K
            {
                get
                {
                    return _k;
                }
                set
                {
                    _k = value;
                    _k = _k > 1 ? 1 : _k < 0 ? 0 : _k;
                }
            }
        }
    }

}
