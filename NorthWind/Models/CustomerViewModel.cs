
using System.ComponentModel.DataAnnotations;

namespace NorthWind.Models
{
    public class CustomerViewModel
    {
        [Required]
        public string CustomerId { get; set; }

        public string CompanyName { get; set; }

        
     
    }
}
