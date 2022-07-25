using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Contracts.ViewModels.User
{
    public class UserDetailListViewModel
    {
        [DisplayName("Id")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("FistName:")]
        [StringLength(15, MinimumLength = 3)]
        public string UserFirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3)]
        [DisplayName("LastName:")]
        public string UserLastName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        [DisplayName("Adress:")]
        public string UserAdress { get; set; }

        [Required]
        [DisplayName("PhoneNumber:")]                                                              
        [DataType(DataType.PhoneNumber)]
         public string UserPhoneNumber { get; set; }
    }
}
