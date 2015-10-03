using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookEngine
{
    public class Book
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string TemplateId { get; set; }
        public string PersonalMessage { get; set; }
        public Character Character { get; set; }
        public List<Page> Pages { get; set; }
    }

    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HairColour { get; set; }
        public string SkinColour { get; set; }
        public string Gender {get; set;}
    }

    public class Page
    {
        public int Id { get; set; }
        public int Index { get; set; }
        public string Type { get; set; }
        public string TemplateId { get; set; }
        public string TemplateOptionId { get; set; }
        public string ImageFile { get; set; }
        public string ImageFileRelative { get; set; }
    }
}
