using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
  public  class QuoteTypes
    {
        public int Id { get; set; }
        public enum Quotes
        {
          Lame, Cheesy, Awesome
    }
}
    
    }