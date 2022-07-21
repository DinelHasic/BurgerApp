using BurgerApp.Contracts.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Contracts.ViewModels.Order
{
    public class OrderInfoViewModel
    {
        public int OrderId { get; set; }    

        [Required]
        [DisplayName("Select user:")]
        public int UserId { get; set; }

        [DisplayName("Select burgers:")]
        public List<int> BurgersId { get; set; }

        [DisplayName("Price:")]
        public decimal OrderPrice { get; set; }


        [DisplayName("Date Order")]
        [DateValidation(ErrorMessage = "Date can not be set les then the curent date")] 
        public DateTime DateOrder { get; set; } 
    }
}
