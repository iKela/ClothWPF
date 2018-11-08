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
    public class ClassMessage : GET_POST
    {     
        public string getMessagesList()
        {
            string url = "/api/v1/messages/list";
            return this.sendGet(url);
        }
        public string getMessagesById(int id)
        {
            string url = String.Format("/api/v1/messages/%s", id);
            return this.sendGet(url);
        }
        public string setMessagesStatus(int[] messagesIds, String status)
        {
            string url = "/api/v1/messages/set_status";

            string preparedIds = String.Format("[%s]", String.Join(",", Convert.ToString(messagesIds)));
            string outputTemplate = "{\"ids\": %s,\"status\":\"%s\"}";
            string Out = String.Format(outputTemplate, preparedIds, status);
            return this.sendPost(url, Out);
        }

        public string setMessagesStatus(int[] messagesIds, String status, String cancellationReason)
        {
            string url = "/api/v1/messages/set_status";

            String preparedIds = String.Format("[%s]", String.Join(",", Convert.ToString(messagesIds)));

            string outputTemplate = "{\"ids\": %s,\"status\":\"%s\", \"cancellation_reason\": %s}";
            string Out = String.Format(outputTemplate, preparedIds, status, cancellationReason);
            return this.sendPost(url, Out);
        }

        public string setMessagesStatus(int[] messagesIds, string status, string cancellationReason, string cancellationText)
        {
            String url = "/api/v1/messages/set_status";

            string preparedIds = String.Format("[%s]", String.Join(",", Convert.ToString(messagesIds)));

            string outputTemplate = "{\"ids\": %s,\"status\":\"%s\", \"cancellation_reason\": %s, \"cancellation_text\": %s}";
            string Out = String.Format(outputTemplate, preparedIds, status, cancellationReason, cancellationText);
            return this.sendPost(url, Out);
        }
        public string replyMessagesStatus(int id, string status)
        {
            String url = "/api/v1/messages/reply";

            string preparedIds = String.Format("[%s]", String.Join(",", Convert.ToString(id)));

            string outputTemplate = "{\"id\": %s,\"status\":\"%s\"}";
            string Out = String.Format(outputTemplate, preparedIds, status);
            return this.sendPost(url, Out);
        }
       
    }
}
