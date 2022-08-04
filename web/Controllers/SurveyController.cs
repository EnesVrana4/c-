using Microsoft.AspNetCore.Mvc;
namespace WEB.Controllers;
public class SurveyController : Controller
{

    [HttpGet]
    [Route("")]
    public ViewResult Index()
    {
        return View();
    }
    [HttpGet]
    [Route("test")]
    public string Test(){
        return("test");
    }

    [HttpPost("Create")]
    public IActionResult Create(string YourName, string DojoLocation, string FavouriteLanguage, string comment){
        ViewBag.name = YourName;
        ViewBag.location = DojoLocation;
        ViewBag.favourite = FavouriteLanguage;
        ViewBag.comment = comment;
        return View("Show");
    }

}

