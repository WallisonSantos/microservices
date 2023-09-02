using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microservices.FrontEnd.Models;
using Microservices.FrontEnd.Service;

#nullable disable

namespace FrontEnd.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;
    public HomeController(IProductService productService)
    {
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));
    }


    
    public async Task<IActionResult> ProductIndex()
    {
        var products = await _productService.FindAllProducts();
        return View(products);
    }



    public IActionResult ProductCreate()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ProductCreate(ProductModel productModel)
    {   
        if(ModelState.IsValid)
        {
            var response = await _productService.CreateProduct(productModel);
            if(response != null) return RedirectToAction(nameof(ProductIndex));     
        }
        return View(productModel);
    }



    public async Task<IActionResult> ProductUpdate(int id)
    {
        var response = await _productService.FindProductById(id);
        if(response != null) return View(response);
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> ProductUpdate(ProductModel productModel)
    {
        if(ModelState.IsValid)
        {
            var response = await _productService.UpdateProduct(productModel);
            if(response != null)  return RedirectToAction(nameof(ProductIndex));
        }
        return View(productModel);
    }



    public async Task<IActionResult> ProductDelete(int id)
    {
        var response = await _productService.FindProductById(id);
        if(response != null) return View(response);
        return NotFound();
    }
    [HttpPost]
    public async Task<IActionResult> ProductDelete(ProductModel productModel)
    {
        var response = await _productService.DeleteProductById(productModel.Id);
        if(response) return RedirectToAction(nameof(ProductIndex));
        return View(productModel);
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
