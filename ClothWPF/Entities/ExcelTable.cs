using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class ExcelTable
    {
        [Key]
        public Int64 UId { get; set; } //Уникальный_идентификатор
        public string Code { get; set; } //Код_товара
        public string Name { get; set; } //Название_позиции
        public double? PriceUah { get; set; } //Цена
        public double? PriceWholesale { get; set; } //Оптовая_цена
        public int? Count { get; set; } //Количество
        public string Country { get; set; } //Страна_производитель
    }
}
