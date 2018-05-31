namespace Core.Models.Dto
{
    public class Catalog
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Name { get; set; }

        public bool HasChilds { get; set; }
    }
}