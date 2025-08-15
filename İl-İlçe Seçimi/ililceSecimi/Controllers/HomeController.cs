using ililceSecimi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ililceSecimi.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbIlIlceSecimiContext _context;

        public HomeController(DbIlIlceSecimiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetIller()
        {
            var iller = await _context.Illers
                .OrderBy(i => i.IlAdi)
                .ToListAsync();

            return Json(iller);
        }

        [HttpGet]
        public async Task<JsonResult> GetIlcelerByIlId(string ilId)
        {
            // İl ID'sini 2 haneli string formatına dönüştür (01, 02 gibi)
            string formattedIlId = ilId.Length == 1 ? $"0{ilId}" : ilId;

            var ilceler = await _context.Ilcelers
                .Where(i => i.IlId == formattedIlId)
                .OrderBy(i => i.IlceAdi)
                .ToListAsync();

            return Json(ilceler);
        }


    }
}
