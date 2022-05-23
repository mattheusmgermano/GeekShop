﻿using AutoMapper;
using GeekShop.ProductApi.Data.ValueObjects;
using GeekShop.ProductApi.Model;
using GeekShop.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShop.ProductApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly SqlContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(SqlContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductVO>> FindAll()
    {
        var products = await _context.Products.ToListAsync();
        return _mapper.Map<List<ProductVO>>(products);
    }

    public async Task<ProductVO> FindById(long id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(prod => prod.Id == id);
        return _mapper.Map<ProductVO>(product);
    }

    public async Task<ProductVO> Create(ProductVO vo)
    {
        var product = new Product();
        _mapper.Map<Product>(vo);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductVO>(product);
    }

    public async Task<ProductVO> Update(ProductVO vo)
    {
        var product = _mapper.Map<Product>(vo);
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return _mapper.Map<ProductVO>(product);
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            var product = _context.Products.FirstOrDefaultAsync(prod => prod.Id == id);
            if (product.Equals(null))
            {
                return false;
            }
            _context.Products.Remove(await product);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}