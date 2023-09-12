using Microsoft.AspNetCore.Mvc;
using ProSoftNet.app_code;
using ProSoftNet.Models;
using System.Diagnostics;

namespace ProSoftNet.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ProdutoController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Produtos()
        {
            List<ProdutoModel> list = new List<ProdutoModel>();

            return View(list);
        }

        public IActionResult ProdutoNew()
        {
            Produto produto = new Produto();

            return View();
        }

        public IActionResult ProdutoGet(long idProduto) 
        {
            return View();
        }

        public IActionResult ProdutoPost(ProdutoModel model)
        {
            return RedirectToAction("Produtos");
        }
    }
}