using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn
{
     public class Library 
     {
          // Instanța Singleton a clasei Library
          private static Library instance;

          // Listă de cărți și DVD-uri disponibile în bibliotecă
          private List<Item> items;

          // Obține instanța Singleton a clasei Library
          public static Library Instance
          {
               get
               {
                    // Dacă instanța nu a fost creată, o creăm și inițializăm lista de itemi
                    if (instance == null)
                    {
                         instance = new Library();
                         instance.items = new List<Item>();
                    }
                    return instance;
               }
          }

          private Library()
          {
               // Constructorul privat asigură că nu se pot crea alte instanțe
          }

          // Metoda pentru adăugarea unui item în bibliotecă
          public void AddItem(Item item)
          {
               items.Add(item);
          }

          // Metoda pentru obținerea tuturor itemilor din bibliotecă
          public List<Item> GetAllItems()
          {
               return items;
          }
        
          public IIterator<Item> GetIterator()
          {
               return new LibraryIterator(items);
          }

       
     }
}
