using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListImportProductStatusPromApi
    {
        public List<ClassModelImportProductStatusPromApi> modelListImportProductStatusPromApis;
    }
    public class ClassModelImportProductStatusPromApi
    {
        public enum status { SUCCESS, PARTIAL, FATAL };
        public int not_changed { get; set; }//���������� �������, ���������� ��� ���������
        public int updated { get; set; }//���������� ����������� �������
        public int not_in_fle { get; set; }//���������� �������, ������� ��� � ����� �������
        public int imported { get; set; }//���������� �������������� �������
        public int created { get; set; }//���������� ��������� �������
        public int actualized { get; set; }//���������� ����������������� �������
        public int created_active { get; set; }//������� �������� �������
        public int created_hidden { get; set; }//������� ������� �������
        public int total { get; set; }//����� ��������� �������
        public int with_errors_count { get; set; }//����� ������� � ��������
        //errors
    }
}