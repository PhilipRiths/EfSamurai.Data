  using System;
  using System.Collections.Generic;

namespace EfSamurai.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Healthpoints { get; set; }
        public HairStyle HairStyleTypes { get; set; }
        public virtual ICollection<Quotes> Quote { get; set; }
        
        
    }
}
