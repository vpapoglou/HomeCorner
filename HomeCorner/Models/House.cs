using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HomeCorner.Models
{
    public class House
    {
        public House()
        {
            this.Features = new HashSet<Features>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        //[Required(ErrorMessage = "Please, provide a description")]
        public string Description { get; set; }

        //[Required(ErrorMessage = "Please, provide a Region")]
        //public string Region { get; set; }

        //[Required(ErrorMessage = "Please, provide an Address")]
        public string Address { get; set; }

        public int PostalCode { get; set; }

        public int Occupancy { get; set; }

        public decimal Price { get; set; }

        public DateTime Availability { get; set; }

        public int OwnerId { get; set; }

        public virtual Customer Owner { get; set; }

        public byte RegionId { get; set; }

        public virtual Region Region { get; set; }

        public virtual ICollection<Features> Features { get; set; }
    }
}