using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QLSV.Models;
using QLSV.Models.DataInput;

namespace QLSV.Controllers
{
    [Route("quan-ly-khoa")] //route của controller
    public class KhoaController : Controller
    {

        private readonly QlsvContext _context;
        public KhoaController(QlsvContext context)
        {
            _context = context;
        }

        [Route("danh-sach-khoa")]
        public IActionResult Index()
        {
            var rows = _context.Khoas.ToList();
            //Response.Cookies.Append("DemoCookie", DateTime.Now.ToString());
            return View(rows);
        }

        [Route("them-khoa")]
        public IActionResult Them()
        {
            return View();
        }

        public IActionResult _PartialKhoa()
        {
            return PartialView();
        }

        //public IActionResult Them(string? makhoa, string? tenkhoa, int? sodienthoai, string kichhoat)
        //{
        //    if (!makhoa.IsNullOrEmpty())
        //    {
        //        Khoa khoa = new Khoa(makhoa, tenkhoa, sodienthoai.ToString(), kichhoat == "on" ? true : false);
        //        _context.Khoas.Add(khoa);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index", "Khoa");
        //    }
        //    else
        //    {
        //        Khoa khoa = new Khoa();
        //        return View(khoa);
        //    }
        //}


        [Route("them-khoa")]
        [HttpPost]

        public IActionResult Them(Khoa input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }
            else
            {
                Khoa khoa = new Khoa(input.MaKhoa, input.TenKhoa, input.SoDienThoai.ToString(), true);
                _context.Khoas.Add(khoa);
                _context.SaveChanges();
                return RedirectToAction("Index", "Khoa");
            }
        }
        //public IActionResult Them(IFormCollection form)
        //{
        //    if (!form["makhoa"].IsNullOrEmpty())
        //    {
        //        Khoa khoa = new Khoa(form["makhoa"], form["tenkhoa"], form["sodienthoai"].ToString(), form["kichhoat"] == "on" ? true : false);
        //        _context.Khoas.Add(khoa);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index", "Khoa");
        //    }
        //    else
        //    {
        //        Khoa khoa = new Khoa();
        //        return View(khoa);
        //    }
        //}

        public IActionResult CapNhat(string? makhoa, string? tenkhoa, int? sodienthoai, string? kichhoat, bool? isUpdate = false)
        {
            //Lấy thông tin dòng dữ liệu
            var rows = _context.Khoas.FirstOrDefault(k => k.MaKhoa == makhoa);

            if ((bool)isUpdate)
            {
                return View(rows);
            }

            rows.TenKhoa = tenkhoa;
            rows.SoDienThoai = sodienthoai.ToString();
            rows.IsActive = kichhoat == "on" ? true : false;
            rows.Keyword = makhoa.ToLower() + " " + tenkhoa.ToLower();
            _context.Khoas.Update(rows);
            _context.SaveChanges();
            return RedirectToAction("Index", "Khoa");
        }
        public IActionResult CapNhat(InputKhoa input, bool? isUpdate = false)
        {
            //Lấy thông tin dòng dữ liệu
            var rows = _context.Khoas.FirstOrDefault(k => k.MaKhoa == input.MaKhoa);

            if ((bool)isUpdate)
            {
                return View(rows);
            }

            rows.TenKhoa = input.TenKhoa;
            rows.SoDienThoai = input.SoDienThoai.ToString();
            rows.IsActive = true;
            rows.Keyword = input.MaKhoa.ToLower() + " " + input.TenKhoa.ToLower();
            _context.Khoas.Update(rows);
            _context.SaveChanges();
            return RedirectToAction("Index", "Khoa");
        }

        //public IActionResult Xoa(string? makhoa)
        //{
        //    var row = _context.Khoas.FirstOrDefault(k => k.MaKhoa == makhoa);
        //    _context.Khoas.Remove(row);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Khoa");
        //}
        public IActionResult Xoa(InputKhoa input)
        {
            var row = _context.Khoas.FirstOrDefault(k => k.MaKhoa == input.MaKhoa);
            _context.Khoas.Remove(row);
            _context.SaveChanges();
            return RedirectToAction("Index", "Khoa");
        }
    }
}
