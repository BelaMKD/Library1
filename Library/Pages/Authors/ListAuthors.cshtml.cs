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
    public class ListAuthorsModel : PageModel
    {
        private readonly IAuthorInMemory authorInMemory;
        public IEnumerable<Author> Authors { get; set; }
        public ListAuthorsModel(IAuthorInMemory authorInMemory)
        {
            this.authorInMemory = authorInMemory;
        }
        public void OnGet()
        {
            Authors = authorInMemory.GetAuthors();
        }
    }
}