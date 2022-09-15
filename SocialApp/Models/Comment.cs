using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SocialApp.Models;
#pragma warning disable CS8618


public class Comment{
    [Key]
    public int CommentId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int PostId { get; set;}
    public List<CommentLike>? CommentLikes { get; set; } = new List<CommentLike>();

    public User? UseriQePelqen { get; set;} 

    public Post? PostiQePelqehet { get; set;}

    

}