using System.Web.Mvc;
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
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = repo.GetDetails(id);
            return View(product);
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
            repo.InsertProduct(product);
            return RedirectToAction("Index");
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
            repo.UpdateProduct(product);
            return RedirectToAction("Index");
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
            repo.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
