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
    public class EditModel : PageModel
    {
        private readonly IAuthorInMemory authorInMemory;
        [BindProperty]
        public Author Author { get; set; }
        public EditModel(IAuthorInMemory authorInMemory)
        {
            this.authorInMemory = authorInMemory;
        }
        public void OnGet(int? id)
        {
            if (id.HasValue)
            {
                Author = authorInMemory.GetAuthor(id.Value);
            }
            else
            {
                Author = new Author();
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                    if (Author.Id==0)
                {
                    Author = authorInMemory.Create(Author);
                    TempData["Message"] = "The Object is created";
                }
                else
                {
                    Author = authorInMemory.Update(Author);
                    TempData["Message"] = "The Object is updated";
                }
            }
            return RedirectToPage("/Authors/ListAuthors");
        }
    }
}