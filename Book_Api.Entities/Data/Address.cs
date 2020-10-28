using Book_Api.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Book_Api.Data.Models
{
    public class Address : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string OpenAddress { get; set; }
        public string PostCode { get; set; }

        public virtual County County { get; set; }
        public virtual User User { get; set; }
    }
}
