using System;

namespace WebApplication3.Controllers
{
    internal class MyDatabaseEntities
    {
        public object User { get; internal set; }
        public object Configuration { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}