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
