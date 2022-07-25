using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Enteties
{
    public class Order : BaseEntity
    {

        [ForeignKey(nameof(UserFk))]

        public User User { get; set; }

        public int UserFk { get; set; }

        [Required]
        public List<Burger> Burgers { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate = DateTime.Now;

        public decimal TotalPrice()
        {
            return Burgers.Sum(x => x.Price);
        }

        public Order(int id, User user, List<Burger> burgers)
        {
            Id = id;
            User = user;
            Burgers = burgers;
        }

        public Order()
        {

        }
    }
}
