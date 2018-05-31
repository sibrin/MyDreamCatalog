using Microsoft.AspNetCore.Http;

namespace Service.Api.Models
{
    public class ProductCreatingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Cost { get; set; }

        public int Count { get; set; }

        public IFormFile Image { get; set; }
    }
}