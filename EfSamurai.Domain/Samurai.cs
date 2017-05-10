  using System;
  using System.Collections.Generic;

namespace EfSamurai.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public HairStyles HairStyleTypes { get; set; }
        public virtual ICollection<Quotes> Quotes { get; set; }
        public virtual SecretIdentity SecretIdentity { get; set; }
        public virtual ICollection<SamuraiBattle> SamuraiBattle { get; set; }
   


    }
}
