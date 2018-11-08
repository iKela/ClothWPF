using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm
{
    public class ClassClient : GET_POST
    {
        public string getClientList()
        {
            string url = "/api/v1/clients/list";
            return this.sendGet(url);
        }
        public string getClientById(int id)
        {
            string url = String.Format("/api/v1/clients/%s", id);
            return this.sendGet(url);
        }        
    }
}
