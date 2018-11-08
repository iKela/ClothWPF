using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm
{
    public class ClassOrder : GET_POST
    {
        public string getOrderList()
        {
            string url = "/api/v1/orders/list";
            return this.sendGet(url);
        }
        public string getOrderById(int id)
        {
            string url = String.Format("/api/v1/orders/%s", id);
            return this.sendGet(url);
        }

        public string setOrderStatus(int[] orderIds, String status)
        {
            string url = "/api/v1/orders/set_status";

            // Formatting given order ids to string such as "[1, 2, 3]"
            string preparedIds = String.Format("[%s]", String.Join(",", Convert.ToString(orderIds)));
            // Creating string which represents json data
            string outputTemplate = "{\"ids\": %s,\"status\":\"%s\"}";
            string Out = String.Format(outputTemplate, preparedIds, status);
            return this.sendPost(url, Out);
        }

        // Set order status if cancellationReason parameter is specified
        public string setOrderStatus(int[] orderIds, String status, String cancellationReason)
        {
            string url = "/api/v1/orders/set_status";

            String preparedIds = String.Format("[%s]", String.Join(",", Convert.ToString(orderIds)));

            string outputTemplate = "{\"ids\": %s,\"status\":\"%s\", \"cancellation_reason\": %s}";
            string Out = String.Format(outputTemplate, preparedIds, status, cancellationReason);
            return this.sendPost(url, Out);
        }

        // Set order status if cancellationReason and cancellationText parameters are specified
        public string setOrderStatus(int[] orderIds, string status, string cancellationReason, string cancellationText)
        {
            String url = "/api/v1/orders/set_status";

            string preparedIds = String.Format("[%s]", String.Join(",", Convert.ToString(orderIds)));

            string outputTemplate = "{\"ids\": %s,\"status\":\"%s\", \"cancellation_reason\": %s, \"cancellation_text\": %s}";
            string Out = String.Format(outputTemplate, preparedIds, status, cancellationReason, cancellationText);
            return this.sendPost(url, Out);
        }        
    }
}
