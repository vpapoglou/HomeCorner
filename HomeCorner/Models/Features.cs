using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCorner.Models
{
    public class Features
    {
        public Features()
        {
            this.Houses = new HashSet<House>();
        }
        public byte Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}