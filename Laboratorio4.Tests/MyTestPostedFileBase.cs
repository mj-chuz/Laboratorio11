using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace Laboratorio4.Tests
{
    class MyTestPostedFileBase : HttpPostedFileBase
    {
        Stream stream;
        string contentType;
        string fileName;
        public MyTestPostedFileBase(Stream stream, string contentType, string fileName)
        {
            this.stream = stream;
            this.contentType = contentType;
            this.fileName = fileName;
        }
        public override int ContentLength
        {
            get { return (int)stream.Length; }
        }
        public override string ContentType
        {
            get { return contentType; }
        }
        public override string FileName
        {
            get { return fileName; }

        }
        public override Stream InputStream
        {
            get { return stream; }
        }
        public override void SaveAs(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
