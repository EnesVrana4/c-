#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DSwithValidation.Models
{
    public class Dojo
    {
        [Required]
        public string YourName {get;set;}
        [Required]
        public string DojoLocation {get;set;}
        [Required]
        public string FavouriteLanguage {get;set;}
        public string Comment {get;set;}
    }
}

