using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchProducts.Application.Products.Commands;
using CleanArchProducts.Domain.Entities;
using CleanArchProducts.Domain.Interfaces;
using MediatR;

namespace CleanArchProducts.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if(product == null)
            {
                throw new ApplicationException("Product could not be found.");
            }
            else
            {
                var result = await _productRepository.DeleteAsync(product);
                return result;
            }
        }
    }
}