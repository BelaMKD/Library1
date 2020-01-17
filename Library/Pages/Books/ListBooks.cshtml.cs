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
    public class ListBooksModel : PageModel
    {
        private readonly IBookInMemory bookInMemory;
        public List<SelectListItem> FullNames { get; set; }
        public IEnumerable<Book> Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTitle { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchAuthor { get; set; }
        public ListBooksModel(IBookInMemory bookInMemory)
        {
            this.bookInMemory = bookInMemory;
        }
        public IActionResult OnGet()
        {
            Books = bookInMemory.GetBooks(SearchTitle, SearchAuthor);
            //if (SearchTitle!=null)
            //{
            //    Books = bookInMemory.GetBooks(SearchTitle);
            //    return Page();
            //}
            //if (SearchAuthor!=null)
            //{
            //    Books = bookInMemory.GetBooksByAuthor(SearchAuthor);
            //    return Page();
            //}
            //if (SearchTitle)
            //{

            //}
            return Page();
        }
    }
}