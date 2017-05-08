using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
    public class Quotes
    {
        public int Id { get; set; }
        public string SamuraiQuotes { get; set; }
       public virtual QuoteTypes QuouteTypes { get; set; }
        public virtual Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}
