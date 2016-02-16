using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEngine
{
    public static class BestSwimmerDefinition
    {
        public static BookTemplate GetTemplate()
        {
            BookTemplate bookTemplate = new BookTemplate
            { 
                Id = "BestSwimmer", 
                PageTemplates = CreatePageTemplates(), 
                PageWidth = 900,
                PageHeight = 506,
                TemplateFolder = @"C:\git\ImageSandpit\BookEngine\BookTemplates\Book\BestSwimmer\",
                TemplateImagesFolder = @"C:\git\ImageSandpit\BookEngine\BookTemplates\Book\BestSwimmer\Images\",
                OutputFolder = @"C:\git\ImageSandpit\BookEngine\Output\BestSwimmer\"
            };

            return bookTemplate;
        }

        public static Dictionary<string, List<OptionItem>> GetCharacterOptionItems()
        {
            Dictionary<string, List<OptionItem>> characterOptionItems = new Dictionary<string, List<OptionItem>>();
            characterOptionItems.Add("Gender", new List<OptionItem> { 
                new OptionItem { Value = "Boy", Text = "Boy", }, 
                new OptionItem { Value = "Girl", Text = "Girl" }});
            characterOptionItems.Add("HairColour", new List<OptionItem> { 
                new OptionItem { Value = "Blonde", Text = "Blonde" }, 
                new OptionItem { Value = "Brown", Text = "Brown", }, 
                new OptionItem { Value = "Black", Text = "Black" }, 
                new OptionItem { Value = "Ginger", Text = "Ginger" }});
            characterOptionItems.Add("SkinColour", new List<OptionItem> { 
                new OptionItem { Value = "Caucasian", Text = "Caucasian" }, 
                new OptionItem { Value = "African", Text = "African", }, 
                new OptionItem { Value = "Asian", Text = "Asian" }});

            return characterOptionItems;
        }

        public static Dictionary<string, List<OptionItem>> GetPageOptionItems()
        {
            Dictionary<string, List<OptionItem>> pageOptionItems = new Dictionary<string, List<OptionItem>>();

            pageOptionItems.Add("Love", new List<OptionItem> { 
                new OptionItem {Value = "Costumes", Text = "The swimming costumes"},
                new OptionItem {Value = "Feelings", Text = "The feeling of the water"},
                new OptionItem {Value = "Deep", Text = "Swimming deep in the water"},
                new OptionItem {Value = "Playing", Text = "Playing in the water"}});

            return pageOptionItems;
        }

        private static List<PageTemplate> CreatePageTemplates()
        {
            // Text formating
            FontFamily myFontFamily = FontFamily.Families.First(x => x.Name == "Arial");
            Font myFont = new Font(myFontFamily, 23, FontStyle.Regular);
            Brush myBrush = new SolidBrush(System.Drawing.Color.DarkRed);
            Brush myBrushBlack = new SolidBrush(System.Drawing.Color.Black);
            Brush myBrushWhite = new SolidBrush(System.Drawing.Color.White);

            List<PageTemplate> pageTemplates = new List<PageTemplate>();

            // P1:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p1",
                Index = 0,
                OptionId = "Default",
                OptionCondition = new KeyValuePair<string, string>(),
                BaseImageLayer = new ImageLayer { Id = "p1_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                    new ImageLayer { Id = "p1_image", StackOrder = 1, File = "house_background_900_506.png" }
                },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p1_text", StackOrder = 1, 
                    Text = @"{Name} loved to swim! {He} adored everything about swimming. Getting ready to go. Gathering up the swimming clothes. Picking the fluffiest towel out of the closet. Searching for {his} favourite goggles. Not forgetting, shoving that luscious smelling shower gel for the steamy shower deep into {his} special swimming bag. {Name} just loooooooooooooovvvvvvvveeeeeeeeeedddddddd to swim!",
                    Font = myFont, Brush = myBrushBlack, X=0, Y=0 }
                }
            });

            // P2A:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2a",
                Index = 1,
                OptionId = "Costumes",
                OptionCondition = new KeyValuePair<string,string>("Love", "Costumes"),
                BaseImageLayer = new ImageLayer { Id = "p2a_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                    new ImageLayer { Id = "p2a_image", StackOrder = 1, File = "p2a.png" }
                },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2a_text", StackOrder = 1, 
                    Text = @"{Name} loved the swimming costumes adorned with her favourite characters. {He} had so many swimming costumes that {he} never knew which one to choose. If {he} had {his} way {he} would have a wardrobe full of nothing but swim wear! That way {he} would have to go to school in her favourite costume, to the shopping centre in her flippers and to the park in her goggles! Perfect!",
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
                }
            });


            // P2B:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2b",
                Index = 1,
                OptionId = "Feeling",
                OptionCondition = new KeyValuePair<string,string>("Love", "Feelings"),
                BaseImageLayer = new ImageLayer { Id = "p2b_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                    new ImageLayer { Id = "p2b_image", StackOrder = 1, File = "p2b.png" }
                },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2b_text", StackOrder = 1, 
                    Text = @"{Name} loved the feeling of the water gently lapping on {his} skin. Some children adored running amok around the park, playing tag and kiss chase. Yuk! Other children were never happier than when they were let loose in the indoor play centre, like animals in a zoo! But {Name} felt at {his} very happiest surrounded by the cool waters of the pool, entering a new world, a world of water … where anything was possible. ",
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
                }
            });

            // P2C:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2c",
                Index = 1,
                OptionId = "Deep",
                OptionCondition = new KeyValuePair<string,string>("Love", "Deep"),
                BaseImageLayer = new ImageLayer { Id = "p2c_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                    new ImageLayer { Id = "p2c_image", StackOrder = 1, File = "p2c.png" }
                },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2c_text", StackOrder = 1, 
                    Text = @"{Name} loved swimming deep under the still surface of the water. Surrounded by the silence of the secret world underneath the surface, {Name} would eagerly enter this world as an explorer, searching out wondrous new worlds, magical mermaids, spooky shipwrecks and new creatures of the underworld. ",
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
                }
            });

            // P2D:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2d",
                Index = 1,
                OptionId = "Playing",
                OptionCondition = new KeyValuePair<string,string>("Love", "Playing"),
                BaseImageLayer = new ImageLayer { Id = "p2d_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                    new ImageLayer { Id = "p2d_image", StackOrder = 1, File = "p2d.png" }
                },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2d_text", StackOrder = 1, 
                    Text = @"{Name} loved playing with all the fun inflatables. To {him} they weren’t simply blow up slides in a pool. No! They were mountains surrounded by the shark ridden oceans of the Splashire world. {He} knew that if {he} didn’t cling fearlessly to the side of the erupting volcano that {he} would simply slip to {his} perilous end at the mercy of the sea monsters that lay precariously beneath.",
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
                }
            });

            // P2E:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2e",
                Index = 1,
                OptionId = "Strokes",
                OptionCondition = new KeyValuePair<string,string>("Love", "Strokes"),
                BaseImageLayer = new ImageLayer { Id = "p2e_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                    new ImageLayer { Id = "p2e_image", StackOrder = 1, File = "sea_background_900_506.png" }
                },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2e_text", StackOrder = 1, 
                    Text = @"{Name} loved practising all {his} favourite swimming strokes. To {Name} he wasn’t making {his} way across the local swimming pool. No! {he} was facing heavy competition against some of the world’s best swimmers in the Olympic Games in Splashire. {He} had never beaten the Splashirian King before! Despite him being a Merman, {Name} was determined to beat him to the finish line. The whole of the Splashire kingdom would then belong to {him}! The pressure was on!",
                    Font = myFont, Brush = myBrushWhite, X=0, Y=0 }
                }
            });


            // P3:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p3",
                Index = 0,
                OptionId = "Default",
                OptionCondition = new KeyValuePair<string, string>(),
                BaseImageLayer = new ImageLayer { Id = "p3_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                    new ImageLayer { Id = "p3_image", StackOrder = 1, File = "p3.png" }
                },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p3_text", StackOrder = 1, 
                    Text = @"{Name} was excited by the bustling sounds coming from the pool. {He} would stand shivering in {his} swimming outfit anticipating what was waiting on the other side of the tiled walls. Whilst waiting for the wail of the instructor to signal the start of the lesson, {He} would begin to wonder? Had the pirates arrived? How many prisoners had they already taken? Was that the sound of snapping piranhas?",
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
                }
            });


            // Add the character images (cheating here: using the same images for all pages)
            ImageLayer boyCaucasian = new ImageLayer { Id = "CaucasianBoyImage", File = "boy_caucasian.png", Conditions = new Dictionary<string, string>() };
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
