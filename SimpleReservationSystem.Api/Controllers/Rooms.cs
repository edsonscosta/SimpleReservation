using Microsoft.AspNetCore.Mvc;

namespace SimpleReservationSystem.Api.Controllers;

public class Rooms : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}