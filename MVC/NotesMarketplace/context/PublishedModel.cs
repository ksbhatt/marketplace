using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesMarketplace.context
{
    public class PublishedModel
    {
        public SellerNote sellernote { get; set; }
        public NoteCategory notecategory { get; set; }
        public User user { get; set; }
    }
}