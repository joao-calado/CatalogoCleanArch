﻿using CatalogoCleanArch.Application.Products.Commands;
using CatalogoCleanArch.Domain.Entities;
using CatalogoCleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoCleanArch.Application.Products.Handlers;

public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public ProductCreateCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

        if (product == null)
        {
            throw new ApplicationException($"Error creating entity.");
        }
        else
        {
            product.CategoryId = request.CategoryId;
            return await _productRepository.CreateAsync(product);
        }
    }
}
