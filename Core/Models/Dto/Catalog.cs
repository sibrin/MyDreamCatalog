using Newtonsoft.Json;

namespace Core.Models.Dto
{
    public class Catalog
    {
        public int Id { get; set; }

        [JsonProperty("parent")]
        public int ParentId { get; set; }

        public string Name { get; set; }

        public bool HasChilds { get; set; }
    }
}