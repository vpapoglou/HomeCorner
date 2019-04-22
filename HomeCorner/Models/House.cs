using System;
using System.ComponentModel.DataAnnotations;


namespace HomeCorner.Models
{
    public class House
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //[Required(ErrorMessage = "Please, provide a description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Please, provide a Region")]
        public string Region { get; set; }

        //[Required(ErrorMessage = "Please, provide an Address")]
        public string Address { get; set; }

        public int PostalCode { get; set; }

        public int Occupancy { get; set; }

        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime Availability { get; set; }

        //public string OwnerName { get; set; }

        //public string Email { get; set; }

        //public int PhoneNumber { get; set; }

        public int OwnerId { get; set; }

        public Customer Owner { get; set; }

    }
}