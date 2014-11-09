using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShop.Domain.Abstract;
using MyShop.Domain.Entities;
using MyShop.WebUI.Models;

namespace MyShop.WebUI.Controllers
{
     [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository _repository;
        private ICategoryRepository _categoryRepository;
        public AdminController(IProductRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        //public PartialViewResult Products(string category)
        //{
        //    IQueryable<Product> result = category == null ? _repository.Products : _repository.Products.Where(c => c.Category.Name == category);
        //    return PartialView("_Products", result);
        //}

        //public ActionResult Index()
        //{
        //    ProductsAdminViewModel model = new ProductsAdminViewModel();
        //    model.Categories = _categoryRepository.Categories;
        //    model.Products = _repository.Products;
        //    return View(model);
        //}

        public ActionResult Index(string category)
        {
            ProductsAdminViewModel model = new ProductsAdminViewModel();
            model.Categories = _categoryRepository.Categories;
            model.Products = category == null ? _repository.Products : _repository.Products.Where(c => c.Category.Name == category);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Products", model);
            }
            return View(model);
        }

        //public ViewResult EditProduct(int id)
        //{
        //    EditProductViewModel model = new EditProductViewModel();
        //    model.Product = _repository.Products.FirstOrDefault(p => p.Id == id);
        //    if (model.Product.Category != null)
        //    {
        //        model.SelectedCategory = model.Product.Category.Name;
        //        model.Categories = new SelectListItem(
        //        _categoryRepository.Categories.Select(
        //            category => new SelectListItem {Text = category.Name, Value = category.Id.ToString()}));
        //    }
        //    //Product product = _repository.Products
        //    //  .FirstOrDefault(p => p.Id == id);
        //    //return View(product);
        //    return View(model);
        //}
        public ViewResult Edit(int id)
        {
            Product product = _repository.Products != null ? _repository.Products.FirstOrDefault(p => p.Id == id) : null;
            return View(product);
        }
        //[HttpPost]
        //public ActionResult Edit(Product product, HttpPostedFileBase image)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (image != null)
        //        {
        //            byte[] imageData = null;
        //            // считываем переданный файл в массив байтов
        //            using (var binaryReader = new BinaryReader(image.InputStream))
        //            {
        //                imageData = binaryReader.ReadBytes(image.ContentLength);
        //            }
        //            product.ImageData = imageData;
        //            //product.ImageMimeType = image.ContentType;
        //            //product.ImageData = new byte[image.ContentLength];
        //            //image.InputStream.Read(product.ImageData, 0, image.ContentLength);
        //        }
        //        _repository.SaveProduct(product);
        //        TempData["message"] = string.Format("{0} has been saved", product.Name);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // there is something wrong with the data values
        //        return View(product);
        //    }
        //}

         [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase fileUpload)
         {
             //EditProductViewModel model = new EditProductViewModel();
             //model.Product = product;
             if (ModelState.IsValid)
             {
                 if (fileUpload != null)
                 {
                     //// получаем имя файла
                     //string fileName = System.IO.Path.GetFileName(fileUpload.FileName);
                     //// сохраняем файл в папку Files в проекте
                     //fileUpload.SaveAs(Server.MapPath("~/Content/Images/" + fileName));
                     //product.ImagePath = Server.MapPath("~/Content/Images/" + fileName);
                     //if (fileUpload == null) continue;
                     string path = AppDomain.CurrentDomain.BaseDirectory + "Content/Images/";
                     string filename = Path.GetFileName(fileUpload.FileName);
                     if (filename != null) fileUpload.SaveAs(Path.Combine(path, filename));
                     product.ImagePath = Path.Combine(path, filename);
                 }
                 _repository.SaveProduct(product);
                 TempData["message"] = string.Format("{0} has been saved", product.Name);

                 return RedirectToAction("Index");
             }
             else return View(product);
         }


        public ViewResult Create()
        {
            
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Product deletedProduct = _repository.DeleteProduct(id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}