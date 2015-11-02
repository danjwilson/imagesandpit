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
            // Get the character option items
            Dictionary<string, List<OptionItem>> characterOptionItems = Builder.GetCharacterOptionItems("BestSwimmer");
            IEnumerable<SelectListItem> genderOptionItems = ConvertToSelectListItems(characterOptionItems["Gender"]);
            IEnumerable<SelectListItem> hairColourOptionItems = ConvertToSelectListItems(characterOptionItems["HairColour"]);
            IEnumerable<SelectListItem> skinColourOptionItems = ConvertToSelectListItems(characterOptionItems["SkinColour"]);            
            
            // Get the page option items
            Dictionary<string, List<OptionItem>> pageOptionItems = Builder.GetPageOptionItems("BestSwimmer");
            IEnumerable<SelectListItem> lovePageOptionItems = ConvertToSelectListItems(pageOptionItems["Love"]);

            TestBookCreateViewModel viewModel = new TestBookCreateViewModel(genderOptionItems, hairColourOptionItems, skinColourOptionItems, lovePageOptionItems);
            return View(viewModel);
        }

        private IEnumerable<SelectListItem> ConvertToSelectListItems(List<OptionItem> optionItems)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (OptionItem item in optionItems)
            {
                selectListItems.Add(new SelectListItem { Value = item.Value, Text = item.Text });
            }

            return selectListItems;
        }

        public ActionResult SerializeBookTemplate()
        {
            BookTemplateHelper.Serialize(BestSwimmerDefinition.GetTemplate());
            return RedirectToAction("Create");
        }

        [HttpPost]
        public ActionResult Create(string CustomerId, string Name, string Gender, string HairColour, string SkinColour, string PersonalMessage, string LovePage)
        {
            return RedirectToAction("Detail", new { CustomerId = CustomerId, Name = Name, Gender = Gender, HairColour = HairColour, SkinColour = SkinColour, PersonalMessage = PersonalMessage, LovePage = LovePage });
        }

        public ActionResult Detail(string CustomerId, string Name, string Gender, string HairColour, string SkinColour, string PersonalMessage, string LovePage)
        {
            Dictionary<string, string> selectedCharacterOptions = new Dictionary<string, string>();
            selectedCharacterOptions.Add("CustomerId", CustomerId);
            selectedCharacterOptions.Add("Name", Name);
            selectedCharacterOptions.Add("Gender", Gender);
            selectedCharacterOptions.Add("HairColour", HairColour);
            selectedCharacterOptions.Add("SkinColour", SkinColour);            
            selectedCharacterOptions.Add("PersonalMessage", PersonalMessage);

            Dictionary<string, string> selectedPageOptions = new Dictionary<string, string>();
            selectedPageOptions.Add("Love", LovePage);

            Book myBook = Builder.BuildBook("BestSwimmer", selectedCharacterOptions, selectedPageOptions);

            TestBookDetailViewModel viewModel = new TestBookDetailViewModel(myBook);
            return View(viewModel);
        } 
    }
}