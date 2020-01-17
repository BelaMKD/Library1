using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly IBookInMemory bookInMemory;
        public Book Book { get; set; }
        [TempData]
        public string Message { get; set; }
        public DetailsModel(IBookInMemory bookInMemory)
        {
            this.bookInMemory = bookInMemory;
        }
        public IActionResult OnGet(int Id)
        {
            Book = bookInMemory.GetBook(Id);
            if (Book == null)
            {
                return RedirectToPage("/Books/ListBooks");
            }
            return Page();
        }
    }
}