using System;
using System.ComponentModel.DataAnnotations;


namespace HomeCorner.Models
{
    public class House
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please, provide a description")]
        [Display(Name = "Description")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Please, provide a Region")]
        public string Region { get; set; }

        //[Required(ErrorMessage = "Please, provide an Address")]
        public string Address { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Price { get; set; }

        public int OwnerId { get; set; }

    }
}