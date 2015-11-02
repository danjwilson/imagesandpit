using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookEngine
{
    public class TestBookTemplateDefinition
    {
        private BookTemplate bookTemplate;

        // Book Template object
        public BookTemplate Template
        {
            get { return bookTemplate; }
            set { bookTemplate = value; }
        }

        public TestBookTemplateDefinition()
        {
            bookTemplate = new BookTemplate
            { 
                Id = "TestBook", 
                PageTemplates = CreatePageTemplates(), 
                PageWidth = 900,
                PageHeight = 506,
                TemplateFolder = @"C:\Projects\ImageSandpit\BookEngine\BookTemplates\Book\TestBook\",
                TemplateImagesFolder = @"C:\Projects\ImageSandpit\BookEngine\BookTemplates\Book\TestBook\Images\",
                OutputFolder = @"C:\Projects\ImageSandpit\BookEngine\Output\TestBook\"
            };

        }

        private List<PageTemplate> CreatePageTemplates()
        {
            // Text formating
            FontFamily myFontFamily = FontFamily.Families.First(x => x.Name == "Pristina");
            Font myFont = new Font(myFontFamily, 36, FontStyle.Regular);
            Font myBigFont = new Font(myFontFamily, 46, FontStyle.Regular);
            Brush myGreenBrush = new SolidBrush(System.Drawing.Color.DarkGreen);
            Brush myWhiteBrush = new SolidBrush(System.Drawing.Color.White);

            List<PageTemplate> pageTemplates = new List<PageTemplate>();
            
            // The HOUSE page....
            pageTemplates.Add(new PageTemplate
            {
                Id = "HousePage",
                OptionId = "None",
                Index = 0,
                BaseImageLayer = new ImageLayer { Id = "HouseBaseImage", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "HouseImage", StackOrder = 1, File = "house_background_900_506.png" }
            },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "HouseText", StackOrder = 1, Text = @"{Name} leaves {his} house and is ready for an adventure!", 
                    Font = myFont, Brush = myGreenBrush, X=20, Y=20 }
            }
            });

            // The PARK page....
            pageTemplates.Add(new PageTemplate
            {
                Id = "ParkPage",
                OptionId = "None",
                Index = 1,
                BaseImageLayer = new ImageLayer { Id = "ParkBaseImage", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "ParkImage", File = "park_background_900_506.png" }
            },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "ParkText", Text = @"Perhaps {he} would like a visit to the park?",
                    Font = myFont, Brush = myGreenBrush, X=200, Y=10 }
            }
            });

            // The SEA page....
            pageTemplates.Add(new PageTemplate
            {
                Id = "SeaPage",
                OptionId = "None",
                Index = 2,
                BaseImageLayer = new ImageLayer { Id = "SeaBaseImage", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "SeaImage", File = "sea_background_900_506.png" }
            },
                TextLayers = new List<TextLayer>{
                new TextLayer { Id = "ParkText1", Text = @"{He} stepped into a lake. Oh my God!!",
                    Font = myFont, Brush = myWhiteBrush, X=10, Y=10 },
                new TextLayer { Id = "ParkText2", Text = @"{Name}'s downing!",
                    Font = myBigFont, Brush = myWhiteBrush, X=10, Y=78 }
            }
            });

            // Add the character images (cheating here: using the same images for all pages)
            ImageLayer boyCaucasian = new ImageLayer{ Id = "CaucasianBoyImage", File = "boy_caucasian.png", Conditions = new Dictionary<string, string>() };
            boyCaucasian.Conditions.Add("Gender", "Boy");
            boyCaucasian.Conditions.Add("SkinColour", "Caucasian");

            ImageLayer boyAfrican = new ImageLayer { Id = "AfricanBoyImage", File = "boy_african.png", Conditions = new Dictionary<string, string>() };
            boyAfrican.Conditions.Add("Gender", "Boy");
            boyAfrican.Conditions.Add("SkinColour", "African");

            ImageLayer boyAsian = new ImageLayer { Id = "AsianBoyImage", File = "boy_asian.png", Conditions = new Dictionary<string, string>() };
            boyAsian.Conditions.Add("Gender", "Boy");
            boyAsian.Conditions.Add("SkinColour", "Asian");

            ImageLayer girlBasic = new ImageLayer { Id = "GirlImage", File = "girl_basic.png", Conditions = new Dictionary<string, string>() };
            girlBasic.Conditions.Add("Gender", "Girl");

            ImageLayer blackHair = new ImageLayer { Id = "BlackHairImage", File = "boy_black_hair.png", Conditions = new Dictionary<string, string>() };
            blackHair.Conditions.Add("HairColour", "Black");

            ImageLayer brownHair = new ImageLayer { Id = "BrownHairImage", File = "boy_brown_hair.png", Conditions = new Dictionary<string, string>() };
            brownHair.Conditions.Add("HairColour", "Brown");

            ImageLayer blondeHair = new ImageLayer { Id = "BlondeHairImage", File = "boy_blonde_hair.png", Conditions = new Dictionary<string, string>() };
            blondeHair.Conditions.Add("HairColour", "Blonde");

            ImageLayer gingerHair = new ImageLayer { Id = "GingerHairImage", File = "boy_ginger_hair.png", Conditions = new Dictionary<string, string>() };
            gingerHair.Conditions.Add("HairColour", "Ginger");


            foreach (PageTemplate pageTemplate in pageTemplates)
            {
                pageTemplate.ImageLayers.Add(boyCaucasian); 
                pageTemplate.ImageLayers.Add(boyAfrican);
                pageTemplate.ImageLayers.Add(boyAsian);
                pageTemplate.ImageLayers.Add(girlBasic);
                pageTemplate.ImageLayers.Add(blackHair);
                pageTemplate.ImageLayers.Add(brownHair);
                pageTemplate.ImageLayers.Add(blondeHair);
                pageTemplate.ImageLayers.Add(gingerHair);
            }


            return pageTemplates;

        }
    }
}
