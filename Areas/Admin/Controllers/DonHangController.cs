using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Template.Data;
using Web_Template.Models;

namespace Web_Template.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DonHangController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<HoaDon> hoadon = _db.HoaDon.Include("ApplicationUser").ToList();
            return View(hoadon);
        }
    }
}
