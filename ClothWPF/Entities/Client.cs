using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothWPF.Entities
{
    public class Client
    {
        [Key]
        public int IDClient { get; set; }
        public string NameClient { get; set; }
        public string Comments { get; set; }
    }
}
