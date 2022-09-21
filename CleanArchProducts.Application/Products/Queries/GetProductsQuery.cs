using System.Collections.Generic;
using CleanArchProducts.Domain.Entities;
using MediatR;

namespace CleanArchProducts.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
        
    }
}