using System.ComponentModel.DataAnnotations;
namespace SocialApp.Models;
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;


public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$",   ErrorMessage = "First Name should be only letters characters!")]
    public string FirstName { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z]+$",   ErrorMessage = "Last Name should be only letter characters!")]

    public string LastName { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
      
    
    [DataType(DataType.Password)]
    [Required]
    [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    // public List<Like> Liked { get; set; } = new List<Like>(); 
    public List<Request> Requests {get;set;} = new List<Request>();
    public List<Post> Posts { get; set; } = new List<Post>(); 
    // public List<Request> Sender {get;set;} = new List<Request>();
    // public List<Request> SenderRequests {get;set;} = new List<Request>();
    // public List<Request> ReciverRequests {get;set;} = new List<Request>();
    public List<Like> Likes {get;set;}= new List<Like>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<CommentLike> CommentLikes { get; set; } = new List<CommentLike>();
    
    
    // Will not be mapped to your users table!
    [NotMapped]
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string Confirm { get; set; }
    public User? CreatedPost { get; set;}

   
}
public class LoginUser
{
    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; }
    [DataType(DataType.Password)]

    [Required]
    public string Password { get; set; }
}
