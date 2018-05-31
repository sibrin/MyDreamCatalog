using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models.Dto
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Cost { get; set; }

        public int Count { get; set; }

        public string ImageName { get; set; }
    }
}
