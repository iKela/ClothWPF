using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models.Group
{
    public class GroupModel
    {
        public int IdGroup { get; set; }
        public string NameGroup { get; set; }
        public string CodeGroup { get; set; }
        public double? Nds { get; set; }
        public string DescriptionGroup { get; set; }
        public int? IdSubGrop { get; set; }        
    }
}
