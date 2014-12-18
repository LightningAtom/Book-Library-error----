using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Annotation { get; set; }
        public string ISBN { get; set; }
        public DateTime Date { get; set; }
    }

    class Catalog
    {
        List<Book> BookList = new List<Book>(); 
        Book BookInCatalog = new Book();
        Book Found = new Book();

        public Book SearchByName(Book FindByName)
        {
            Found = BookList.Find(b => b.Name == FindByName.Name);
            return Found;
        }

        public Book SearchByISBN(Book FindByISBN)
        {
            Found = BookList.Find(b => b.ISBN == FindByISBN.ISBN);
            return Found;
        }

        public void SearchByTag()
        {
            //SearchByTag
        }
        public void Add(Book AddBook)
        {
            BookList.Add(AddBook);
        }

        public void Remove(Book BookForRemove)
        {
            foreach (var item in BookList)
            {
                BookList.Remove(BookList.Find(x => x.Name == BookForRemove.Name));
            }
        }
    }

    class IO
    {
        List<string> MenuList = new List<string> { "1.Add Book", "2.Search", "3.Exit" };
        List<string> SearchList = new List<string> { "1.By Name", "2.By ISBN", "3.By Tags", "To Main Menu" };
        List<string> MenuName = new List<string> { "Main Menu", "Search", "Exit" };
        Catalog CatalogIoIO = new Catalog();
        Book BookInIO = new Book();
        private int _case;

        public void PrintMenu(List<string> menu)
        {
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
        }
        public void FirstMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------Main Menu----------------------------------");
            PrintMenu(MenuList);
            _case = int.Parse(Console.ReadLine());
            switch (_case)
            {
                case 1:
                    PrintAddBook();
                    break;
                case 2:
                    SecondMenu();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        public void SecondMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------Search----------------------------------");
            PrintMenu(SearchList);
            _case = int.Parse(Console.ReadLine());
            switch (_case)
            {
                case 1:
                    PrintSearchBooksByName();
                    break;
                case 2:
                    PrintSearchBooksByISBN();
                    break;
                case 3:
                    //Search by tag
                    break;
                case 4:
                    FirstMenu();
                    break;
            }
        }

        public void PrintBookInfo(Book BookInfo)
        {
            Console.WriteLine("Name: ", CatalogIoIO.SearchByName(BookInfo).Name);
            Console.WriteLine("Author: ", CatalogIoIO.SearchByName(BookInfo).Author);
            Console.WriteLine("Genre: ", CatalogIoIO.SearchByName(BookInfo).Genre);
            Console.WriteLine("Annotation: ", CatalogIoIO.SearchByName(BookInfo).Annotation);
            Console.WriteLine("ISBN: ", CatalogIoIO.SearchByName(BookInfo).ISBN);
            Console.WriteLine("Date: ", CatalogIoIO.SearchByName(BookInfo).Date);
        }

        public void PrintSearchBooksByName()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------Search By Name---------------------------------");
            Console.Write("Name: ");
            BookInIO.Name = Console.ReadLine();
            PrintBookInfo(BookInIO);
            Console.WriteLine("Press Key to Escape ");
            Console.ReadKey();
            FirstMenu();
        }
        public void PrintSearchBooksByISBN()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------Search By ISBN---------------------------------");
            Console.Write("ISBN: ");
            BookInIO.ISBN = Console.ReadLine();
            PrintBookInfo(BookInIO);
            Console.WriteLine("Press Key to Escape ");
            Console.ReadKey();
            FirstMenu();
        }
        public void PrintAddBook()
        {
            Console.Write("Name: ");
            BookInIO.Name = Console.ReadLine();
            Console.Write("Author: ");
            BookInIO.Author = Console.ReadLine();
            Console.Write("Genre: ");
            BookInIO.Genre = Console.ReadLine();
            Console.Write("Annotation: ");
            BookInIO.Annotation = Console.ReadLine();
            Console.Write("ISBN: ");
            BookInIO.ISBN = Console.ReadLine();
            CatalogIoIO.Add(BookInIO);
            FirstMenu();
        }
        public void RemoveBook()
        {
            Console.Write("Name: ");
            BookInIO.Name = Console.ReadLine();
            CatalogIoIO.Remove(BookInIO);
        }
    }

    class Program
    {
       
       static void Main()
        {
           var instance = new IO();
           instance.FirstMenu();
        }
    }
}
