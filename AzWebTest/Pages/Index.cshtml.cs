using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Models;
using sqlapp.Services;

namespace AzWebTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Product> ProductList = new();
        public void OnGet()
        {
            ProductService productService = new();
            ProductList = productService.GetProducts();
        }
    }
}