using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PeopleForPeople.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
#pragma warning disable CS8618



namespace PeopleForPeople.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    // here we can "inject" our context service into the constructor
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("")]
    public RedirectToActionResult Index()
    {
        return RedirectToAction("Login");
    }
    [HttpGet("Register")]
    public IActionResult Register()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return View();
        }
        return RedirectToAction("HomePage");
    }
    [HttpPost("Register")]
    public IActionResult Register(User user)
    {
        if (ModelState.IsValid)
        {
      
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email already in use!");

                return View();
                // You may consider returning to the View at this point
            }
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            user.Password = Hasher.HashPassword(user, user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("userId", user.UserId);
           
            return RedirectToAction("HomePage");
        }
        return View();
    }

    [HttpGet("Login")]
    public IActionResult Login()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return View();
        }
        return RedirectToAction("HomePage");
    }
    [HttpPost("Login")]
    public IActionResult Login(LoginUser userSubmission)
    {
        if (ModelState.IsValid)
        {
            // If initial ModelState is valid, query for a user with provided email
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
            // If no user exists with provided email
            if (userInDb == null)
            {
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("User", "Invalid Email/Password");
                return View("Login");
            }

            // Initialize hasher object
            var hasher = new PasswordHasher<LoginUser>();

            // verify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

            // result can be compared to 0 for failure
            if (result == 0)
            {
                ModelState.AddModelError("Password", "Invalid Password");
                return View("Login");
                // handle failure (this should be similar to how "existing email" is handled)
            }
            HttpContext.Session.SetInt32("userId", userInDb.UserId);

            return RedirectToAction("HomePage");
        }

        return View("Login");
    }

    [HttpGet("Logout")]
    public IActionResult Logout()
    {

        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }



    [HttpGet("HomePage")]
    public IActionResult HomePage()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Login");
            }
            int id = (int)HttpContext.Session.GetInt32("userId");

          
        
        // Marr te loguarin me te dhena dhe cases
        ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);
        ViewBag.cases = _context.Cases.OrderByDescending(a => a.CreatedAt).Include(e => e.Creator).ToList();


        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [HttpGet("/Case/Add")]
    public IActionResult CaseAdd()
    {
         if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Login");
            }
        return View("CaseAdd");
    }

    [HttpPost("/Case/Add")]
        public IActionResult CaseAdd(Case marrNgaView,string Description)
        {
             if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Login");
            }
            int id = (int)HttpContext.Session.GetInt32("userId");            
           
        if (Description == null)
        {
            {
            ModelState.AddModelError("Description", "Description must be 20 letters or longer!");
            ViewBag.Cases = _context.Cases.Include(e => e.Creator).ToList();

            
            //Marr te loguarin me te dhena
            ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);
            return View("CaseAdd");
            
        }
        }
        if (Description.Length < 20)
        {
            ModelState.AddModelError("Description", "Description must be 20 letters or longer!");
               ViewBag.Cases = _context.Cases.Include(e => e.Creator).ToList();

            
            //Marr te loguarin me te dhena
            ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);
            return View("CaseAdd");
            
        }
        
        Case newCase = new Case(){
            UserId = id,
            Tittle = marrNgaView.Tittle,
            Description = Description,
            FamilySurname = marrNgaView.FamilySurname,
            City = marrNgaView.City,
            Address = marrNgaView.Address
        };

        // User currentUser = _context.Users.FirstOrDefault(e => e.UserId == id);
        // List<User> usersInChat = new List<User>();
        // usersInChat.Add(currentUser);

        // Chat caseChat = new Chat(){
        //     CaseId = newCase.CaseId,
        //     UserId = id
        // };

        _context.Cases.Add(newCase);
        // Console.WriteLine("TEST here{0}", newCase.CaseId);

        // _context.Chats.Add(caseChat); 
 
            _context.SaveChanges();
        return RedirectToAction("HomePage");
        
        
    }

    

[HttpGet("/Case/Delete/{id}")]
    public IActionResult Delete(int id)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Login");
        }
        Case deleteCase = _context.Cases.First(e => e.CaseId == id);
        _context.Cases.Remove(deleteCase);
        _context.SaveChanges();
        return RedirectToAction("HomePage");
    }


    [HttpGet("HomePage/{id}")]
    public IActionResult TheCase(int id)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Login");
        }
        ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);
        ViewBag.Cases = _context.Cases.Include(e => e.Creator).First(e=> e.CaseId== id);
        
        return View("TheCase");
    }

    [HttpGet("Chats")]
    public IActionResult Chats()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Login");
        }
        int id = (int)HttpContext.Session.GetInt32("userId");            
        ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);
        return View("GroupChats");
    }

    
    [HttpGet("Chat")]
    public IActionResult groupChat()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Login");
        }
        int idFromSession = (int)HttpContext.Session.GetInt32("userId");            
        ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == idFromSession);
        // ViewBag.Messages = _context.Messages.OrderByDescending(a => a.CreatedAt).ToList();
        return View("GroupChat");
    }
    [HttpPost("Chat")]
    public IActionResult GroupChat()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Login");
        }
        
        int idFromSession = (int)HttpContext.Session.GetInt32("userId");            
        ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == idFromSession);
        return RedirectToAction("groupChat");
    }

}


