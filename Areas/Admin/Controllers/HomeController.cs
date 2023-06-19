using Microsoft.AspNetCore.Mvc;
using QLSV.Areas.Admin.Data;
using QLSV.Models;

namespace QLSV.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("quan-tri")]
    public class HomeController : Controller
    {
        private readonly QlsvContext _context;
        public HomeController(QlsvContext context)
        {
            _context = context;
        }
        [Route("bang-dieu-khien")]
        public IActionResult Index()
        {
            var listKhoa = _context.Khoas.ToList();
            var listSV = _context.Sinhviens.ToList();
            var listGV = _context.Giangviens.ToList();
            DataHome dataHome = new DataHome();
            dataHome.DanhSachKhoa = listKhoa;
            dataHome.DanhSachSV = listSV;
            dataHome.DanhSachGV = listGV;
            return View(dataHome);
        }
    }
}
