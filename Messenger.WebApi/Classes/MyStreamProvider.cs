using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Messenger.WebApi.Classes
{
    public class MyStreamProvider : MultipartFormDataStreamProvider
    {
        public MyStreamProvider(string uploadPath)
            : base(uploadPath)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var fileName = headers.ContentDisposition.FileName;
            fileName=fileName.Replace("\"", string.Empty);
            var userId = fileName.Split('_')[0];
            var ext = Path.GetExtension(fileName);
            fileName = userId+"_"+Guid.NewGuid()+ext;
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = Guid.NewGuid().ToString() + ".data";
            }
            return fileName;
        }
    }
}