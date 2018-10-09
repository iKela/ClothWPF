using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ClothWPF.Models
{
  public  class UserModel
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }   
        public string SurName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        
    }
}
