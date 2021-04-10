using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesMarketplace.context
{
    public class APublishedModel
    {
        public SellerNote sellernote { get; set; }
        public NoteCategory notecategory { get; set; }
        public User user { get; set; }
        public User auser { get; set; }
    }
}