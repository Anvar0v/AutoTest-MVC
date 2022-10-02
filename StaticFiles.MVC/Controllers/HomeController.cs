using Microsoft.AspNetCore.Mvc;
using StaticFiles.MVC.Services;

namespace StaticFiles.MVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(int? id)
    {
        return View();
    }
}