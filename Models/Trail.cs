using System;
using System.ComponentModel.DataAnnotations;
namespace LostInTheWoods.Models
{
    public class Trail
    {
        [Key]
        public int Id {get; set;}

        [Required]
        [MinLength(2, ErrorMessage="Must be more than 2 characters")]
        [RegularExpression(@"^[a-zA-Z_ ]+$", ErrorMessage = "Name can only contain letters")]
        public string Name {get; set;}

        [MinLength(10, ErrorMessage="Description must be more than 10 characters")]
        public string Description {get; set;}

        [Required]
        [Range(-90, 90)]
        [RegularExpression(@"^[0-9_. ]+$", ErrorMessage="Only numerical characters in miles!")]
        public float Length {get; set;}

        [Required]
        [RegularExpression(@"^[0-9 . ]+$", ErrorMessage = "Only numerical characters in feet!")]
        public float Elevation {get; set;}


        [Required]
        [Range(-180, 180)]
        public float Longitude {get; set;}

        [Required]
        [Range(-90, 90)]
        public float Latitude {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public DateTime UpdatedAt {get; set;}
    }
}