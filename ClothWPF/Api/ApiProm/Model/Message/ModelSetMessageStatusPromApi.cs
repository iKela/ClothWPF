using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListSetMessageStatusPromApi
    {
        public List<ClassModelSetMessageStatusPromApi> modelListSetMessageStatusPromApis;
    }
    public class ClassModelSetMessageStatusPromApi
    {
        public Int64[] ids { get; set; }// ������ ���������� ���������������.//P.S.�� �� �� ������
        public enum status { unread, read, deleted }
    }
}