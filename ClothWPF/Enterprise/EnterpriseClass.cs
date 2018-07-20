using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothWPF.Enterprise
{
     public class EnterpriseClass
     {

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
