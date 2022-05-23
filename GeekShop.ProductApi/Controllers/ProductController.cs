using AutoMapper;
using GeekShop.ProductApi.Data.ValueObjects;
using GeekShop.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeekShop.ProductApi.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository
                      ?? throw new ArgumentNullException(
                          nameof(repository),
                          "O repositório é nulo."
                      );
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
    {
        var product = await _repository.FindAll();
        if (product.Equals(null)) return NotFound();
        return Ok(product);
    }
    
    [HttpGet("{id:long}")]
    public async Task<ActionResult<ProductVO>> FindById(long id)
    {
        var product = await _repository.FindById(id);
        if (product.Equals(null)) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductVO>> Create(ProductVO vo)
    {
        if (vo.Equals(null)) return BadRequest();
        var product = await _repository.Create(vo);
        return Ok(product);
    }
    
    [HttpPut]
    public async Task<ActionResult<ProductVO>> Update(ProductVO vo)
    {
        if (vo.Equals(null)) return BadRequest();
        var product = await _repository.Update(vo);
        return Ok(product);
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult<bool>> Delete(long id)
    {
        var status = await _repository.Delete(id);
        if (!status) return BadRequest();
        return Ok(status);
    }
}