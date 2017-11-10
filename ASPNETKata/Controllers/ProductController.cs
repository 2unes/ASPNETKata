using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.Practices.Unity;
using SqlIntro;

namespace ASPNETKata.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        // GET: Product
        public ActionResult Index()
        {
            var list = repo.GetProducts();
            return View(list);
            //var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            //using (var conn = new MySqlConnection(connectionString))
            //{
            //    conn.Open();
            //    var list = conn.Query<Product>("Select * from Product Order by ProductID Desc");
            //    return View(list);
            //}
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var product = repo.GetDetails(id);
                return View(product);
            }
            catch (Exception e)
            {

                throw (e);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
               repo.InsertProduct(product);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
               
                throw(e);
            }
           ;
            /*
            var name = collection["Name"];

            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    conn.Execute("INSERT into Product (Name) Values (@Name)", new {Name = name});
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            */
           
        }


        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            product.ProductId = id;

            try
            {
                repo.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw (e);
            }
            /*
            var name = collection["Name"];

            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    conn.Execute("Update Product Set Name = @Name WHERE ProductID =@ID", new { Name = name, ID = id });
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            */
         
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                repo.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw (e);
            }
            /*
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    conn.Execute("DELETE FROM Product WHERE ProductID = @ID", new { ID = id });
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            */
           
        }
    }
}
