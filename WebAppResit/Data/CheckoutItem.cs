using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebAppResit.Data;

public class CheckoutItem
{
    
        
        [Key, Required]
        public string ISBN { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required,StringLength(50)]
        public string ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }
    [Required]
    public int BasketID { get; set; }

}