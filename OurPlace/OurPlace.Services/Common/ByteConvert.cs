using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OurPlace.Services.Common
{
    public static class ByteConvert
    {
        public static byte[] ToImageToByteArray(List<IFormFile> userImage)
        {
            MemoryStream stream = new MemoryStream();
            foreach (var item in userImage)
            {
                item.CopyToAsync(stream);
            }
            return stream.ToArray();
        }
    }
}
