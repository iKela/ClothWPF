using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class GroupProduct
    {
        [Key]
        public int           IdGroup { get; set; }
        public string      NameGroup { get; set; }
        public string      CodeGroup { get; set; }
        public  double? Nds { get; set; }
        public string      DescriptionGroup { get; set; }
        public  int? IdSubGrop { get; set; }
        public GroupProduct GetGroupProduct { get; set; }
    }
}
