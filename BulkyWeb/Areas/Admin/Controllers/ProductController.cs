using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAcess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;


namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository db)
        {
			_productRepo = db;
        }



        public IActionResult Index()
        {
            List<Product> objProductList = _productRepo.GetAll().ToList();
            return View(objProductList);
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
				_productRepo.Add(obj);
				_productRepo.Save();
                TempData["success"] = "Product created seccessfully";
                return RedirectToAction("Index", "Product");
            }
            return View();

        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _productRepo.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }




        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //	ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            //}


            if (ModelState.IsValid)
            {
                _productRepo.Update(obj);
                _productRepo.Save();
                TempData["success"] = "Product updated seccessfully";
                return RedirectToAction("Index");
            }
            return View();

        }








        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _productRepo.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }




        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //	ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            //}

            Product? obj = _productRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
			_productRepo.Remove(obj);
			_productRepo.Save();
            TempData["success"] = "Product deleted seccessfully";
            return RedirectToAction("Index");
        }
    }
}
