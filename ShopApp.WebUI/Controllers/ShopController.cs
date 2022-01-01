using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entities.Concrete;
using ShopApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;

        public ShopController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string url)
        {
            if (url == null)
            {
                return NotFound();
            }
            Product product = _productService.GetProductDetails(url);
            if (product == null)
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            });
        }

        public IActionResult List(string category, int page = 1)
        {
            const int pageSize = 3;
            var model = new ProductListModel
            {
                Products = _productService.GetProductsByCategory(category, page, pageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentCategory = category
                }
            };
            return View(model);
        }

        public IActionResult Search(string q)
        {
            var model = new ProductListModel
            {
                Products = _productService.GetSearchString(q)
            };
            return View(model);
        }
    }
}