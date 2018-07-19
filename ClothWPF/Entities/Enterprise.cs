using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Entities
{
    public class Enterprise
    {
        [Key]
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

        public List<String> EnterprisesList
        {
            get
            {
                return new List<String>
            {
                "Колективна",
                "Суспільна",
                "Приватна",
                "Комунальна",
                "З іноземними інвестиціями",
                "Іноземні",
                "Змішана"
            };
            }
        }
        public List<String> CreatingWayList
        {
            get
            {
                return new List<String>
            {
                "Унітарне",
                "Корпоративне"
            };
            }
        }
        public List<String> EconomicPartnershipList
        {
            get
            {
                return new List<String>
            {
                "Фкціонерне товариство",
                "Товариство з обмеженою відповідальністю",
                "Товариство з додатковою відповідальністю",
                "Командитне товариство",
                "Повне товариство"
                };
            }
        }
        public List<String> AssociationOfEnterprisesList
        {
            get
            {
                return new List<String>
            {
                "Асоціація",
                "Концерт",
                "Консорціум",
                "Корпорація",
                "Холдинг",
                "Промислово-фінансова група"
                };
            }
        }
        public List<String> ActivityList
        {
            get
            {
                return new List<String>
                {
                    "Сільськогосподарська",
                    "Видобувна",
                    "Переробна",
                    "Виробнича",
                    "Фінансова",
                    "Посередницька",
                    "Страхова"
                };
            }
        }
    }
}
