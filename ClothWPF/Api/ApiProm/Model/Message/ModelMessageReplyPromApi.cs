using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListMessageReplyPromApi
    {
        public List<ClassModelMessageReplyPromApi> modelListMessageReplyPromApis;
    }
    public class ClassModelMessageReplyPromApi
    {
        public Int64 id { get; set; }//������������� ���������.
        public string message { get; set; }//����� ���������. ����������� - 1000 ��������.
    }
}