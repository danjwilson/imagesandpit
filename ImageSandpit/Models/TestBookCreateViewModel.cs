using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookEngine;

namespace ImageSandpit.Models
{
    public class TestBookCreateViewModel
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<SelectListItem> GenderOptions { get; set; }
        public IEnumerable<SelectListItem> HairColourOptions { get; set; }
        public IEnumerable<SelectListItem> SkinColourOptions { get; set; }
        public SelectListItem Gender { get; set; }
        public SelectListItem HairColour { get; set; }
        public SelectListItem SkinColour { get; set; }
        public string PersonalMessage { get; set; }

        public TestBookCreateViewModel(IEnumerable<SelectListItem> genderOptions, IEnumerable<SelectListItem> hairColourOptions, IEnumerable<SelectListItem> skinColourOptions)
        {
            GenderOptions = genderOptions;
            HairColourOptions = hairColourOptions;
            SkinColourOptions = skinColourOptions;
        }
    }
}