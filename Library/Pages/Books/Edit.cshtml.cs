    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly IBookInMemory bookInMemory;
        private readonly IAuthorInMemory authorInMemory;

        public List<SelectListItem> FullNames { get; set; }
        [BindProperty]
        public Book Book { get; set; }
        public Author Author { get; set; }
        public EditModel(IBookInMemory bookInMemory, IAuthorInMemory authorInMemory)
        {
            this.bookInMemory = bookInMemory;
            this.authorInMemory = authorInMemory;
        }
        public IActionResult OnGet(int? Id)
        {
            if (Id.HasValue)
            {
                Book = bookInMemory.GetBook(Id.Value);
                Author = authorInMemory.GetAuthor(Id.Value);
               
                if (Book == null)
                {
                    return RedirectToPage("/Books/ListBooks");
                }
            }
            else
            {
                Book = new Book();
            }
            FullNames = authorInMemory.GetAuthors().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName
            }).ToList();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var author = authorInMemory.GetAuthor(Book.AuthorId);
                Book.Author = author;
                if (Book.Id==0)
                {
                    Book = bookInMemory.Create(Book);
                    TempData["Message"] = "The book is created";
                }
                else
                {
                    Book = bookInMemory.Update(Book);
                    TempData["Message"] = "The book is updated";
                }
                bookInMemory.Commit();                
                return RedirectToPage("./Details", new { Id = Book.Id });
            }
            FullNames = authorInMemory.GetAuthors().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName
            }).ToList();
            return Page();
        }
    }
}