using Microsoft.AspNetCore.Mvc;
using Inveon.Web.Models;
using Inveon.Web.Services.IServices;
using Newtonsoft.Json;
using Inveon.Web.Services;

namespace Inveon.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class YoneticiController : Controller
    {
        private readonly IProductService productService;

        public YoneticiController(IProductService productService) {
            this.productService = productService;
            
        }

        public async Task<IActionResult> Index()

        {
            List<ProductDto> list = new();
            var response = await productService.GetAllProductsAsync<ResponseDto>("");
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        public IActionResult Git()
        {
            return View();
        }
        public IActionResult AdminLogout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
