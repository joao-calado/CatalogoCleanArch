using CatalogoCleanArch.Application.Products.Commands;
using CatalogoCleanArch.Domain.Entities;
using CatalogoCleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoCleanArch.Application.Products.Handlers;

public class ProducRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProducRemoveCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ??
            throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new ApplicationException(nameof(product));
        }
        else
        {
            var result = await _productRepository.RemoveAsync(product);
            return result;
        }
    }
}
