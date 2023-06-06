using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn
{
     public class LibraryIterator : IIterator<Item>
     {
          private List<Item> items;
          private int currentIndex;

          public LibraryIterator(List<Item> items)
          {
               this.items = items;
               currentIndex = 0;
          }

          public bool HasNext()
          {
               return currentIndex < items.Count;
          }

          public Item Next()
          {
               Item currentItem = items[currentIndex];
               currentIndex++;
               return currentItem;
          }
     }
}
