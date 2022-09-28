using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PeopleForPeople.Models;
#pragma warning disable CS8618


public class Message {
[Key]
public string MessageId {get; set; }
public string MessageContent {get; set;}
public int? UserId {get; set;}
public int? ChatId {get; set;}
public User? Creator { get; set; }
public Chat? ConnectedTo {get; set;}
public DateTime CreatedAt { get; set; } = DateTime.Now;


}