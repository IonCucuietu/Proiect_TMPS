using System;
using System.Collections.Generic;

namespace ProiectDeAn
{
     public class Program
     {
          public static void Main(string[] args)
          {
               // Obținem instanța singleton a clasei Library
               Library library = Library.Instance;
               // Adăugăm itemi în bibliotecă
               library.AddItem(new Book
               {
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Pages = 224,
                    Publisher = "Little, Brown and Company"
               });

               library.AddItem(new Book
               {
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Pages = 281,
                    Publisher = "J. B. Lippincott & Co."
               });

               library.AddItem(new Book
               {
                    Title = "1984",
                    Author = "George Orwell",
                    Pages = 328,
                    Publisher = "Secker & Warburg"
               });

               library.AddItem(new DVD
               {
                    Title = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Runtime = 175
               });

               library.AddItem(new DVD
               {
                    Title = "Inception",
                    Director = "Christopher Nolan",
                    Runtime = 148
               });

               library.AddItem(new DVD
               {
                    Title = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Runtime = 142
               });

               // Creăm un utilizator
               var user = new User
               {
                    Name = "John Doe",
                    Address = "123 Main St.",
                    Age = 30
               };

               // Setăm tema și dimensiunea ferestrei consolei
               Console.BackgroundColor = ConsoleColor.Black;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WindowWidth = 80;
               Console.WindowHeight = 25;
               Console.Clear();

               // Afisăm meniul principal
               bool isRunning = true;
               while (isRunning)
               {
                    Console.WriteLine(" ╔══════════════════════════════════════════════╗ ");
                    Console.WriteLine(" ║        Bine ati venit in biblioteca!         ║ ");
                    Console.WriteLine(" ║              Selectati o optiune:            ║ ");
                    Console.WriteLine(" ║                                              ║ ");
                    Console.WriteLine(" ║ 1. Vizualizati lista de carti disponibile    ║ ");
                    Console.WriteLine(" ║ 2. Vizualizati lista de DVD-uri disponibile  ║ ");
                    Console.WriteLine(" ║ 3. Adaugati un element in biblioteca         ║ ");
                    Console.WriteLine(" ║ 4. Inchideti programul                       ║ ");
                    Console.WriteLine(" ╚══════════════════════════════════════════════╝ ");
                    Console.WriteLine(); ;

                    string option = Console.ReadLine();

                    switch (option)
                    {
                         case "1":
                              DisplayBooks(library.GetAllItems());
                              break;
                         case "2":
                              DisplayDVDs(library.GetAllItems());
                              break;
                         case "3":
                              AddItemToLibrary(library);
                              break;
                         case "4":
                              isRunning = false;
                              break;
                         default:
                              Console.WriteLine("Optiune invalida. Va rugam sa selectati o optiune valida.");
                              break;
                    }
               }
          }

          public static void AddItemToLibrary(Library library)
          {
               Console.WriteLine("Adaugati un element in biblioteca:");
               Console.WriteLine("1. Carte");
               Console.WriteLine("2. DVD");
               Console.Write("Selectati tipul de element: ");
               string itemType = Console.ReadLine();

               switch (itemType)
               {
                    case "1":
                         AddBookToLibrary(library);
                         break;
                    case "2":
                         AddDVDToLibrary(library);
                         break;
                    default:
                         Console.WriteLine("Optiune invalida. Va rugam sa selectati o optiune valida.");
                         break;
               }
          }

          public static void AddBookToLibrary(Library library)
          {
               Console.Write("Titlu: ");
               string title = Console.ReadLine();

               Console.Write("Autor: ");
               string author = Console.ReadLine();

               Console.Write("Numar de pagini: ");
               int pages = int.Parse(Console.ReadLine());

               Console.Write("Editura: ");
               string publisher = Console.ReadLine();

               // Creăm o instanță de carte
               Book book = new Book
               {
                    Title = title,
                    Author = author,
                    Pages = pages,
                    Publisher = publisher
               };

               // Adaptăm cartea la interfața Item utilizând BookAdapter
               Item item = new BookAdapter(book);

               // Adăugăm cartea în bibliotecă
               library.AddItem(book);

               Console.WriteLine("Carte adaugata in biblioteca.");
               Console.WriteLine();
          }

