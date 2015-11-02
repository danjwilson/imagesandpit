using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace BookEngine
{
    public static class Builder
    {
        public static Dictionary<string, List<OptionItem>> GetCharacterOptionItems(string bookTemplateId)
        {
            // TO DO: Get option items by deserializing JSON
            Dictionary<string, List<OptionItem>> characterOptions = new Dictionary<string, List<OptionItem>>();
            switch (bookTemplateId.ToUpper())
            {
                case "BESTSWIMMER":
                    characterOptions = BestSwimmerDefinition.GetCharacterOptionItems();
                    break;
                default:
                    characterOptions = BestSwimmerDefinition.GetCharacterOptionItems();
                    break;
            }

            return characterOptions;
        }

        public static Dictionary<string, List<OptionItem>> GetPageOptionItems(string bookTemplateId)
        {
            // TO DO: Get option items by deserializing JSON
            Dictionary<string, List<OptionItem>> pageOptions = new Dictionary<string, List<OptionItem>>();
            switch (bookTemplateId.ToUpper())
            {
                case "BESTSWIMMER":
                    pageOptions = BestSwimmerDefinition.GetPageOptionItems();
                    break;
                default:
                    pageOptions = BestSwimmerDefinition.GetPageOptionItems();
                    break;
            }

            return pageOptions;
        }

        public static Book BuildBook(string bookTemplateId, Dictionary<string, string> selectedCharacterOptions, Dictionary<string, string> selectedPageOptions)
        {
            // TO DO: Get book template by deserializing JSON
            BookTemplate bookTemplate;
            switch(bookTemplateId.ToUpper())
            {
                case "BESTSWIMMER":
                    bookTemplate = BestSwimmerDefinition.GetTemplate();
                    break;
                default:
                    bookTemplate = BestSwimmerDefinition.GetTemplate();
                    break;                    
            }

            return Builder.BuildBook(bookTemplate, selectedCharacterOptions, selectedPageOptions);
        }

        public static Book BuildBook(BookTemplate bookTemplate, Dictionary<string, string> selectedCharacterOptions, Dictionary<string, string> selectedPageOptions)
        {
            Book book = new Book
            {
                CustomerId = selectedCharacterOptions["CustomerId"],
                PersonalMessage = selectedCharacterOptions["PersonalMessage"],
                TemplateId = bookTemplate.Id
            };

            // Create character
            book.Character = new Character
            { 
                Name = selectedCharacterOptions["Name"], 
                Gender = selectedCharacterOptions["Gender"],
                HairColour = selectedCharacterOptions["HairColour"], 
                SkinColour = selectedCharacterOptions["SkinColour"]
            };

            // Create pages based on template ** Currently assuming there is only one option for each page
            book.Pages = new List<Page>();

            foreach (PageTemplate pageTemplate in bookTemplate.PageTemplates)
            {
                // Check to see if this page template is the selected option
                // ** // TO DO // ** //
                // >>>> USE pageOptions !!!! <<<< //
                if (pageTemplate.OptionCondition.Value != null && pageTemplate.OptionCondition.Value != selectedPageOptions[pageTemplate.OptionCondition.Key])
                    continue;

                Page page = new Page();
                page.Index = pageTemplate.Index;
                page.TemplateId = pageTemplate.Id;
                page.TemplateOptionId = pageTemplate.OptionId;

                // Copy new base image based on base page image
                string baseImageFile = bookTemplate.TemplateImagesFolder + pageTemplate.BaseImageLayer.File;
                page.ImageFile = bookTemplate.OutputFolder + book.Id + @"-" + pageTemplate.Id + ".png";
                page.ImageFileRelative = @"../Output/" + book.Id + @"-" + pageTemplate.Id + ".png";
                File.Copy(baseImageFile, page.ImageFile, true);

                // Determine which image layers to include depending on specified conditions
                List<ImageLayer> processedImageLayers = new List<ImageLayer>();
                foreach (ImageLayer imageLayer in pageTemplate.ImageLayers)
                {
                    bool include = true;
                    if (imageLayer.Conditions != null)
                    {
                        foreach (KeyValuePair<string, string> condition in imageLayer.Conditions)
                        {
                            if (selectedCharacterOptions[condition.Key] != condition.Value)
                            {
                                include = false;
                                break;
                            }
                        }
                    }
                    if (include)
                    {
                        processedImageLayers.Add(imageLayer);
                    }
                }

                // Word replacement logic for text layers
                List<TextLayer> processedTextLayers = new List<TextLayer>();
                foreach (TextLayer textLayer in pageTemplate.TextLayers)
                {
                    textLayer.Text = WordReplaceHelper.Replace(book.Character, textLayer.Text);
                    processedTextLayers.Add(textLayer);
                }


                // Physically create the layers and add page
                Image newPageImage = AddLayers(bookTemplate.TemplateImagesFolder, page.ImageFile, processedImageLayers, processedTextLayers, bookTemplate.PageWidth, bookTemplate.PageHeight);
                newPageImage.Save(page.ImageFile);
                newPageImage.Save(page.ImageFileRelative.Replace("..", @"C:\git\danjwilson\ImageSandpit\ImageSandpit")); // << + duplicated for website access [**to be reviewed**]

                book.Pages.Add(page);
            }

            return book;
        }

        private static Image AddLayers(string templateImageFolder, string targetImageFile, List<ImageLayer> imageLayers, List<TextLayer> textLayers, float imageWidth, float imageHeight)
        {
            Image newImage;

            using (Image targetImage = Image.FromFile(targetImageFile))
            {
                using (Bitmap b = new Bitmap((int)imageWidth, (int)imageHeight))
                {
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                        g.DrawImage(targetImage, new Rectangle(0, 0, b.Width, b.Height));

                        // Add image layers
                        foreach (ImageLayer imageLayer in imageLayers)
                        {
                            using (Image imageToAdd = Image.FromFile(templateImageFolder + imageLayer.File, true))
                            {
                                g.DrawImage(imageToAdd, new Rectangle(0, 0, (int)imageWidth, (int)imageHeight));
                            }
                        }

                        // Add text layers
                        foreach (TextLayer textLayer in textLayers)
                        {
                            RectangleF recFormat = new RectangleF { X = textLayer.X, Y = textLayer.Y, Width = 800, Height = 400 };
                            g.DrawString(textLayer.Text, textLayer.Font, textLayer.Brush, recFormat);
                        }
                    }

                    newImage = Image.FromHbitmap(b.GetHbitmap());
                }
            }

            return newImage;
        }
    }
}
