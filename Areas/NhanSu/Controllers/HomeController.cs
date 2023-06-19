using Microsoft.AspNetCore.Mvc;

namespace QLSV.Areas.NhanSu.Controllers
{
    [Area("NhanSu")]
    [Route("phong-nhan-su")]
    public class HomeController : Controller
    {
        [Route("danh-sach-nhan-su")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
