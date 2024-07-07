using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppResit.Models
{
    public class BookItem
    {
        [Key]
        [StringLength(13, MinimumLength = 10)]
        public string ISBN { get; set; }

        [StringLength(255)]
        public string ItemName { get; set; }

        [StringLength(1024)]
        public string Item_desc { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        public bool? Available { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal? Price { get; set; }
        public string ImageDescription { get; set; }
        public byte[] ImageData { get; set; }
    }

    public class CheckoutCustomer
    {
    [Key]
    [StringLength(50)]
    public string Email { get; set; }
    [StringLength(50)]
    public string Name { get; set; }
    public int BasketID { get; set; }
}

    public class Basket
    {
        [Key] 
        public int BasketID { get; set; }
    }

    public class BasketItem
    {
        [Required]
        public string StockID { get; set; }
        [Required]
        public int BasketID { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
    public class OrderItem
    {
        [Required]
        public int OrderNo { get; set; }

        [Required]
        public string StockID { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
    
    
    public class OrderHistory
    {
        [Key, Required] public int OrderNo { get; set; }
        [Required] public string Email {get; set;}
    }

    
    
}