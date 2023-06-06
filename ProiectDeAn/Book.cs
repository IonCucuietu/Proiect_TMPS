using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn
{
     public class Book : Item
     {
          public string Author { get; set; }
          public int Pages { get; set; }
          public string Publisher { get; set; }
     }
}
