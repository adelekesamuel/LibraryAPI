using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Dtos
{
	public class Journals
	{
        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Publisher { get; set; }
    }
}

