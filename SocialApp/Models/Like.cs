using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SocialApp.Models;
#pragma warning disable CS8618


public class Like {

[Key]
public int LikeId { get;set; }
[Required]
public int UserId { get; set; }
[Required]
public int PostId { get; set; }
public User? UseriQePelqen{get; set;}
public Post? UseriQePelqehet{get; set;}


}