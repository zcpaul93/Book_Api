using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "date")]
        public DateTime ShippedDate { get; set; }
        public decimal ShipPrice { get; set; }
         

        public virtual User User { get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
     
    }
}
