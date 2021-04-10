using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesMarketplace.context
{
    public class RejectedModel
    {
        public SellerNote sellernote { get; set; }
        public NoteCategory notecategory { get; set; }
    }
}