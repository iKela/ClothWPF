using ClothWPF.Api.ApiProm.Model;
using ClothWPF.Api.ApiProm.Model.Client;
using ClothWPF.Api.ApiProm.Model.Group;
using ClothWPF.Api.ApiProm.Model.Message;
using ClothWPF.Api.ApiProm.Model.PaymentOption;
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
    public class ConnectionToApi
    {
        public static string token = "f35277ebf3c453088467c49440020d3e2abdf711";
        public static string host = "my.prom.ua";
        
        public void getOrderList()
        {
            ClassOrder ogp = new ClassOrder();
            var parsed = JsonConvert.DeserializeObject<ClassModelListOrderPromApi>(ogp.getOrderList());
            List<ClassModelOrderPromApi> model = parsed.modelListOrdrPromApis;
        }
        public void getOrderById(int id)
        {
            ClassOrder ogp = new ClassOrder();
            var parsed = JsonConvert.DeserializeObject<ClassModelListOrderPromApi>(ogp.getOrderById(id));
            List<ClassModelOrderPromApi> modelOrderPromApis = parsed.modelListOrdrPromApis;
        }
        public void setOrderStatus(int[] id, string stat)
        {
            ClassOrder ogp = new ClassOrder();
            var parsed = JsonConvert.DeserializeObject<ClassModelListOrderPromApi>(ogp.setOrderStatus(id, stat));
            List<ClassModelOrderPromApi> modelOrderPromApis = parsed.modelListOrdrPromApis;
        }
        public void setOrderStatus(int[] id, string stat, string cancellationReason)
        {
            // Set order status if cancellationReason parameter is specified
            ClassOrder ogp = new ClassOrder();
            var parsed = JsonConvert.DeserializeObject<ClassModelListOrderPromApi>(ogp.setOrderStatus(id, stat, cancellationReason));
            List<ClassModelOrderPromApi> modelOrderPromApis = parsed.modelListOrdrPromApis;
        }
        public void setOrderStatus(int[] id, string stat, string cancellationReason, string cancellationText)
        {
            ClassOrder ogp = new ClassOrder();
            var parsed = JsonConvert.DeserializeObject<ClassModelListOrderPromApi>(ogp.setOrderStatus(id, stat, cancellationReason, cancellationText));
            List<ClassModelOrderPromApi> modelOrderPromApis = parsed.modelListOrdrPromApis;
        }

        public List<ClassModelProductPromApi> _items()
        {
            ClassProduct pgs = new ClassProduct();
            var parsed = JsonConvert.DeserializeObject<ClassModelListProductPromApi>(pgs.getProductsList());
            List<ClassModelProductPromApi> modelProductPromApis = parsed.modelListProductPromApis;
            return modelProductPromApis;
        }
        public void getProductList()
        {
            ClassProduct pgs = new ClassProduct();
            var parsed = JsonConvert.DeserializeObject<ClassModelListProductPromApi>(pgs.getProductsList());
            List<ClassModelProductPromApi> modelProductPromApis = parsed.modelListProductPromApis;
        }
        public void getProductById(int id)
        {
            ClassProduct pgs = new ClassProduct();
            var parsed = JsonConvert.DeserializeObject<ClassModelListProductPromApi>(pgs.getProductsById(id));
            List<ClassModelProductPromApi> modelProductPromApis = parsed.modelListProductPromApis;
        }
        public void getProductByExternalId(int id)
        {
            ClassProduct pgs = new ClassProduct();
            var parsed = JsonConvert.DeserializeObject<ClassModelListProductPromApi>(pgs.getProductsByExternalid(id));
            List<ClassModelProductPromApi> modelProductPromApis = parsed.modelListProductPromApis;
        }
        public void setProductsEdit(string path, string data)
        {
            ClassProduct pgs = new ClassProduct();
            var parsed = JsonConvert.DeserializeObject<ClassModelProductEditPromApi>(pgs.setProductsEdit(path, data));
            //
        }
        public void setProductsEditByExternalId(string path, string data, int id)
        {
            ClassProduct pgs = new ClassProduct();
            var parsed = JsonConvert.DeserializeObject<ClassModelProductEditByExternalIdPromApi>(pgs.setProductsEditByExternalid(path, data, id));
            //
        }
        public void getMessagesList()
        {
            ClassMessage mgp = new ClassMessage();
            var parsed = JsonConvert.DeserializeObject<ClassModelListMessagePromApi>(mgp.getMessagesList());
            List<ClassModelMessagePromApi> modelMessagePromApis = parsed.modelListMessagePromApis;
        }
        public void getMessagesById(int id)
        {
            ClassMessage mgp = new ClassMessage();
            var parsed = JsonConvert.DeserializeObject<ClassModelListMessagePromApi>(mgp.getMessagesById(id));
            List<ClassModelMessagePromApi> modelMessagePromApis = parsed.modelListMessagePromApis;
        }
        public void setMessagesStatus(int[] messagesIds, string status)
        {
            ClassMessage mgp = new ClassMessage();
            var parsed = JsonConvert.DeserializeObject<ClassModelSetMessageStatusPromApi>(mgp.setMessagesStatus(messagesIds, status));
            //List</*ClassModelMessagePromApi*/> modelMessagePromApis = parsed.modelListMessagePromApis;
        }
        public void setMessagesStatus(int[] messagesIds, string status, string cancellationReason)
        {
            ClassMessage mgp = new ClassMessage();
            var parsed = JsonConvert.DeserializeObject<ClassModelSetMessageStatusPromApi>(mgp.setMessagesStatus(messagesIds, status, cancellationReason));
            //List</*ClassModelMessagePromApi*/> modelMessagePromApis = parsed.modelListMessagePromApis;
        }
        public void setMessagesStatus(int[] messagesIds, string status, string cancellationReason, string cancellationText)
        {
            ClassMessage mgp = new ClassMessage();
            var parsed = JsonConvert.DeserializeObject<ClassModelSetMessageStatusPromApi>(mgp.setMessagesStatus(messagesIds, status, cancellationReason, cancellationText));
            //List</*ClassModelMessagePromApi*/> modelMessagePromApis = parsed.modelListMessagePromApis;
        }
        public void replyMessages(int id, string status)
        {
            ClassMessage mgp = new ClassMessage();
            var parsed = JsonConvert.DeserializeObject<ClassModelMessageReplyPromApi>(mgp.replyMessagesStatus(id, status));
            //List</*ClassModelMessagePromApi*/> modelMessagePromApis = parsed.modelListMessagePromApis;
        }
        public void getClientList()
        {
            ClassClient cc = new ClassClient();
            var parsed = JsonConvert.DeserializeObject<ClassModelListClientPromApi>(cc.getClientList());
            List<ClassModelClientPromApi> modelMessagePromApis = parsed.modelListClientPromApis;
        }
        public void getClientListById(int id)
        {
            ClassClient cc = new ClassClient();
            var parsed = JsonConvert.DeserializeObject<ClassModelListClientPromApi>(cc.getClientById(id));
            List<ClassModelClientPromApi> modelMessagePromApis = parsed.modelListClientPromApis;
        }
        public void getGroupList()
        {
            ClassGroup cg = new ClassGroup();
            var parsed = JsonConvert.DeserializeObject<ClassModelListGroupPromApi>(cg.getGroupList());
            List<ClassModelGroupPromApi> modelGroupPromApis = parsed.modelListGroupPromApis;
        }
        public void getPaymentOptionList()
        {
            ClassPaymentOption cpo = new ClassPaymentOption();
            var parsed = JsonConvert.DeserializeObject<ClassModelListPaymentOptionPromApi>(cpo.getPaymentOptionList());
            List<ClassModelPaymentOptionPromApi> modelPaymentOptionPromApis = parsed.modelListPaymentOptionPromApis;
        }
     }
}
