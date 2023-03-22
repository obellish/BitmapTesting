using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace BitmapTesting
{
    public static class Program
    {
        private static readonly double scaleFactor = 1.5;

        public static void Main()
        {
            var path = @"C:\Users\obellish\Downloads\new_kitcheck_logo.jpg";

            var res = @"C:\Users\obellish\Downloads\resized_kitcheck_logo.jpg";

            using var input = new Bitmap(path);

            using var result = new Bitmap(Scale(input.Width), Scale(input.Height));

            using var g = Graphics.FromImage(result);

            //g.DrawImage(input, 0, 0, input.Width * 2, input.Height * 2);
            g.DrawImage(input, 0, 0, Scale(input.Width), Scale(input.Height));

            var ici = ImageCodecInfo.GetImageEncoders().FirstOrDefault(ie => ie.MimeType == "image/jpeg");
            var eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
            result.Save(res, ici, eps);
        }

        private static int Scale(int input)
        {
            var converted = Convert.ToDouble(input);

            return Convert.ToInt32(converted * scaleFactor);
        }
    }
}
