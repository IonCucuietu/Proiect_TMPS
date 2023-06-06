using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn
{
     public abstract class ItemDecorator : Item
     {
          protected Item decoratedItem;

          public ItemDecorator(Item item)
          {
               decoratedItem = item;
          }

          public override string Title
          {
               get { return decoratedItem.Title; }
               set { decoratedItem.Title = value; }
          }
     }
}
