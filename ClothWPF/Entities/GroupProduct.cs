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
        public int IdGroup { get; set; }
        public string NameGroup { get; set; }
        public int RungGroup { get; set; }
        public string DescriptionGroup { get; set; }
    }
}
