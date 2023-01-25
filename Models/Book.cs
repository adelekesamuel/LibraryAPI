using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
	public class Book
	{
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]

        public string? Title { get; set; }

        [Required]
        [StringLength(75)]

        public string? Autor { get; set; }

    }
}

