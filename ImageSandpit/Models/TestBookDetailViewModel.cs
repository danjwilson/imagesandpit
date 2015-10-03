using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookEngine;

namespace ImageSandpit.Models
{
    public class TestBookDetailViewModel
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string TemplateId { get; set; }
        public string PersonalMessage { get; set; }
        public Character Character { get; set; }
        public List<Page> Pages { get; set; }

        public TestBookDetailViewModel(Book book)
        {
            Id = book.Id;
            CustomerId = book.CustomerId;
            TemplateId = book.TemplateId;
            PersonalMessage = book.PersonalMessage;
            Character = book.Character;
            Pages = book.Pages;
        }
    }
}
