using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Domain
{
   public class HairStyle
    {
        public int Id { get; set; }
        public enum HairStyles
        {
            Chonmage, Oicho, Western
        }
    }
}
