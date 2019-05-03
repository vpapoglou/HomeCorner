using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HomeCorner.Models
{
    public class Images
    {
        public Guid Id { get; set; }
        public string ImageName { get; set; }
        public string Extension { get; set; }

        public int HouseId { get; set; }
        public virtual House House { get; set; }

    }
}