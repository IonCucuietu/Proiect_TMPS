using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn
{
     public class DVDDecorator : ItemDecorator
     {
          public int ReleaseYear { get; set; }
          public string Genre { get; set; }
          public List<string> Actors { get; set; }

          public DVDDecorator(Item item) : base(item)
          {
          }

          public override string Title
          {
               get { return $"[DVD] {decoratedItem.Title}"; }
               set { decoratedItem.Title = value; }
          }

          public Item Item
          {
               get { return decoratedItem; }
          }
     }
}
