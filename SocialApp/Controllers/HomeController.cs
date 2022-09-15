using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;
#pragma warning disable CS8618



namespace SocialApp.Controllers;

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
        return RedirectToAction("Register");
    }
    [HttpGet("HomePage")]
    public IActionResult HomePage()
    {
        if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Register");
            }
            int id = (int)HttpContext.Session.GetInt32("userId");

          
        ViewBag.posts = _context.Posts.Include(e => e.Creator).ThenInclude(e => e.CreatedPost).Include(e => e.Likes).ThenInclude(e => e.UseriQePelqen).ToList();
        
        // Marr te loguarin me te dhena
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
                ModelState.AddModelError("User", "Invalid Email/Password");
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

            return RedirectToAction("HomePage");
        }

        return View("Register");
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {

        HttpContext.Session.Clear();
        return RedirectToAction("register");
    }







    [HttpGet("Send/{id}")]
    public IActionResult Send(int id)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Register");
            }
        int idFromSession = (int)HttpContext.Session.GetInt32("userId");
        Request newRequest = new Models.Request()
        {
            SenderId = idFromSession,
            ReciverId = id,

        };
        _context.Requests.Add(newRequest);
        _context.SaveChanges();
        // User dbUser = _context.Users.Include(e=>e.Requests).First(e=> e.UserId == idFromSession);
        // dbUser.Requests.Add(newRequest);
        _context.SaveChanges();
        HttpContext.Session.SetInt32("DeleteFromPerdoruesitId", id);

        return RedirectToAction("Requests");

    }
    [HttpGet("Accept/{id}")]
    public IActionResult Accept(int id)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Register");
            }

        Request requestii = _context.Requests.First(e => e.RequestId == id);
        requestii.Accepted = true;
        // _context.Remove(hiqFans);
        _context.SaveChanges();
        return RedirectToAction("Requests");
    }
    [HttpGet("Decline/{id}")]
    public IActionResult Decline(int id)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Register");
            }

        Request requestii = _context.Requests.First(e => e.RequestId == id);
        _context.Remove(requestii);
        _context.SaveChanges();
        return RedirectToAction("Requests");
    }
    [HttpGet("Remove/{id}")]
    public IActionResult Remove(int id)
    {

        Request requestii = _context.Requests.First(e => e.RequestId == id);
        _context.Remove(requestii);
        _context.SaveChanges();
        return RedirectToAction("Friends");
    }









[HttpGet("Friends")]
public IActionResult Friends()
{
    int id = (int)HttpContext.Session.GetInt32("userId");
   



















     ViewBag.miqte = _context.Requests.Where(e => (e.SenderId == id) || (e.ReciverId == id)).Include(e => e.Reciver).Include(e => e.Sender).Where(e => e.Accepted == true).ToList();

    return View();

}


