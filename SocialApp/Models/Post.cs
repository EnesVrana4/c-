using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SocialApp.Models;
#pragma warning disable CS8618


public class Post {

[Key]
public int PostId { get;set; }

[MinLength(5, ErrorMessage = "Idea must be 5 characters or longer!")]
public string PostContent { get;set; }  //Tittle
public int? UserId { get; set; }

// public int CommentId { get; set; }


public List<Like>? Likes { get; set; } = new List<Like>();
public List<Comment>? Comments { get; set; } = new List<Comment>();


public User? Creator { get; set; }
public DateTime CreatedAt { get; set; } = DateTime.Now;
public DateTime UpdatedAt { get; set; } = DateTime.Now;

}