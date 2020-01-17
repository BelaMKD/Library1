using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Data
{
    public class BookInMemory : IBookInMemory
    {
        private readonly IAuthorInMemory authorInMemory;

        public List<Book> Books { get; set; }
        public BookInMemory(IAuthorInMemory authorInMemory)
        {

            Books = new List<Book>()
            {

                new Book
                {
                    Id=1,
                    Title="Romeo and Juliet",
                    NumberOfPages=480,
                    ImgPath="romeo.jpg",
                    Author=authorInMemory.GetAuthor(1)
                },
                new Book
                {
                    Id=2,
                    Title="Murder on the orient express",
                    NumberOfPages=256,
                    ImgPath="murder.jpg",
                    Author=authorInMemory.GetAuthor(2)
                } ,
                new Book
                {
                    Id=3,
                    Title="A stone for Danny Fisher",
                    NumberOfPages=317,
                    ImgPath="stone.jpg",
                    Author=authorInMemory.GetAuthor(3)
                }
            };
            this.authorInMemory = authorInMemory;
        } 
        public Book GetBook(int Id)
        {
            return Books.FirstOrDefault(x => x.Id == Id);
        }

        public Book Update(Book book)
        {
            var tempBook = Books.SingleOrDefault(x => x.Id == book.Id);
            if (tempBook != null)
            {
                tempBook.Title = book.Title;
                tempBook.NumberOfPages = book.NumberOfPages;
                tempBook.Author = book.Author;
            }
            return tempBook;
        }

        public int Commit()
        {
            return 1;
        }

        public Book Create(Book book)
        {
            book.Id = Books.Max(x => x.Id) + 1;
            Books.Add(book);
            return book;
        }

        public IEnumerable<Book> GetBooks(string title = null, string author = null)
        {
            if (title==null)
            {
                return Books.Where(x => string.IsNullOrEmpty(author) || x.Author.FirstName.ToLower().StartsWith(author.ToLower())).OrderBy(x => x.Id);
            }
            if (author==null)
            {
                return Books.Where(x => string.IsNullOrEmpty(title) || x.Title.ToLower().StartsWith(title.ToLower())).OrderBy(x => x.Id);
            }
            if (title!=null && author!=null)
            {
                return Books.Where(x =>x.Title.ToLower().StartsWith(title.ToLower()) && x.Author.FirstName.ToLower().StartsWith(author.ToLower())).OrderBy(x => x.Id);
            }
            else
            {
                return Books.Where(x => string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author));
            }
        }
    }
}
