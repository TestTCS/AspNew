using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using AspDemoApp.DB;
using AspDemoApp.Models;

namespace AspDemoApp.DB
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //var context = serviceProvider.GetService<MyDbContext>();
            var context = new MyDbContext();
           // context.Database.Migrate();
           
                var austen = context.Authors.Add(
                    new Author { LastName = "Austen", FirstMidName = "Jane" }).Entity;
                var dickens = context.Authors.Add(
                    new Author { LastName = "Dickens", FirstMidName = "Charles" }).Entity;
                var cervantes = context.Authors.Add(
                    new Author { LastName = "Cervantes", FirstMidName = "Miguel" }).Entity;

                context.Books.AddRange(
                    new Book()
                    {
                        Title = "Pride and Prejudice",
                        Year = 1813,
                        Author = austen,
                        Price = 9.99M,
                        Genre = "Comedy of manners"
                    },
                    new Book()
                    {
                        Title = "Northanger Abbey",
                        Year = 1817,
                        Author = austen,
                        Price = 12.95M,
                        Genre = "Gothic parody"
                    },
                    new Book()
                    {
                        Title = "David Copperfield",
                        Year = 1850,
                        Author = dickens,
                        Price = 15,
                        Genre = "Bildungsroman"
                    },
                    new Book()
                    {
                        Title = "Don Quixote",
                        Year = 1617,
                        Author = cervantes,
                        Price = 8.95M,
                        Genre = "Picaresque"
                    }
                );
               // context.SaveChanges();
            }
        


        


        public List<Book> GetsBooks()
        {
            List<Book> CollBooks = new List<Book>();
        CollBooks.Add(
                   new Book()
                   {
                       Title = "Pride and Prejudice",
                       Year = 1813,
                       //  Author = "austen",
                       Price = 9.99M,
                       Genre = "Comedy of manners"
                   });
            CollBooks.Add(
                   new Book()
                   {
                       Title = "Northanger Abbey",
                       Year = 1817,
                       // Author = austen,
                       Price = 12.95M,
                       Genre = "Gothic parody"
                   });
            CollBooks.Add(new Book()
            {
                Title = "David Copperfield",
                Year = 1850,
                //Author = dickens,
                Price = 15,
                Genre = "Bildungsroman"
            });
            CollBooks.Add(new Book()
            {
                Title = "Don Quixote",
                Year = 1617,
                //Author = cervantes,
                Price = 8.95M,
                Genre = "Picaresque"
            });
            return CollBooks;
        }
    }
}