          public static void AddDVDToLibrary(Library library)
          {
               Console.Write("Titlu: ");
               string title = Console.ReadLine();

               Console.Write("Regizor: ");
               string director = Console.ReadLine();

               Console.Write("Durata (minute): ");
               int runtime = int.Parse(Console.ReadLine());

               Console.Write("Anul lansării: ");
               int releaseYear = int.Parse(Console.ReadLine());

               Console.Write("Genul: ");
               string genre = Console.ReadLine();


               // Creăm o instanță de DVD
               DVD dvd = new DVD
               {
                    Title = title,
                    Director = director,
                    Runtime = runtime
               };

               // Decorăm DVD-ul cu DVDDecorator și setăm informațiile suplimentare
               DVDDecorator dvdDecorator = new DVDDecorator(dvd)
               {
                    ReleaseYear = releaseYear,
                    Genre = genre,
               };

               // Adăugăm DVD-ul decorat în bibliotecă
               library.AddItem(dvdDecorator);

               Console.WriteLine("DVD adaugat in biblioteca.");
               Console.WriteLine();
          }


          public static void DisplayBooks(List<Item> items)
          {
               Console.Clear();
               Console.WriteLine("Carti disponibile in biblioteca:");
               Console.WriteLine();

               foreach (var item in items)
               {
                    if (item is Book book)
                    {
                         Console.WriteLine(" ╔══════════════════════════════════════╗");
                         Console.WriteLine($" ║ Titlu: {book.Title}");
                         Console.WriteLine($" ║ Autor: {book.Author}");
                         Console.WriteLine($" ║ Numar de pagini: {book.Pages}");
                         Console.WriteLine($" ║ Editura: {book.Publisher}");
                         Console.WriteLine($" ║ Stare curenta: {item.CurrentState.GetType().Name}");
                         Console.WriteLine(" ╚══════════════════════════════════════╝");
                         Console.WriteLine();
                    }
               }

               Console.WriteLine();
               Console.WriteLine("Apasati o tasta pentru a continua...");
               Console.ReadKey();
               Console.Clear();
          }

          public static void DisplayDVDs(List<Item> items)
          {
               Console.Clear();
               Console.WriteLine("DVD-uri disponibile în bibliotecă:");
               Console.WriteLine();

               foreach (var item in items)
               {
                    if (item is DVDDecorator dvdDecorator)
                    {
                         var dvd = dvdDecorator.Item as DVD;
                         Console.WriteLine(" ╔════════════════════════════════════╗ ");
                         Console.WriteLine($" ║ Titlu: {dvd.Title}");
                         Console.WriteLine($" ║ Regizor: {dvd.Director}");
                         Console.WriteLine($" ║ Durata: {dvd.Runtime} minute");
                         Console.WriteLine($" ║ Anul lansării: {dvdDecorator.ReleaseYear}");
                         Console.WriteLine($" ║ Genul: {dvdDecorator.Genre}");
                         Console.WriteLine(" ╚════════════════════════════════════╝ ");
                         Console.WriteLine();
                    }
                    else if (item is DVD dvd)
                    {
                         Console.WriteLine(" ╔════════════════════════════════════╗ ");
                         Console.WriteLine($" ║ Titlu: {dvd.Title}");
                         Console.WriteLine($" ║ Regizor: {dvd.Director}");
                         Console.WriteLine($" ║ Durata: {dvd.Runtime} minute");
                         Console.WriteLine(" ╚════════════════════════════════════╝ ");
                         Console.WriteLine();
                    }
               }

               Console.WriteLine("Apasati o tasta pentru a reveni la meniul principal...");
               Console.ReadKey();
               Console.Clear();
          }

          public static AbstractFactory CreateFactory(string itemType)
          {
               if (itemType == "book")
               {
                    return new BookFactory();
               }
               else if (itemType == "dvd")
               {
                    return new DVDFactory();
               }
               else
               {
                    throw new ArgumentException("Tip invalid de item");
               }
          }
     }
}