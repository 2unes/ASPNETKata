﻿using System;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETKata.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace ASPNETKata.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var list = conn.Query<Product>("Select * from Product Order by ProductID Desc");
                return View(list);
            }
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
        public ActionResult Create(FormCollection collection)
        {
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
        }


        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
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
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
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
        }
    }
}
