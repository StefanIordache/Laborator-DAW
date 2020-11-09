using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Demo_MVC_CRUD.CustomValidations;

namespace Demo_MVC_CRUD.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [OnlyGmail(ErrorMessage = "Foloseste doar Gmail, e mai fain decat Yahoo!")]
        public string Email { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}