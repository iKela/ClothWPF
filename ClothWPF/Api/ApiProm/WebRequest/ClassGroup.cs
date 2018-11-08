using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm
{
    public class ClassGroup : GET_POST
    {
        public string getGroupList()
        {
            string url = "/api/v1/orders/list";
            return this.sendGet(url);
        }       
    }
}
