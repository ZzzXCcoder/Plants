using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using Plants.Services;
using Plants.Interfaces;
using Plants.Interfaces.auth;

namespace Plants.Controllers
{
    public class User_register : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


     

    }
}
