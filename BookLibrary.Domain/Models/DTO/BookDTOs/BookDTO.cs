using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Models.DTO.BookDTOs
{
    public class BookDTO
    {
        public string Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Authors { get; set; }
        public string Publisher { get; set; }
       
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
