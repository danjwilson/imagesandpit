using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace BookEngine
{
    public class OptionItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsDefault { get; set; }
    }

    public class BookTemplate
    {
        public string Id { get; set; }
        public List<PageTemplate> PageTemplates { get; set; }
        public float PageWidth { get; set; }
        public float PageHeight { get; set; }
        public string TemplateFolder { get; set; }
        public string TemplateImagesFolder { get; set; }
        public string OutputFolder { get; set; }
    }

    public class PageTemplate
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public string OptionId { get; set; }
        public KeyValuePair<string, string> OptionCondition { get; set; }
        public Dictionary<string, string> Conditions { get; set; }
        public ImageLayer BaseImageLayer { get; set; }
        public List<ImageLayer> ImageLayers { get; set; }
        public List<TextLayer> TextLayers { get; set; }
    }

    public class ImageLayer
    {
        public string Id { get; set; }
        public int StackOrder { get; set; }
        public string File { get; set; }
        public Dictionary<string, string> Conditions { get; set; }
    }
    
    public class TextLayer
    {
        public string Id { get; set; }
        public int StackOrder { get; set; }
        public string Text { get; set; }
        [IgnoreDataMemberAttribute]
        public Font Font { get; set; }
        [IgnoreDataMemberAttribute]
        public Brush Brush { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}
