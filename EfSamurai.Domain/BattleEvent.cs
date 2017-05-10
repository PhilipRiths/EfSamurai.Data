﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
  public  class BattleEvent
    {
        public int Id { get; set; }
        public string Description { get; set; } 
        public string Summary { get; set; }
        public int SortOrder { get; set; }
        public DateTime BattleDate { get; set; }

        public int BatlleLogId { get; set; }
        public virtual BattleLog BattleLog { get; set; }

    }
}
