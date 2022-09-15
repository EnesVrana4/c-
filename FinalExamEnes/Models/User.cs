using System.ComponentModel.DataAnnotations;
namespace FinalExamEnes.Models;
#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations.Schema;


public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z\s]+$",   ErrorMessage = "Name should be only letter characters and spaces!")]
    public string Name { get; set; }
    [Required]
    [RegularExpression(@"^[a-zA-Z0-9]+$",   ErrorMessage = "Alias should be only letter and numbers characters!")]

    public string Alias { get; set; }
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
    public List<Post> Posts { get; set; } = new List<Post>(); 

public List<Like> Likes {get;set;}= new List<Like>();
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
