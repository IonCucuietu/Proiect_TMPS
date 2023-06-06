using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn
{
     public class BookAdapter : Item
     {
          private Book book;

          public BookAdapter(Book book)
          {
               this.book = book;
          }

          public string Title
          {
               get { return book.Title; }
               set { book.Title = value; }
          }
     }
}
