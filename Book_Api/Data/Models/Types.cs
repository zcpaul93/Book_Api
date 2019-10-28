using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Types
    {
        [Key]
        public int TypesId { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }
        
    }
}
