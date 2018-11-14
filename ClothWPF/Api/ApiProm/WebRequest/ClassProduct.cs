using ClothWPF.Api.ApiProm.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClothWPF.Api.ApiProm
{
 
        public class ClassProduct : GET_POST
        {                       
        public string getProductsList()
        {
            string url = "/api/v1/products/list";
            return this.sendGet(url);
        }
        public string getProductsById(int id)
        {
            string url = String.Format("/api/v1/products/%s", id);
            return this.sendGet(url);
        }
        public string getProductsByExternalid(int id)
        {
            string url = String.Format("/api/v1/products/%s", id);
            return this.sendGet(url);
        }
        public string setProductsEdit(string path, string data)
        {
            //string url = "/api/v1/products";
            //string outputTemplate = "{\"path\":\"%s\", \"data\": %s}";
            //string Out = String.Format(outputTemplate, path, data);
            //return this.sendPost(url, Out);
            return null;
        }
        public string setProductsEditByExternalid(string path, string data, int id)
        {
            //string url = "/api/v1/products";
            //string preparedIds = String.Format("[%s]", String.Join(",", Convert.ToString(id)));
            //string outputTemplate = "{\"path\":\"%s\", \"data\": %s, \"id\": %s}";
            //string Out = String.Format(outputTemplate, path, data, preparedIds);
            //return this.sendPost(url, Out);
            return null;
        }

        public string setProductsAsFile()
        {
            return null;
        }
    }
}