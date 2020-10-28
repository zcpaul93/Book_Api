using Book_Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Api.Data.Models
{
    public class Types : IEntity
    {
        [Key]
        public int TypesId { get; set; }

        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }

    }
}
