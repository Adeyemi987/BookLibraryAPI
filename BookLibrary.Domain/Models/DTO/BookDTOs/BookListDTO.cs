using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models.DTO.BookDTOs
{
    public class BookListDTO
    {
        public string Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string PublishedOn { get; set; }       
        public string Description { get; set; }
        public string AuthorsOrdered { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
