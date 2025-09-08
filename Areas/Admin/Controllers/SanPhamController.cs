using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Template.Data;
using Web_Template.Models;

namespace Web_Template.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
        {
            SanPham sanpham = new SanPham();

            IEnumerable<SelectListItem> DSTheLoai = _db.TheLoai
                 .Select(sanpham => new SelectListItem
                 {
                     Text = sanpham.Name,
                     Value = sanpham.Id.ToString(),
                 });
            ViewBag.DSTheLoai = DSTheLoai;

            if (id == 0)
            {
                return View(sanpham);
            }
            else
            {
                sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sanpham => sanpham.Id == id);
                return View(sanpham);
            }
        }
        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                if (sanpham.Id == 0)
                {
                    _db.SanPham.Add(sanpham);

                }
                else
                {
                    _db.SanPham.Update(sanpham);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var sanpham = _db.SanPham.FirstOrDefault(sanpham => sanpham.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            else
            {
                _db.SanPham.Remove(sanpham);
                _db.SaveChanges();
                return Json(new { success = true });
            }

        }

    }
}
