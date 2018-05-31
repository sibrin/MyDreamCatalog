using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public Catalog Catalog { get; set; }

        public int CatalogId { get; set; }

        public string Name { get; set; }

        public float Cost { get; set; }

        public int Count { get; set; }

        public string ImageName { get; set; }
    }
}