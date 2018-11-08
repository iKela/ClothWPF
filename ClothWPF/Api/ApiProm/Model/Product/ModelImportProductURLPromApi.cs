using ClothWPF.Api.ApiProm.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Api.ApiProm.Model
{
    public class ClassModelListImportProductURLPromApi
    {
        public List<ClassModelImportProductURLPromApi> modelListImportProductURLPromApis;
    }
    public class ClassModelImportProductURLPromApi
    {
       public string url { get; set; }//������ �� excel ��������
       public enum periodic_type { none, every_hour, hourly, daily, weekly, monthly };
       public Boolean force_update { get; set; }//�������� �������������//xzchu z velukoi bukvu boolean
       public Boolean remove_groups_not_in_file { get; set; }//������� ������ ������� ��� � �����//xzchu z velukoi bukvu boolean
       public Boolean user_post_moderation { get;set }//��������� ��������� �� ����� �������
       public Boolean make_missing_parent_main { get; set; }//���� �������� ������ �� ������ - ���������� � ��������
       public enum mark_missing_product_as { none, not_available, not_on_display, deleted } //�������� ������������� �������� ��������� ��������
        public Boolean has_variations { get; set; }//���� �������� ������ �� ������ - ���������� � ��������
        //public enum updated_fields { name, price, images_urls, presence, quantity_in_stock, description, group, keywords, attributes, discount }//������ �����, ������� ���������� ��������

    }
}