using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotesMarketplace.context
{
    public class RequestModel
    {
        public User user { get; set; }
        public Download download { get; set; }
    }
}