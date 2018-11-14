using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm
{
    public class GET_POST : ConnectionToApi
    {
        public string sendGet(string path)
        {
            Uri url = new Uri(String.Format("http://%s%s", host, path));
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Headers.Add("Authorization", "Bearer" + token);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string text = sr.ReadToEnd();
            resp.Close();
            sr.Close();
            return text;
        }
        public string sendPost(string path, string data)//rework
        {
            Uri url = new Uri(String.Format("http://%s%s", host, path));
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.Headers.Add("Authorization", "Bearer" + token);
            req.ContentType = "application/json; charset=UTF-8";
            using (var requestStream = req.GetRequestStream())
            using (var sw = new StreamWriter(requestStream))
            {
                sw.Write(data);
            }

            using (var responseStream = req.GetResponse().GetResponseStream())
            using (var sr = new StreamReader(responseStream))
            {
                var result = sr.ReadToEnd();
                using (var sw = new StreamWriter("page.html", false, Encoding.GetEncoding(1251)))
                    sw.Write(result);
            }
            return /*response.toString()*/null;
        }
    }
}
