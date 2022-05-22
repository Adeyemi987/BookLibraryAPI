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
      
        [StringLength(125)]
        public string Name { get; set; }       
        public ICollection<Book> Books { get; set; }
        

    }
}
