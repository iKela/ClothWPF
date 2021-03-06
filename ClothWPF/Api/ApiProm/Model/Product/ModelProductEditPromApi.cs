using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelProductEditPromApi
    {
        public Int64 id { get; set; }//���������� ������������� ������.
        public enum presence { available, not_available, order };//������� ������.
        public double? price { get; set; }//���� ������.
        public enum status { on_display, draft, deleted, not_on_display };//������ ���������.
        public ModelPricesFromProductPromApi prices{get;set;}//����� ������� ���.
        public ModelDiscountFromProductPromApi discount{get;set;}
        public string name { get; set; }//�������� ������.
        public string keywords { get; set; }//������ �������� ���� (����������� ������� ������ ', ').
        public string description { get; set; }//�������� ������ (����� ��������� html ����).
    }
}