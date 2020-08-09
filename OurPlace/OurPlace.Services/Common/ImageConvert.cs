using System.Drawing;
using System.IO;

namespace OurPlace.Services.Common
{
    public static class ImageConvert
    {

        public static byte[] ToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }
    }
}
