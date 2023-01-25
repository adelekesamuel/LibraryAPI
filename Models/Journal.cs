using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Journal
    {
        [Key]
        public int id { get; set; }

        [Required]
        public Guid UniqueId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        [StringLength(100)]
        public string? Author { get; set; }

        [Required]
        [StringLength(100)]
        public string? Publisher { get; set; }

    }
}