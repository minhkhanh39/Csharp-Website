using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Security.Claims;
using Web_Template.Data;
using Web_Template.Models;

namespace Web_Template.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.ToList();
            return View(sanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Aboutus()
        {
            return View();
        }
        public IActionResult Blogfullwidth()
        {
            return View();
        }
        public IActionResult Bloggridsidebarleft()
        {
            return View();
        }

        public IActionResult Bloggridsidebarright()
        {
            return View();
        }

        public IActionResult Bloglistsidebarleft()
        {
            return View();
        }
        public IActionResult Bloglistsidebarright()
        {
            return View();
        }
        public IActionResult Blogsinglesidebarleft()
        {
            return View();
        }
        public IActionResult Blogsinglesidebarright()
        {
            return View();
        }
        public IActionResult Compare()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Contactus()
        {
            return View();
        }
        public IActionResult Faq()
        {
            return View();
        }
        public IActionResult Emptycart()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult Index4()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Myaccount()
        {
            return View();
        }
        public IActionResult Privacypolicy()
        {
            return View();
        }
        public IActionResult Productdetailsaffiliate()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Productdetailsdefault(int sanphamId)
        {
            GioHang giohang = new GioHang()
            {
                SanPhamId = sanphamId,
                SanPham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == sanphamId),
                Quantity = 1
            };
           
            return View(giohang);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Productdetailsdefault(GioHang giohang)
        {

            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            giohang.ApplicationUserId = claim.Value;

            var giohangFromDB = _db.GioHang.FirstOrDefault(sp => sp.SanPhamId == giohang.SanPhamId
            && sp.ApplicationUserId == giohang.ApplicationUserId);
            if (giohangFromDB == null)
            {
                _db.GioHang.Add(giohang);
            }
            else
            {
                giohangFromDB.Quantity += giohang.Quantity;
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Productdetailsgalleryleft()
        {
            return View();
        }
        public IActionResult Productdetailsgalleryright()
        {
            return View();
        }
        public IActionResult Productdetailsgroup()
        {
            return View();
        }
        public IActionResult Productdetailssingleslide()
        {
            return View();
        }
        public IActionResult Productdetailsstickyleft()
        {
            return View();
        }
        public IActionResult Productdetailsstickyright()
        {
            return View();
        }
        public IActionResult Productdetailstableft()
        {
            return View();
        }
        public IActionResult Productdetailstabright()
        {
            return View();
        }
        public IActionResult Productdetailsvariable()
        {
            return View();
        }
        public IActionResult Shopfullwidth()
        {
            return View();
        }
        public IActionResult Shopgridsidebarleft()
        {
            return View();
        }
        public IActionResult Shopgridsidebarright()
        {
            return View();
        }
        public IActionResult Shoplistsidebarleft()
        {
            return View();
        }
        public IActionResult Shoplistsidebarright()
        {
            return View();
        }
        public IActionResult Wishlist()
        {
            return View();
        }
    }
}