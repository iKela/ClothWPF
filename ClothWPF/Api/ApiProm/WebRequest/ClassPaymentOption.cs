using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm
{
    public class ClassPaymentOption : GET_POST
    {
        public string getPaymentOptionList()
        {
            string url = "/api/v1/payment_option/list";
            return this.sendGet(url);
        }
        
    }
}
