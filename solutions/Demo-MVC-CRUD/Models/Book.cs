using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demo_MVC_CRUD.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Unde ai mai vazut tu carte fara titlu?"), MinLength(3, ErrorMessage = "Gigele, titlul trebuie sa fie mai lung de 3 caractere!")]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        public int? Year { get; set; }

        public string Description { get; set; }
    }
}