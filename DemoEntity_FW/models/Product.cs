using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    [Table("Products")]
    public class Products
    {

        [Key]
        public int ProductId { set; get; }

        [Required]
        [StringLength(50)]
        public string Name { set; get; }

        [StringLength(50)]
        public string Provider { set; get; }
        public void printInfor()
        {
            
            Console.WriteLine($"{ProductId} - {Name} - {Provider}");
        }
    }

    
        
}
