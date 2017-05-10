using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Brutal { get; set; }
        public DateTime  StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<SamuraiBattle> SamuraiBattle { get; set; }
      
        public virtual BattleLog BattleLog { get; set; }
       
      

    }
}