using System.Drawing;
using System.IO;

namespace Dragonfly.Chalk
{
    internal static class ScreenLogger
    {
        public static bool DrawScreen(string filename, bool createDirectory)
        {
            try
            {
                if (createDirectory)
                {
                    string path = Path.GetDirectoryName(filename);
                    if (!FileUtils.CreateDirectory(path))
                        return false;
                }

                Bitmap bmp = WindowUtils.CaptureScreen();
                bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DrawScreen(string filename, Point point, bool createDirectory)
        {
            try
            {
                if (createDirectory)
                {
                    string path = Path.GetDirectoryName(filename);
                    if (!FileUtils.CreateDirectory(path))
                        return false;
                }

                Size size = new Size(100, 100);
                Point start = point;
                start.X -= 50;
                start.Y -= 50;
                if (start.X < 0)
                    start.X = 0;
                if (start.Y < 0)
                    start.Y = 0;

                Point drawPosition = point;
                drawPosition.Offset(-start.X, -start.Y);

                Rectangle drawRect = new Rectangle(start, size);
                Bitmap bmp = WindowUtils.CaptureScreen(drawRect, drawPosition);
                bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
