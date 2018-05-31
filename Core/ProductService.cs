using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Dto;
using Infrastructure;
using NLog;

namespace Core
{
    public class ProductService : DomainService
    {
        public ProductService(IDbContext dbContext, ILogger logger)
            : base(dbContext, logger)
        {
        }

        public async Task<List<Product>> LoadProductsByCatalog(string catalogId, int page)
        {
            throw new NotImplementedException();
        }

        public async Task<int> LoadCountProductsByCatalog(string catalogId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}