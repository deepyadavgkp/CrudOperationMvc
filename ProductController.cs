using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CrudOperation_MVC.Models;

namespace CrudOperation_MVC.Controllers
{
    public class ProductController : Controller
    {
        ProductDb pd = new ProductDb();
        // GET: Product
        public ActionResult Index()
        {
            var pdlist = pd.GetAllProducts();
            if (pdlist.Count == 0)
            {
                TempData["InfoMessage"] = "Currently data is unavailable";
            }
            return View(pdlist);


        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product p)
        {
            bool isinserted = false;
            try
            {
                if (ModelState.IsValid)
                {
                    isinserted = pd.insertProduct(p);

                    if (isinserted)
                    {
                        TempData["Success"] = "Data is inserted successfully";
                    }
                    else
                    {
                        TempData["Error"] = "Data is unable to save";
                    }
                   
                }
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {

            try
            {
                var product = pd.GetProductbyID(id).FirstOrDefault();
                if (product == null)
                {
                    TempData["InfoMessage"] = "Products not available with id " + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product Pr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isUpdate = pd.UpdateProduct(Pr);
                    if (isUpdate)
                    {
                        TempData["SuccessMessage"] = "Products details Updated successfuly";
                    }

                    else
                    {
                        TempData["Error"] = "Products is unable to Update";
                    }
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var product = pd.GetProductbyID(id).FirstOrDefault();
                if (product == null)
                {
                    TempData["InfoMessage"] = "Products not available with id " + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
            
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
