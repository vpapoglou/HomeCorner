using HomeCorner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeCorner.ViewModels
{
    public class HousesViewModel
    {
        public House House { get; set; }  //oxi lista giati mas endiaferei sto details kai sta ypoloipa views na emfanizetai mono ena spiti kai ola ta features tou kai oxi ola ta spitia mazi
        public IEnumerable<SelectListItem> AllRegions { get; set; }
        public IEnumerable<SelectListItem> AllFeatures { get; set; }

        private List<byte> _selectedFeatures;
        public List<byte> SelectedFeatures
        {
            get
            {
                if (_selectedFeatures == null)
                {
                    _selectedFeatures = House.Features.Select(m => m.Id).ToList();
                }
                return _selectedFeatures;
            }
            set { _selectedFeatures = value; }

        }
        private string _selectedRegion;
        public string SelectedRegion
        {
            get
            {
                if (_selectedRegion == null)
                {
                    _selectedRegion = House.Region.RegionName;
                }
                return _selectedRegion;
            }
            set { _selectedRegion = value; }

        }
        public HousesViewModel()
        {
            AllFeatures = new List<SelectListItem>();
            AllRegions = new List<SelectListItem>();
        }
    }
}