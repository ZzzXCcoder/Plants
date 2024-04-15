using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plants.Services;
using WebApplication1.Context;
using Plants.Endpoints;
using Plants.Contract;
namespace Plants.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Accounts
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Accounts.ToListAsync());
        }



    }
}
