using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models.DTO.BookDTOs
{
    public class BookRequestDTO
    {
        [Required]
        [StringLength(maximumLength: 125, ErrorMessage = "Title should not be more than 125 characters long")]
        public string Title { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Name of Author should not be more than 50 characters long")]
        public string Author { get; set; }

        [Required]
        [StringLength(maximumLength: 125, ErrorMessage = "Publisher Name should not be more than 125 characters long")]
        public string Publisher { get; set; }

        public string PublishedDate { get; set; }

        [Required]
        [StringLength(maximumLength: 13, ErrorMessage = "ISBN should not be more than 13 characters long")]
        public string ISBN { get; set; }

        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(maximumLength: 1050, ErrorMessage = "Description Too long"), DataType(DataType.Text)]
        public string Description { get; set; }

        public bool? IsFavorite { get; set; }
    }
}
