using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Core;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Library.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly IAuthorInMemory authorInMemory;
        public Author Author { get; set; }
        public DetailsModel(IAuthorInMemory authorInMemory)
        {
            this.authorInMemory = authorInMemory;
        }
        public IActionResult OnGet(int Id)
        {
            Author = authorInMemory.GetAuthor(Id);
            if (Author==null)
            {
                return RedirectToPage("/Authors/List");
            }
            return Page();
        }
    }
}