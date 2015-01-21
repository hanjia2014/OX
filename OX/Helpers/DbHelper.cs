using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace OX.Helpers
{
    public class DbHelper
    {
        public static byte[] ConvertImageToBlob(Image image)
        {
            var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            return stream.ToArray();
        }

        public static Image ConvertBlobToImage(byte[] blob)
        {
            return Image.FromStream(new MemoryStream(blob));
        }

        public static byte[] ReadBytes(Stream input)
        {
            var buffer = new byte[input.Length];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}