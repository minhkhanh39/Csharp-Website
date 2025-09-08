using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Template.Data;
using Web_Template.Models;

namespace Web_Template.ViewComponents
{
    public class HeaderCartViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _db;
        public HeaderCartViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var giohang =  _db.GioHang.ToList();
            return View(giohang);
        }
    }
}