[HttpGet("Requests")]
public IActionResult Requests()
{
    if (HttpContext.Session.GetInt32("userId") == null)
            {
                return RedirectToAction("Register");
            }
    int id = (int)HttpContext.Session.GetInt32("userId");

   
 //Marrim gjithe perdoruesit e tjere
        List<Request> rq =  _context.Requests.Include(e=>e.Reciver).Include(e=>e.Sender).Where(e => e.ReciverId == id).Where(e => e.Accepted == false).ToList();

        ViewBag.perdoruesit2 = _context.Users.Include(e=>e.Requests).Where(e=> e.UserId != id).Where(e=>(e.Requests.Any(f=> f.SenderId == id) == false) && (e.Requests.Any(f=> f.ReciverId == id) == false) ).ToList();
        
        
        //List me request
        List<User> LIST4= _context.Users.Include(e=>e.Requests).Where(e=> e.UserId != id).Where(e=>(e.Requests.Any(f=> f.SenderId == id) == false) && (e.Requests.Any(f=> f.ReciverId == id) == false) ).ToList();
        //list me miqte
        List<Request> miqte =_context.Requests.Where(e => (e.SenderId == id) || (e.ReciverId == id)).Include(e=>e.Reciver).Include(e=>e.Sender).Where(e=>e.Accepted ==true).ToList();
        
        //Filtorjme listen e gjithe userave ne menyre qe miqte dhe ata qe u kemi nisur ose na kane nisur request te mos dalin tek users e tjere.
        for (int i = 0; i < LIST4.Count; i++)
        {
            var test22= LIST4[i].Requests.Except(rq);
            
            for (int j = 0; j < rq.Count; j++)
            {
                if (rq[j].SenderId == LIST4[i].UserId || rq[j].ReciverId == LIST4[i].UserId )
            {
                LIST4.Remove(LIST4[i]);
            }
                if (HttpContext.Session.GetInt32("DeleteFromPerdoruesitId")  == LIST4[i].UserId || HttpContext.Session.GetInt32("userId") == LIST4[i].UserId )
            {
                LIST4.Remove(LIST4[i]);
            }
            
            }
            for (int z = 0; z < miqte.Count; z++)
            {
                if (miqte[z].SenderId == LIST4[i].UserId || miqte[z].ReciverId == LIST4[i].UserId )
            {
                LIST4.Remove(LIST4[i]);
            }

            }

            
        }
        
        // lista e filtruar ruhet ne viewbag
        ViewBag.perdoruesit= LIST4;
        
        //shfaqim gjith requests
        ViewBag.requests = _context.Requests.Include(e=>e.Reciver).Include(e=>e.Sender).Where(e => e.ReciverId == id).Where(e => e.Accepted == false).ToList();

        // shfaq gjith miqte

        ViewBag.miqte = _context.Requests.Where(e => (e.SenderId == id) || (e.ReciverId == id)).Include(e=>e.Reciver).Include(e=>e.Sender).Where(e=>e.Accepted ==true).ToList();
        //Marr te loguarin me te dhena
        ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);





    return View();
}







    [HttpGet("/Post/Add")]
    public IActionResult PostAdd()
    {
        return RedirectToAction("HomePage");
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
            return View("HomePage");
            
        }
        }
        if (text.Length < 5)
        {
            ModelState.AddModelError("PostContent", "Min Length 4");
               ViewBag.posts = _context.Posts.Include(e => e.Creator).ToList();

            
            //Marr te loguarin me te dhena
            ViewBag.iLoguari = _context.Users.FirstOrDefault(e => e.UserId == id);
            return View("HomePage");
            
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
        return RedirectToAction("HomePage");
        
        
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
        return RedirectToAction("HomePage");
    }

    [HttpGet("/Post/Unlike/{id}/{PostId}")]
    public IActionResult Unlike(int id, int postId)
    {
        int idFromSession = (int)HttpContext.Session.GetInt32("userId");
        Like unlike = _context.Likes.First(e => e.UserId == id && e.PostId == postId);
        _context.Likes.Remove(unlike);
        _context.SaveChanges();
        return RedirectToAction("HomePage");
    }

[HttpGet("/Post/Delete/{id}")]
    public IActionResult Delete(int id)
    {
        if (HttpContext.Session.GetInt32("userId") == null)
        {
            return RedirectToAction("Register");
        }
        Post fshiPost = _context.Posts.First(e => e.PostId == id);
        _context.Posts.Remove(fshiPost);
        _context.SaveChanges();
        return RedirectToAction("HomePage");
    }

    [HttpGet("users/{creator}")]
    public IActionResult Creator(int creator)
    {
        ViewBag.PostsBy = _context.Posts.Where(e => e.UserId == creator).ToList();
        // ViewBag.CreatorProfile = _context.Users.Include(e=> e.Likes).Include(e=> e.Posts).ThenInclude(e=>e.Likes).FirstOrDefault(e => e.UserId == creator);

                    ViewBag.CreatorProfile = _context.Users.Include(e=> e.Posts).ThenInclude(e=> e.Likes).FirstOrDefault(e => e.UserId == creator);


        return View("CreatorProfile");
    }

    [HttpGet("HomePage/{id}")]
    public IActionResult TheIdea(int id)
    {

        ViewBag.posts = _context.Posts.Include(e => e.Creator).Include(e=> e.Likes).ThenInclude(e=>e.UseriQePelqen).First(e=> e.PostId== id);
        
        return View("TheIdea");
    }

    [HttpGet("Post/Comment")]
    public IActionResult Comment()
    {
        return RedirectToAction("HomePage");
    }


}


