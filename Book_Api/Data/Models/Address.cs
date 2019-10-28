using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string OpenAddress { get; set; }
        public string PostCode { get; set; }

        public virtual County County { get; set; }
        public virtual User User { get; set; }
    }
}
