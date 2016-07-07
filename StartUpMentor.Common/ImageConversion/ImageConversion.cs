using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Common
{
    public static class ImageConversion
    {
        public static byte[] ImageToArray(System.Drawing.Image image)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

                return stream.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static System.Drawing.Image ImageFromArray(byte[] byteArray)
        {
            try
            {
                MemoryStream stream = new MemoryStream(byteArray);
                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

                return image;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
