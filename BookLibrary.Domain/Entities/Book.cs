using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [StringLength(125)]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        [ForeignKey("Category")]
        public int categoryId { get; set; }
        public Category category { get; set; }
        public DateTime Created { get; set; } = DateTime.Today;
        public DateTime Updated { get; set; } = DateTime.Today;
        [StringLength(500)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFavorite { get; set; }

    }
}
