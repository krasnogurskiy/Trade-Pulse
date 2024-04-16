﻿using BLL.DTOs;
using BLL.Errors;
using BLL.Features;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ServiceResult<ProductDto>> AddProductAsync(ProductDto productDto)
        {
            try
            {
                var product = new Product
                {
                    Title = productDto.Title,
                    Description = productDto.Description,
                    Model = productDto.Model,
                    Price = productDto.Price,
                    ItemsAvailable = productDto.ItemsAvailable,
                    CreatedAt = DateTime.Now.ToUniversalTime(),
                };

                await _productRepository.Add(product, productDto.VendorId, productDto.CategoryId);
                return productDto;
            }
            catch (Exception ex)
            {
                return ServiceResult<ProductDto>.Failure(new ModelError($"Failed to add product: {ex.Message}"));
            }
        }
    }
}
