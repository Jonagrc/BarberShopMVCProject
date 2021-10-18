using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarberShop.Services;
using BarberShop.Models;
using Microsoft.AspNetCore.Authorization;//nneeed bthis for employees to have authorization


namespace BarberShop.Controllers
{
    //public class ProductController : Controller
    //{//TODO add all action methods here for the product view page 
    //    IRepository _productRepository;//initialize the interface
    //    public ProductController(IRepository repository)
    //    {//constructor with dependency injection
    //        _productRepository = repository;
    //    }
    //    public ViewResult DisplayAll()
    //    { //TODO GET PRODUCTS FROM DATABASE AND DISPLAY TO THE VIEW 
    //        //ViewBag.Productlist = new string[] { ""Hair products };
    //        //ViewBag.Productlist = _productRepository.GetProduct();
    //        return View();
    //    }

    //    public IActionResult Productlist()
    //    {//THIS IS MY LIST FOR EMPLOYEES ONLY 
    //     //TODO ADD AUTHORIZATION ROLES 
    //     //this will show you all Products in table format
    //        var model = _productRepository.GetProduct();
    //        return View(model);
    //    }
    //    public ViewResult Create()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    public IActionResult Create(Product obj)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            Product newproduct = _productRepository.AddProduct(obj);
    //            return RedirectToAction("ProductList");
    //        }
    //        return View();
    //    }
    //    [HttpGet]
    //    public ViewResult Update(int id)
    //    {
    //        Product prodchanges = _productRepository.GetProduct(id);//getting selected product by id 
    //        return View(prodchanges);//then sending that object of product to the view with the properties in the text boxes
    //    }
    //    [HttpPost]
    //    public ViewResult Update(Product obj, int id)
    //    {
    //        //this will show you all Products in table format 
    //        obj.ProductId = id;
    //        Product prodchanges = _productRepository.UpdateProduct(obj);
    //        var model = _productRepository.GetProduct();//need to pass model == new list 
    //        return View("ProductList", model);
    //    }
    //    public IActionResult Delete(int id)
    //    {
    //        _productRepository.DeleteProduct(id); //sending obj with specific id to delete method and then returning to product list t o show changes 
    //        return RedirectToAction("ProductList");
    //    }
    //    public IActionResult GetProduct(int id)
    //    {
    //        var products = _productRepository.GetProduct();
    //        var product = products.Where(p => p.ProductId == id).FirstOrDefault();
    //        return View(product);
    //    }
   // }
}
