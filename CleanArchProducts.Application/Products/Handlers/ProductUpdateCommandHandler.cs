using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchProducts.Application.Products.Commands;
using CleanArchProducts.Domain.Entities;
using CleanArchProducts.Domain.Interfaces;
using MediatR;

namespace CleanArchProducts.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            
            if(product == null)
            {
                throw new ApplicationException("Product could not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
                return await _productRepository.UpdateAsync(product);
            }
        }
    }
}