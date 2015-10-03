using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageSandpit.Models;
using BookEngine;

namespace ImageSandpit.Controllers
{
    public class TestBookController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            // Sex and Hair colour options
            IEnumerable<SelectListItem> genderOptions = new List<SelectListItem> { 
                new SelectListItem { Value = "Boy", Text = "Boy", }, 
                new SelectListItem { Value = "Girl", Text = "Girl" }};
            IEnumerable<SelectListItem> hairColourOptions = new List<SelectListItem> {
                new SelectListItem { Value = "Blonde", Text = "Blonde" }, 
                new SelectListItem { Value = "Brown", Text = "Brown", }, 
                new SelectListItem { Value = "Black", Text = "Black" }, 
                new SelectListItem { Value = "Ginger", Text = "Ginger" }};
            IEnumerable<SelectListItem> skinColourOptions = new List<SelectListItem> {
                new SelectListItem { Value = "Caucasian", Text = "Caucasian" }, 
                new SelectListItem { Value = "African", Text = "African", }, 
                new SelectListItem { Value = "Asian", Text = "Asian" }};

            TestBookCreateViewModel viewModel = new TestBookCreateViewModel(genderOptions, hairColourOptions, skinColourOptions);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(string CustomerId, string Name, string Gender, string HairColour, string SkinColour, string PersonalMessage)
        {
            return RedirectToAction("Detail", new { CustomerId = CustomerId, Name = Name, Gender = Gender, HairColour = HairColour, SkinColour = SkinColour, PersonalMessage = PersonalMessage });
        }

        public ActionResult Detail(string CustomerId, string Name, string Gender, string HairColour, string SkinColour, string PersonalMessage)
        {
            Dictionary<string, string> characterOptions = new Dictionary<string, string>();
            characterOptions.Add("CustomerId", CustomerId);
            characterOptions.Add("Name", Name);
            characterOptions.Add("Gender", Gender);
            characterOptions.Add("HairColour", HairColour);
            characterOptions.Add("SkinColour", SkinColour);
            characterOptions.Add("PersonalMessage", PersonalMessage);

            //TestBookTemplateDefinition definition = new TestBookTemplateDefinition();
            BestSwimmerTemplateDefinition definition = new BestSwimmerTemplateDefinition();
            Book myBook = Builder.BuildBook(definition.Template, characterOptions, null);

            TestBookDetailViewModel viewModel = new TestBookDetailViewModel(myBook);
            return View(viewModel);
        } 
    }
}