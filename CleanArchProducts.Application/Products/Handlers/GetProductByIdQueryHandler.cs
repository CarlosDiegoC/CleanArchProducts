using System.Threading;
using System.Threading.Tasks;
using CleanArchProducts.Application.Products.Queries;
using CleanArchProducts.Domain.Entities;
using CleanArchProducts.Domain.Interfaces;
using MediatR;

namespace CleanArchProducts.Application.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}