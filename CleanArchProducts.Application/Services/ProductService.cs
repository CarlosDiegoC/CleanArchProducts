using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchProducts.Application.DTO;
using CleanArchProducts.Application.Interfaces;
using CleanArchProducts.Application.Products.Commands;
using CleanArchProducts.Application.Products.Queries;
using MediatR;

namespace CleanArchProducts.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();
            if(productsQuery == null) throw new ApplicationException($"Products could not be loaded.");
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var getProductByIdQuery = new GetProductByIdQuery(id.Value);
            if(getProductByIdQuery == null) throw new ApplicationException($"Product could not be found.");
            var result = await _mediator.Send(getProductByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDto);
            var result = await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDto);
            var result = await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            if(productRemoveCommand == null) throw new ApplicationException($"Product could not be found.");          
            await _mediator.Send(productRemoveCommand);
        }
    }
}