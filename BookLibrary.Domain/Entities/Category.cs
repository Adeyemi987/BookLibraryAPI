using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Books = new List<Book>();
        }
      
        [StringLength(125)]
        public string Name { get; set; }       
        public ICollection<Book> Books { get; set; }
        

    }
}
