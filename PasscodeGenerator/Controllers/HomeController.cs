using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PasscodeGenerator.Models;
using Microsoft.AspNetCore.Http;


#pragma warning disable CS8618

namespace PasscodeGenerator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
                HttpContext.Session.Clear();

        return View();
    }

    public IActionResult Privacy()
    {
                HttpContext.Session.Clear();

        return View();
    }
    [HttpGet("Generate")]
    public IActionResult Generate()
    {
        if (HttpContext.Session.GetInt32("Count") == null)
        {
            HttpContext.Session.SetInt32("Count", 1);
        }
        else
        {
            int nr =  (int)HttpContext.Session.GetInt32("Count");
            nr++;
            HttpContext.Session.SetInt32("Count", nr);
        }


        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        ViewBag.finalString = new String(stringChars);
        return View();
    }
    [HttpGet("Clear")]
    public RedirectToActionResult Clear(){
        
        HttpContext.Session.Clear();

        return RedirectToAction("Generate");
    }
    public IActionResult Add()
    {
                HttpContext.Session.Clear();

        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}
