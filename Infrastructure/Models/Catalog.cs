using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }

        public Catalog Parent { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public string HasChilds { get; set; }
    }
}