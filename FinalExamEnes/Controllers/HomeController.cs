using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalExamEnes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
#pragma warning disable CS8618



namespace FinalExamEnes.Controllers;

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
        return RedirectToAction("bright_ideas");
    }
    [HttpGet("bright_ideas")]
    public IActionResult bright_ideas()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Register");
            }
            int id = (int)HttpContext.Session.GetInt32("userId");

            ViewBag.posts = _context.Posts.OrderByDescending(e => e.Likes.Count()).Include(e => e.Creator).Include(e=> e.Likes).ToList();

            
            //Marr te loguarin me te dhena
            ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet("Register")]
    public IActionResult Register()
    {


        if (HttpContext.Session.GetInt32("userId") == null)
        {

            return View();
        }

        return RedirectToAction("bright_ideas");

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
           
            return RedirectToAction("bright_ideas");
        }
        return View();
    }

    [HttpPost("Login")]
    public IActionResult LoginSubmit(LoginUser userSubmission)
    {
        if (ModelState.IsValid)
        {
            // If initial ModelState is valid, query for a user with provided email
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
            // If no user exists with provided email
            if (userInDb == null)
            {
                // Add an error to ModelState and return to View!
                ModelState.AddModelError("User", "Invalid UserName/Password");
                return View("Register");
            }

            // Initialize hasher object
            var hasher = new PasswordHasher<LoginUser>();

            // verify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);

            // result can be compared to 0 for failure
            if (result == 0)
            {
                ModelState.AddModelError("Password", "Invalid Password");
                return View("Register");
                // handle failure (this should be similar to how "existing email" is handled)
            }
            HttpContext.Session.SetInt32("userId", userInDb.UserId);

            return RedirectToAction("bright_ideas");
        }

        return View("Register");
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {

        HttpContext.Session.Clear();
        return RedirectToAction("register");
    }

    [HttpGet("/Post/Add")]
    public IActionResult PostAdd()
    {
        return RedirectToAction("bright_ideas");
    }

    [HttpPost("/Post/Add")]
        public IActionResult PostAdd(Post marrNgaView,string text)
       
        {
             int id = (int)HttpContext.Session.GetInt32("userId");
            
           
        if (text == null)
        {
            {
            ModelState.AddModelError("PostContent", "Min Length 4");
            ViewBag.posts = _context.Posts.Include(e => e.Creator).ToList();

            
            //Marr te loguarin me te dhena
            ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);
            return View("bright_ideas");
            
        }
        }
        if (text.Length < 5)
        {
            ModelState.AddModelError("PostContent", "Min Length 4");
               ViewBag.posts = _context.Posts.Include(e => e.Creator).ToList();

            
            //Marr te loguarin me te dhena
            ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);
            return View("bright_ideas");
            
        }
        
        Post marrNgaDB = new Post(){
            UserId = id,
            PostContent = text
        };
       
            
           
            _context.Posts.Add(marrNgaDB);
            // int nrOfPostsCreated = _context.Users.SingleOrDefault(a => a.CreatedPost).Where(a => a.UserId == id ); 
            // nrOfPostsCreated ++;
            // _context.Users.CreatedPost = nrOfPostsCreated;
            _context.SaveChanges();
        return RedirectToAction("bright_ideas");
        
        
    }

    
    [HttpGet("/Post/Like/{id}")]
    public IActionResult LikeAdd(int id)
    {
        int idFromSession = (int)HttpContext.Session.GetInt32("userId");

        Like likes = new Like()
        {
            UserId = idFromSession,
            PostId = id

        };
        _context.Likes.Add(likes);
        _context.SaveChanges();
        return RedirectToAction("bright_ideas");
    }

    [HttpGet("/Post/Unlike/{id}/{PostId}")]
    public IActionResult Unlike(int id, int postId)
    {
        int idFromSession = (int)HttpContext.Session.GetInt32("userId");
        Like unlike = _context.Likes.First(e => e.UserId == id && e.PostId == postId);
        _context.Likes.Remove(unlike);
        _context.SaveChanges();
        return RedirectToAction("bright_ideas");
    }

[HttpGet("/Post/Delete/{id}")]
    public IActionResult Fshi(int id)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Register");
        }
        Post fshiPost = _context.Posts.First(e => e.PostId == id);
        _context.Posts.Remove(fshiPost);
        _context.SaveChanges();
        return RedirectToAction("bright_ideas");
    }

    [HttpGet("users/{creator}")]
    public IActionResult Creator(int creator)
    {
        ViewBag.PostsBy = _context.Posts.Where(e => e.UserId == creator).ToList();
        ViewBag.CreatorProfile = _context.Users.Include(e=> e.Likes).Include(e=> e.Posts).ThenInclude(e=>e.Likes).FirstOrDefault(e => e.UserId == creator);
        return View("CreatorProfile");
    }

    [HttpGet("bright_ideas/{id}")]
    public IActionResult TheIdea(int id)
    {

        ViewBag.posts = _context.Posts.Include(e => e.Creator).Include(e=> e.Likes).ThenInclude(e=>e.UseriQePelqen).First(e=> e.PostId== id);
        
        return View("TheIdea");
    }




}




  
    
