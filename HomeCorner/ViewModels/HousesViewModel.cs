using HomeCorner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeCorner.ViewModels
{
    public class HousesViewModel
    {
        public House House { get; set; }  //oxi lista giati mas endiaferei sto details kai sta ypoloipa views na emfanizetai mono ena spiti kai ola ta features tou kai oxi ola ta spitia mazi
        public List <Features> Features { get; set; }

    }
}