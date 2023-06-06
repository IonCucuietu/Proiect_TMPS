using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn
{
     public class DVDFactory : AbstractFactory
     {
          public Item CreateItem()
          {
               return new DVD();
          }

     }
}
