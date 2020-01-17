using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Core
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Display(Name ="Number of books:"), Required]
        public int NumberOfBooks { get; set; }
        [Required]
        public string Description { get; set; }
        public string ImgPath { get; set; }
        [Display(Name = "Written by:")]

        public string FullName 
        { 
            get 
            { 
                return this.FirstName + " " + this.LastName; 
            }
            set
            {
                this.FirstName = value;
                this.LastName = value;
            }
        }
    }
    
}
