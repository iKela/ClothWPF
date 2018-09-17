using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Models.ArrivalInfo
{
    public class EnterpriseModel
    {
        public int IdEnterprise { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string KodEDRPOU { get; set; }
        public string Ownership { get; set; } //За формою властності
        public string CreatingWay { get; set; } //Залужно від способу утворення та формування статутного капіталу
        public string LegalForm { get; set; }//Залежно від організаційно-правової форми 
        public string Activity { get; set; }//Вид діяльності 
        public string IdentificationCode { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Number { get; set; }
    }
}
