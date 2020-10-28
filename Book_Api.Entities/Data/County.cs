using Book_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class County : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20),Required]
        public string Name { get; set; }
        public virtual City City { get; set; }
        public virtual IEnumerable<Address> Addresses { get; set; }
    }
}
