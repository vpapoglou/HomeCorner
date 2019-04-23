using HomeCorner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCorner.ViewModels
{
    public class FeaturesDetailsViewModel
    {
        public House House { get; set; }
        public List<Features> Features { get; set; }
    }
}