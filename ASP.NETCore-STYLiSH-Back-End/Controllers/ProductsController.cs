using ASP.NETCore_STYLiSH_Back_End.Data;
using ASP.NETCore_STYLiSH_Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STYLiSH.Types;

namespace ASP.NETCore_STYLiSH_Back_End.Controllers;

[ApiController]
[Route("api/1.0/products")]
public class ProductsController(StylishContext context) : ControllerBase
{
    private readonly StylishContext _context = context;

    [HttpGet("{category}", Name = "GetProducts")]
    public async Task<ActionResult<ProductsSearch>> GetProducts(string category, int paging)
    {
        #region products
        Product[] _products = await _context.Products.ToArrayAsync();

        List<ASP.NETCore_STYLiSH_Back_End.Models.Variant> _ef_variant = await _context.Variants.ToListAsync();
        List<Otherimage> _ef_otherimages = await _context.Otherimages.ToListAsync();

        List<ProductDetailsData>? _data = new();

        for (int i = 0; i < _products.Length; i++)
        {
            List<ASP.NETCore_STYLiSH_Back_End.Models.Variant> _id_variant = _ef_variant.Where(x => x.Id == _products[i].Id).ToList();
            List<Color> _color = new();
            List<STYLiSH.Types.Variant> _variant = new();
            List<string> _images = _ef_otherimages.Where(x => x.Id == _products[i].Id).Select(x => x.ImagesUrl).ToList()!;
            foreach (ASP.NETCore_STYLiSH_Back_End.Models.Variant variant in _id_variant)
            {
                _color.Add(new Color() { code = variant.ColorCode, name = variant.ColorName });
                _variant.Add(new STYLiSH.Types.Variant() { color_code = variant.ColorCode, size = variant.Size, stock = variant.Stock });
            }
            _data.Add(new ProductDetailsData { id = _products[i].Id, category = _products[i].Category, title = _products[i].Title, description = _products[i].Description, price = _products[i].Price, texture = _products[i].Texture, wash = _products[i].Wash, place = _products[i].Place, note = _products[i].Note, story = _products[i].Story, main_image = _products[i].MainImage, images = _images, variants = _variant, colors = _color.Distinct().ToList(), sizes = _variant.Select(x => x.size).Distinct().ToList()! });

        }

        if (category != "all")
        {
            _data = _data.Where(x => x.category == category).ToList();
        }

        if (paging * 6 > _data.Count)
        {
            return new ProductsSearch();
        }

        ProductsSearch result = new() { data = _data[(paging * 6)..((paging + 1) * 6 < _data.Count ? (paging + 1) * 6 : _data.Count)], next_paging = (paging + 1) * 6 < _data.Count ? paging + 1 : null };
        return Ok(result);
        #endregion
    }


    [HttpGet("search", Name = "GetSearchProducts")]
    public async Task<ActionResult<ProductsSearch>> GetSearchProducts(string keyword, int paging)
    {
        #region searchProducts
        Product[] _products = await _context.Products.ToArrayAsync();

        List<ASP.NETCore_STYLiSH_Back_End.Models.Variant> _ef_variant = await _context.Variants.ToListAsync();
        List<Otherimage> _ef_otherimages = await _context.Otherimages.ToListAsync();

        List<ProductDetailsData>? _data = new();

        for (int i = 0; i < _products.Length; i++)
        {
            List<ASP.NETCore_STYLiSH_Back_End.Models.Variant> _id_variant = _ef_variant.Where(x => x.Id == _products[i].Id).ToList();
            List<Color> _color = new();
            List<STYLiSH.Types.Variant> _variant = new();
            List<string> _images = _ef_otherimages.Where(x => x.Id == _products[i].Id).Select(x => x.ImagesUrl).ToList()!;
            foreach (ASP.NETCore_STYLiSH_Back_End.Models.Variant variant in _id_variant)
            {
                _color.Add(new Color() { code = variant.ColorCode, name = variant.ColorName });
                _variant.Add(new STYLiSH.Types.Variant() { color_code = variant.ColorCode, size = variant.Size, stock = variant.Stock });
            }
            _data.Add(new ProductDetailsData { id = _products[i].Id, category = _products[i].Category, title = _products[i].Title, description = _products[i].Description, price = _products[i].Price, texture = _products[i].Texture, wash = _products[i].Wash, place = _products[i].Place, note = _products[i].Note, story = _products[i].Story, main_image = _products[i].MainImage, images = _images, variants = _variant, colors = _color.Distinct().ToList(), sizes = _variant.Select(x => x.size).Distinct().ToList()! });

        }

        if (keyword != "")
        {
            _data = _data.Where(x => x.title.Contains(keyword)).ToList();
        }

        if (paging * 6 > _data.Count)
        {
            return new ProductsSearch();
        }

        ProductsSearch result = new() { data = _data[(paging * 6)..((paging + 1) * 6 < _data.Count ? (paging + 1) * 6 : _data.Count)], next_paging = (paging + 1) * 6 < _data.Count ? paging + 1 : null };
        return Ok(result);
        #endregion
    }

    [HttpGet("details", Name = "GetProductDetails")]
    public async Task<ActionResult<ProductsSearch>> GetProductDetails(long id)
    {
        #region productDetails
        Product[] _products = await _context.Products.ToArrayAsync();

        List<ASP.NETCore_STYLiSH_Back_End.Models.Variant> _ef_variant = await _context.Variants.ToListAsync();
        List<Otherimage> _ef_otherimages = await _context.Otherimages.ToListAsync();

        List<ProductDetailsData>? _data = new();

        for (int i = 0; i < _products.Length; i++)
        {
            List<ASP.NETCore_STYLiSH_Back_End.Models.Variant> _id_variant = _ef_variant.Where(x => x.Id == _products[i].Id).ToList();
            List<Color> _color = new();
            List<STYLiSH.Types.Variant> _variant = new();
            List<string> _images = _ef_otherimages.Where(x => x.Id == _products[i].Id).Select(x => x.ImagesUrl).ToList()!;
            foreach (ASP.NETCore_STYLiSH_Back_End.Models.Variant variant in _id_variant)
            {
                _color.Add(new Color() { code = variant.ColorCode, name = variant.ColorName });
                _variant.Add(new STYLiSH.Types.Variant() { color_code = variant.ColorCode, size = variant.Size, stock = variant.Stock });
            }
            _data.Add(new ProductDetailsData { id = _products[i].Id, category = _products[i].Category, title = _products[i].Title, description = _products[i].Description, price = _products[i].Price, texture = _products[i].Texture, wash = _products[i].Wash, place = _products[i].Place, note = _products[i].Note, story = _products[i].Story, main_image = _products[i].MainImage, images = _images, variants = _variant, colors = _color.Distinct().ToList(), sizes = _variant.Select(x => x.size).Distinct().ToList()! });

        }

        ProductDetails result = new() { data = _data.Where(x => x.id == id).ToList().First() };
        return Ok(result);
        #endregion

    }
}