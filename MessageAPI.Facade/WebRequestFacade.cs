using MessageAPI.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MessageAPI.Facade
{
    public class WebRequestFacade : IRequestFacade
    {
        public string GetMessage()
        {
            var port = 51185;
            var url = "http://localhost:" + port + "/api/Message";

            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            using (StreamReader s = new StreamReader(dataStream))
            {
                return s.ReadToEnd();
            }
        }
    }
}
