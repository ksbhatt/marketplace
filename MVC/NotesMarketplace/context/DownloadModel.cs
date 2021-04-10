using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesMarketplace.context
{
    public class DownloadModel
    {
        public SellerNote sellernote { get; set; }
        public User user { get; set; }
        public Download download { get; set; }
    }
}