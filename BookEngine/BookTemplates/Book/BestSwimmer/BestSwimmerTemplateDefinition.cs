using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEngine
{
    public class BestSwimmerTemplateDefinition
    {
        private BookTemplate bookTemplate;

        // Book Template object
        public BookTemplate Template
        {
            get { return bookTemplate; }
            set { bookTemplate = value; }
        }

        public BestSwimmerTemplateDefinition()
        {
            bookTemplate = new BookTemplate
            { 
                Id = "BestSwimmer", 
                PageTemplates = CreatePageTemplates(), 
                PageWidth = 900,
                PageHeight = 506,
                TemplateFolder = @"C:\Projects\ImageSandpit\BookEngine\BookTemplates\Book\BestSwimmer\",
                TemplateImagesFolder = @"C:\Projects\ImageSandpit\BookEngine\BookTemplates\Book\BestSwimmer\Images\",
                OutputFolder = @"C:\Projects\ImageSandpit\BookEngine\Output\BestSwimmer\"
            };

        }

        private List<PageTemplate> CreatePageTemplates()
        {
            // Text formating
            FontFamily myFontFamily = FontFamily.Families.First(x => x.Name == "Arial");
            Font myFont = new Font(myFontFamily, 24, FontStyle.Regular);
            Brush myBrush = new SolidBrush(System.Drawing.Color.DarkRed);

            List<PageTemplate> pageTemplates = new List<PageTemplate>();

            // P1:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p1",
                Index = 0,
                OptionId = "Default",
                OptionCondition = null;
                BaseImageLayer = new ImageLayer { Id = "p1_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "p1_image", StackOrder = 1, File = "p1.png" }
            },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p1_text", StackOrder = 1, 
                    Text = @"{0} loved to swim! {1} adored everything about swimming. Getting ready to go. Gathering up the swimming clothes. Picking the fluffiest towel out of the closet. Searching for {2} favourite goggles. Not forgetting, shoving that luscious smelling shower gel for the steamy shower deep into his/her special swimming bag. {0} just loooooooooooooovvvvvvvveeeeeeeeeedddddddd to swim!",
                    WordReplacements = new List<CharacterWordPlaceholder>{ CharacterWordPlaceholder.Name, CharacterWordPlaceholder.HeSheTitle, CharacterWordPlaceholder.HisHerLower },
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
            }
            });

            // P2A:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2a",
                Index = 1,
                OptionId = "Costumes",
                OptionCondition = new KeyValuePair<string,string>("Love", "Costumes");
                BaseImageLayer = new ImageLayer { Id = "p2a_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "p2a_image", StackOrder = 1, File = "p2a.png" }
            },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2a_text", StackOrder = 1, 
                    Text = @"{0} loved the swimming costumes adorned with her favourite characters. {1} had so many swimming costumes that {2} never knew which one to choose. If {2} had her way {2} would have a wardrobe full of nothing but swim wear! That way {2} would have to go to school in her favourite costume, to the shopping centre in her flippers and to the park in her goggles! Perfect!",
                    WordReplacements = new List<CharacterWordPlaceholder>{ CharacterWordPlaceholder.Name, CharacterWordPlaceholder.HeSheTitle, CharacterWordPlaceholder.HeSheLower },
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
            }
            });


            // P2B:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2b",
                Index = 1,
                OptionId = "Feeling",
                OptionCondition = new KeyValuePair<string,string>("Love", "Feelings");
                BaseImageLayer = new ImageLayer { Id = "p2b_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "p2b_image", StackOrder = 1, File = "p2b.png" }
            },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2b_text", StackOrder = 1, 
                    Text = @"{0} loved the feeling of the water gently lapping on {1} skin. Some children adored running amok around the park, playing tag and kiss chase. Yuk! Other children were never happier than when they were let loose in the indoor play centre, like animals in a zoo! But {0} felt at {!} very happiest surrounded by the cool waters of the pool, entering a new world, a world of water … where anything was possible. ",
                    WordReplacements = new List<CharacterWordPlaceholder>{ CharacterWordPlaceholder.Name, CharacterWordPlaceholder.HisHerLower },
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
            }
            });

            // P2C:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2c",
                Index = 1,
                OptionId = "Deep",
                OptionCondition = new KeyValuePair<string,string>("Love", "Deep");
                BaseImageLayer = new ImageLayer { Id = "p2c_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "p2c_image", StackOrder = 1, File = "p2c.png" }
            },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2c_text", StackOrder = 1, 
                    Text = @"{0} loved swimming deep under the still surface of the water. Surrounded by the silence of the secret world underneath the surface, {0} would eagerly enter this world as an explorer, searching out wondrous new worlds, magical mermaids, spooky shipwrecks and new creatures of the underworld. ",
                    WordReplacements = new List<CharacterWordPlaceholder>{ CharacterWordPlaceholder.Name },
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
            }
            });

            // P2D:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2d",
                Index = 1,
                OptionId = "Playing",
                OptionCondition = new KeyValuePair<string,string>("Love", "Playing");
                BaseImageLayer = new ImageLayer { Id = "p2d_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "p2d_image", StackOrder = 1, File = "p2d.png" }
            },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2d_text", StackOrder = 1, 
                    Text = @"{0} loved playing with all the fun inflatables. To {0} they weren’t simply blow up slides in a pool. No! They were mountains surrounded by the shark ridden oceans of the Splashire world. {1} knew that if {2} didn’t cling fearlessly to the side of the erupting volcano that {2} would simply slip to {3} perilous end at the mercy of the sea monsters that lay precariously beneath.",
                    WordReplacements = new List<CharacterWordPlaceholder>{ CharacterWordPlaceholder.Name, CharacterWordPlaceholder.HeSheTitle, CharacterWordPlaceholder.HeSheLower, CharacterWordPlaceholder.HisHerLower },
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
            }
            });

            // P2E:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p2e",
                Index = 1,
                OptionId = "Strokes",
                OptionCondition = new KeyValuePair<string,string>("Love", "Strokes");
                BaseImageLayer = new ImageLayer { Id = "p2e_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "p2e_image", StackOrder = 1, File = "p2e.png" }
            },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p2e_text", StackOrder = 1, 
                    Text = @"{0} loved practising all {1} favourite swimming strokes. To {0} he wasn’t making {1} way across the local swimming pool. No! {2} was facing heavy competition against some of the world’s best swimmers in the Olympic Games in Splashire. {2} had never beaten the Splashirian King before! Despite him being a Merman, {0} was determined to beat him to the finish line. The whole of the Splashire kingdom would then belong to her/him! The pressure was on!",
                    WordReplacements = new List<CharacterWordPlaceholder>{ CharacterWordPlaceholder.Name, CharacterWordPlaceholder.HisHerLower, CharacterWordPlaceholder.HeSheTitle, CharacterWordPlaceholder.HimHerLower },
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
            }
            });


            // P3:
            pageTemplates.Add(new PageTemplate
            {
                Id = "p3",
                Index = 0,
                OptionId = 0,
                BaseImageLayer = new ImageLayer { Id = "p3_base", StackOrder = -1, File = "base_900_506.png" },
                ImageLayers = new List<ImageLayer> { 
                new ImageLayer { Id = "p3_image", StackOrder = 1, File = "p3.png" }
            },
                TextLayers = new List<TextLayer> {
                new TextLayer { Id = "p3_text", StackOrder = 1, 
                    Text = @"{0} was excited by the bustling sounds coming from the pool. {1} would stand shivering in {2} swimming outfit anticipating what was waiting on the other side of the tiled walls. Whilst waiting for the wail of the instructor to signal the start of the lesson, {3} would begin to wonder? Had the pirates arrived? How many prisoners had they already taken? Was that the sound of snapping piranhas?",
                    WordReplacements = new List<CharacterWordPlaceholder>{ CharacterWordPlaceholder.Name, CharacterWordPlaceholder.HeSheTitle, CharacterWordPlaceholder.HisHerLower, CharacterWordPlaceholder.HimHerLower, CharacterWordPlaceholder.HeSheLower },
                    Font = myFont, Brush = myBrush, X=0, Y=0 }
            }
            });

            return pageTemplates;
        }
    }
}
