using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Contracts.ViewModels.Order
{
    public class OrderViewModel
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Select User")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Select Burgers")]
        public List<int> BurgersId { get; set; }
    }
}
