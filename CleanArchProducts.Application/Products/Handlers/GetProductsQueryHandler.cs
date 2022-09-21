using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchProducts.Application.Products.Queries;
using CleanArchProducts.Domain.Entities;
using CleanArchProducts.Domain.Interfaces;
using MediatR;

namespace CleanArchProducts.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return _productRepository.GetProductsAsync();
        }
    }
}